using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoExtensionista2026_2
{
    public partial class UcCardProduto : UserControl
    {
        // Cache estático em memória para evitar baixar a mesma imagem da web repetidas vezes
        private static readonly ConcurrentDictionary<string, Image> _imageCache = new ConcurrentDictionary<string, Image>();

        public ProdutoDTO DadosProduto { get; private set; }

        public int ProdutoId { get; private set; }
        public string NomeProduto { get; private set; }
        public string DescricaoProduto { get; private set; }
        public decimal PrecoVenda { get; private set; }
        public decimal PrecoCompra { get; private set; }
        public int Estoque { get; private set; }
        public string FotoOrigem { get; private set; }

        public event Action<int, decimal, int> AoAdicionarProduto;
        public event Action<ProdutoDTO> AoClicarParaEditar;

        public UcCardProduto()
        {
            InitializeComponent();

            UpDownProduto.Minimum = 1;
            UpDownProduto.Maximum = 999;
            UpDownProduto.Value = 1;

            picFoto.SizeMode = PictureBoxSizeMode.Zoom;

            // Vincula o clique recursivamente em todos os controles internos
            VincularCliquesDeEdicao(this);
        }

        /// <summary>
        /// Percorre o card e todos os seus painéis/filhos aplicando o clique de edição
        /// </summary>
        private void VincularCliquesDeEdicao(Control container)
        {
            EventHandler dispararEdicao = (s, e) =>
            {
                if (DadosProduto != null)
                {
                    AoClicarParaEditar?.Invoke(DadosProduto);
                }
            };

            foreach (Control ctrl in container.Controls)
            {
                // Ignora explicitamente o seletor numérico e o botão de adicionar venda
                if (ctrl == UpDownProduto || ctrl == btnAdicionar || ctrl is NumericUpDown || ctrl is Button)
                {
                    ctrl.Cursor = Cursors.Default;
                    continue;
                }

                // Aplica o clique e a mãozinha no controle
                ctrl.Click += dispararEdicao;
                ctrl.Cursor = Cursors.Hand;

                if (ctrl.HasChildren)
                {
                    VincularCliquesDeEdicao(ctrl);
                }
            }

            container.Click += dispararEdicao;
            container.Cursor = Cursors.Hand;
        }

        public void CarregarDados(ProdutoDTO p)
        {
            if (p == null) return;

            DadosProduto = p;

            ProdutoId = p.Id;
            NomeProduto = p.Nome;
            DescricaoProduto = p.Descricao;
            PrecoVenda = p.PrecoVenda;
            PrecoCompra = p.PrecoCompra;
            Estoque = p.Estoque;
            FotoOrigem = p.FotoUrl;

            lblTitulo.Text = $"{p.Id} - {LimitarTexto(p.Nome, 38)}";
            lblDescricao.Text = LimitarTexto(string.IsNullOrWhiteSpace(p.Descricao) ? "Sem descrição disponível." : p.Descricao, 70);
            lblPrecoVenda.Text = p.PrecoVenda.ToString("C2");
            lblPrecoCompra.Text = $"Custo: {p.PrecoCompra:C2}";

            lblEstoque.Text = $"Estoque: {p.Estoque}";
            lblEstoque.ForeColor = p.Estoque <= 0 ? Color.Red : Color.FromArgb(70, 70, 70);

            UpDownProduto.Value = 1;
            _ = CarregarImagemAsync(p.FotoUrl); // Executa o carregamento assíncrono otimizado
        }

        public void CarregarDados(int id, string nome, string descricao, decimal precoVenda, decimal precoCompra, int estoque, string fotoOrigem)
        {
            var dto = new ProdutoDTO
            {
                Id = id,
                Codigo = id.ToString(),
                Nome = nome,
                Descricao = descricao,
                PrecoVenda = precoVenda,
                PrecoCompra = precoCompra,
                Estoque = estoque,
                FotoUrl = fotoOrigem,
                Ativo = true
            };

            CarregarDados(dto);
        }

        private string LimitarTexto(string texto, int max)
        {
            if (string.IsNullOrWhiteSpace(texto)) return "";
            return texto.Length <= max ? texto : texto.Substring(0, max).TrimEnd() + "...";
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            int quantidade = (int)UpDownProduto.Value;
            AoAdicionarProduto?.Invoke(ProdutoId, PrecoVenda, quantidade);
            UpDownProduto.Value = 1;
        }

        private async Task CarregarImagemAsync(string fotoOrigem)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(fotoOrigem))
                {
                    AplicarImagemAjustada(Properties.Resources.produto_ausente);
                    return;
                }

                // 1. Verifica se já existe em Cache na memória
                if (_imageCache.TryGetValue(fotoOrigem, out Image imagemCached))
                {
                    AplicarImagemAjustada(imagemCached);
                    return;
                }

                Image imgOriginal = null;

                if (fotoOrigem.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                    fotoOrigem.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                {
                    using (var clienteWeb = new WebClient())
                    {
                        clienteWeb.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");
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
                        using (var tempImg = Image.FromStream(stream))
                        {
                            imgOriginal = new Bitmap(tempImg);
                        }
                    }
                }
                else
                {
                    byte[] imageBytes = Convert.FromBase64String(fotoOrigem);
                    using (var ms = new MemoryStream(imageBytes))
                    {
                        imgOriginal = Image.FromStream(ms);
                    }
                }

                if (imgOriginal != null)
                {
                    _imageCache.TryAdd(fotoOrigem, imgOriginal);
                    AplicarImagemAjustada(imgOriginal);
                }
                else
                {
                    AplicarImagemAjustada(Properties.Resources.produto_ausente);
                }
            }
            catch
            {
                AplicarImagemAjustada(Properties.Resources.produto_ausente);
            }
        }

        private void AplicarImagemAjustada(Image imgOriginal)
        {
            if (imgOriginal == null || picFoto.Width <= 0 || picFoto.Height <= 0)
                return;

            int alvoW = picFoto.Width;
            int alvoH = picFoto.Height;

            Bitmap bmpCortado = new Bitmap(alvoW, alvoH);

            using (Graphics g = Graphics.FromImage(bmpCortado))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                float ratio = Math.Max((float)alvoW / imgOriginal.Width, (float)alvoH / imgOriginal.Height);

                int larguraFinal = (int)(imgOriginal.Width * ratio);
                int alturaFinal = (int)(imgOriginal.Height * ratio);

                int posX = (alvoW - larguraFinal) / 2;
                int posY = (alvoH - alturaFinal) / 2;

                g.DrawImage(imgOriginal, posX, posY, larguraFinal, alturaFinal);
            }

            picFoto.Image?.Dispose();
            picFoto.SizeMode = PictureBoxSizeMode.Normal;
            picFoto.Image = bmpCortado;
        }
    }
}