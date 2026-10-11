using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ProjetoExtensionista2026_2
{
    public partial class UcCardProduto : UserControl
    {
        public int ProdutoId { get; private set; }
        public decimal PrecoVenda { get; private set; }
        public decimal PrecoCompra { get; private set; }

        public UcCardProduto()
        {
            InitializeComponent();

            // Faz o clique em qualquer elemento interno (labels, foto) propagar para o card
            foreach (Control ctrl in Controls)
            {
                ctrl.Click += (s, e) => this.InvokeOnClick(this, e);
            }
        }

        public void CarregarDados(int id, string nome, string descricao, decimal precoVenda, decimal precoCompra, string fotoOrigem)
        {
            ProdutoId = id;
            PrecoVenda = precoVenda;
            PrecoCompra = precoCompra;

            lblTitulo.Text = $"[#{id}] {nome}";
            lblDescricao.Text = string.IsNullOrWhiteSpace(descricao) ? "Sem descrição disponível." : descricao;
            lblPrecoVenda.Text = precoVenda.ToString("C2");
            lblPrecoCompra.Text = $"Custo: {precoCompra:C2}";

            CarregarImagem(fotoOrigem);
        }

        private void CarregarImagem(string fotoOrigem)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(fotoOrigem))
                {
                    picFoto.Image = null;
                    return;
                }

                if (fotoOrigem.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                    fotoOrigem.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                {
                    picFoto.LoadAsync(fotoOrigem);
                }
                else if (File.Exists(fotoOrigem))
                {
                    picFoto.Image = Image.FromFile(fotoOrigem);
                }
                else
                {
                    byte[] imageBytes = Convert.FromBase64String(fotoOrigem);
                    using (var ms = new MemoryStream(imageBytes))
                    {
                        picFoto.Image = Image.FromStream(ms);
                    }
                }
            }
            catch
            {
                picFoto.Image = null;
            }
        }
    }
}