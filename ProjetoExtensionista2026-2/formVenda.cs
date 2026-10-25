using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjetoExtensionista2026_2
{
    public partial class formVenda : Form
    {
        private UcEstoque _ucEstoque;

        public formVenda()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Maximized;
        }

        private void formVenda_Load(object sender, EventArgs e)
        {
            _ucEstoque = new UcEstoque();
            _ucEstoque.Dock = DockStyle.Fill;

            _ucEstoque.ConfigurarPerfilVendedor(true);
            _ucEstoque.AoAdicionarAoCarrinho += AcaoSelecionarProduto;

            panelConteudo.Controls.Clear();
            panelConteudo.Controls.Add(_ucEstoque);
            _ucEstoque.BringToFront();

            _ucEstoque.BuscarProdutosNoSupabase("");
        }

        private void splitContainer_menu_SplitterMoved(object sender, SplitterEventArgs e)
        {
            double percMin = 0.15;
            double percMax = 0.22;

            int larguraTotal = splitContainer_menu.Width;
            int limiteMinimo = (int)(larguraTotal * percMin);
            int limiteMaximo = (int)(larguraTotal * percMax);

            if (splitContainer_menu.SplitterDistance < limiteMinimo)
                splitContainer_menu.SplitterDistance = limiteMinimo;
            else if (splitContainer_menu.SplitterDistance > limiteMaximo)
                splitContainer_menu.SplitterDistance = limiteMaximo;
        }

        private void splitContainer_catalogo_SplitterMoved(object sender, SplitterEventArgs e)
        {
            double percMin = 0.60;
            double percMax = 0.70;

            int larguraTotal = splitContainer_catalogo.Width;
            int limiteMinimo = (int)(larguraTotal * percMin);
            int limiteMaximo = (int)(larguraTotal * percMax);

            if (splitContainer_catalogo.SplitterDistance < limiteMinimo)
                splitContainer_catalogo.SplitterDistance = limiteMinimo;
            else if (splitContainer_catalogo.SplitterDistance > limiteMaximo)
                splitContainer_catalogo.SplitterDistance = limiteMaximo;
        }

        private void AcaoSelecionarProduto(int idProduto, decimal precoVenda, int quantidade)
        {
            decimal totalItem = precoVenda * quantidade;

            // Ponto de integração com a grelha/lista do carrinho de compras
            MessageBox.Show($"Produto ID: {idProduto}\nQuantidade: {quantidade}\nUnitário: {precoVenda:C2}\nTotal: {totalItem:C2}",
                            "Item Adicionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}