using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoExtensionista2026_2
{
    public partial class UcCardVenda : UserControl
    {
        private static readonly ConcurrentDictionary<string, Image> _imageCache = new ConcurrentDictionary<string, Image>();

        public int ProdutoId { get; private set; }
        public string NomeProduto { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public int Quantidade { get; private set; }
        public int EstoqueMaximo { get; private set; } = 999;
        public string FotoOrigem { get; private set; }
        public decimal PrecoTotal => PrecoUnitario * Quantidade;

        // Eventos para comunicação com o formVenda
        public event Action<int, int, decimal> AoAlterarQuantidade;
        public event Action<int, UcCardVenda> AoRemoverItem;

        public UcCardVenda()
        {
            InitializeComponent();

            if (picFoto != null)
                picFoto.SizeMode = PictureBoxSizeMode.Zoom;

            // Vinculação programática dos botões para evitar falhas de evento no Designer
            if (btnAumentar != null)
            {
                btnAumentar.Click -= btnAumentar_Click;
                btnAumentar.Click += btnAumentar_Click;
            }

            if (btnDiminuir != null)
            {
                btnDiminuir.Click -= btnDiminuir_Click;
                btnDiminuir.Click += btnDiminuir_Click;
            }

            if (btnExcluir != null)
            {
                btnExcluir.Click -= btnExcluir_Click;
                btnExcluir.Click += btnExcluir_Click;
            }
        }

        /// <summary>
        /// Popula todos os dados do produto no card de venda, incluindo imagem e preço.
        /// </summary>
        public void CarregarItem(int id, string nome, decimal precoUnitario, int quantidadeInicial = 1, int estoqueDisponivel = 999, string fotoUrl = null)
        {
            ProdutoId = id;
            NomeProduto = string.IsNullOrWhiteSpace(nome) ? $"Item #{id}" : nome;
            PrecoUnitario = precoUnitario;
            EstoqueMaximo = estoqueDisponivel > 0 ? estoqueDisponivel : 1;
            Quantidade = Math.Max(1, Math.Min(quantidadeInicial, EstoqueMaximo));
            FotoOrigem = fotoUrl;

            AtualizarInterface();
            _ = CarregarImagemAsync(FotoOrigem);
        }

        /// <summary>
        /// Atualiza os textos e o estado dos botões de controle de quantidade.
        /// </summary>
        private void AtualizarInterface()
        {
            if (lblCodigo != null)
                lblCodigo.Text = $"#{ProdutoId}";

            if (lblNomeProduto != null)
                lblNomeProduto.Text = NomeProduto;

            if (lblPrecoUnitario != null)
                lblPrecoUnitario.Text = PrecoUnitario.ToString("C2");

            if (lblPrecoTotal != null)
                lblPrecoTotal.Text = PrecoTotal.ToString("C2");

            if (lblQuantidade != null)
                lblQuantidade.Text = Quantidade.ToString();

            if (btnDiminuir != null)
                btnDiminuir.Enabled = Quantidade > 1;

            if (btnAumentar != null)
                btnAumentar.Enabled = Quantidade < EstoqueMaximo;
        }

        private void btnAumentar_Click(object sender, EventArgs e)
        {
            if (Quantidade < EstoqueMaximo)
            {
                Quantidade++;
                AtualizarInterface();
                AoAlterarQuantidade?.Invoke(ProdutoId, Quantidade, PrecoTotal);
            }
        }

        private void btnDiminuir_Click(object sender, EventArgs e)
        {
            if (Quantidade > 1)
            {
                Quantidade--;
                AtualizarInterface();
                AoAlterarQuantidade?.Invoke(ProdutoId, Quantidade, PrecoTotal);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            AoRemoverItem?.Invoke(ProdutoId, this);
        }

        /// <summary>
        /// Baixa e faz cache da imagem para exibir no picFoto.
        /// </summary>
        private async Task CarregarImagemAsync(string fotoOrigem)
        {
            if (picFoto == null) return;

            try
            {
                if (string.IsNullOrWhiteSpace(fotoOrigem))
                {
                    picFoto.Image = Properties.Resources.produto_ausente;
                    return;
                }

                if (_imageCache.TryGetValue(fotoOrigem, out Image imagemCached))
                {
                    picFoto.Image = imagemCached;
                    return;
                }

                Image imgOriginal = null;

                if (fotoOrigem.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                    fotoOrigem.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                {
                    using (var clienteWeb = new WebClient())
                    {
                        clienteWeb.Headers.Add("User-Agent", "Mozilla/5.0");
                        byte[] dados = await clienteWeb.DownloadDataTaskAsync(new Uri(fotoOrigem));
                        using (var ms = new MemoryStream(dados))
                        {
                            imgOriginal = Image.FromStream(ms);
                        }
                    }
                }
                else if (File.Exists(fotoOrigem))
                {
                    using (var stream = new FileStream(fotoOrigem, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        using (var temp = Image.FromStream(stream))
                        {
                            imgOriginal = new Bitmap(temp);
                        }
                    }
                }

                if (imgOriginal != null)
                {
                    _imageCache.TryAdd(fotoOrigem, imgOriginal);
                    picFoto.Image = imgOriginal;
                }
                else
                {
                    picFoto.Image = Properties.Resources.produto_ausente;
                }
            }
            catch
            {
                picFoto.Image = Properties.Resources.produto_ausente;
            }
        }
    }
}