using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ProjetoExtensionista2026_2
{
    public partial class UcCardProduto : UserControl
    {
        public int ProdutoId { get; private set; }
        public string NomeProduto { get; private set; }
        public string DescricaoProduto { get; private set; }
        public decimal PrecoVenda { get; private set; }
        public decimal PrecoCompra { get; private set; }
        public int Estoque { get; private set; }
        public string FotoOrigem { get; private set; }

        public event Action<int, decimal, int> AoAdicionarProduto;
        // Evento disparado para abrir os detalhes/edição
        public event Action<UcCardProduto> AoClicarParaEditar;

        public UcCardProduto()
        {
            InitializeComponent();

            UpDownProduto.Minimum = 1;
            UpDownProduto.Maximum = 999;
            UpDownProduto.Value = 1;

            picFoto.SizeMode = PictureBoxSizeMode.Zoom;

            // Vincula o clique nos elementos que cobrem o card
            VincularCliquesDeEdicao();
        }

        private void VincularCliquesDeEdicao()
        {
            EventHandler dispararEdicao = (s, e) => AoClicarParaEditar?.Invoke(this);

            // Clique no fundo do card e nos textos/foto
            this.Click += dispararEdicao;
            picFoto.Click += dispararEdicao;
            lblTitulo.Click += dispararEdicao;
            lblDescricao.Click += dispararEdicao;
            lblPrecoVenda.Click += dispararEdicao;
            lblPrecoCompra.Click += dispararEdicao;
            lblEstoque.Click += dispararEdicao;

            // O UpDownProduto e o btnAdicionar NÃO recebem esse evento,
            // garantindo que adicionar item à venda funcione separadamente.
        }

        public void CarregarDados(int id, string nome, string descricao, decimal precoVenda, decimal precoCompra, int estoque, string fotoOrigem)
        {
            ProdutoId = id;
            NomeProduto = nome;
            DescricaoProduto = descricao;
            PrecoVenda = precoVenda;
            PrecoCompra = precoCompra;
            Estoque = estoque;
            FotoOrigem = fotoOrigem;

            lblTitulo.Text = $"{id} - {LimitarTexto(nome, 38)}";
            lblDescricao.Text = LimitarTexto(string.IsNullOrWhiteSpace(descricao) ? "Sem descrição disponível." : descricao, 70);
            lblPrecoVenda.Text = precoVenda.ToString("C2");
            lblPrecoCompra.Text = $"Custo: {precoCompra:C2}";

            lblEstoque.Text = $"Estoque: {estoque}";
            lblEstoque.ForeColor = estoque <= 0 ? Color.Red : Color.FromArgb(70, 70, 70);

            UpDownProduto.Value = 1;
            CarregarImagem(fotoOrigem);
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

        private void CarregarImagem(string fotoOrigem)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(fotoOrigem))
                {
                    AplicarImagemAjustada(Properties.Resources.produto_ausente);
                    return;
                }

                if (fotoOrigem.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                    fotoOrigem.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                {
                    using (var clienteWeb = new System.Net.WebClient())
                    {
                        byte[] dados = clienteWeb.DownloadData(fotoOrigem);
                        using (var ms = new MemoryStream(dados))
                        {
                            using (var imgOriginal = Image.FromStream(ms))
                            {
                                AplicarImagemAjustada(imgOriginal);
                            }
                        }
                    }
                }
                else if (File.Exists(fotoOrigem))
                {
                    using (var imgOriginal = Image.FromFile(fotoOrigem))
                    {
                        AplicarImagemAjustada(imgOriginal);
                    }
                }
                else
                {
                    byte[] imageBytes = Convert.FromBase64String(fotoOrigem);
                    using (var ms = new MemoryStream(imageBytes))
                    {
                        using (var imgOriginal = Image.FromStream(ms))
                        {
                            AplicarImagemAjustada(imgOriginal);
                        }
                    }
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