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

            // Ativa o modo PDV (oculta custos e botões administrativos de estoque)
            _ucEstoque.ConfigurarPerfilVendedor(true);

            // Vincula o evento que adiciona itens do catálogo ao carrinho
            _ucEstoque.AoAdicionarAoCarrinho += AcaoSelecionarProduto;

            panelConteudo.Controls.Clear();
            panelConteudo.Controls.Add(_ucEstoque);
            _ucEstoque.BringToFront();

            _ucEstoque.BuscarProdutosNoSupabase("");

            // Garante que o painel do carrinho role verticalmente
            if (panelCarrinho != null)
            {
                panelCarrinho.AutoScroll = true;
            }

            AtualizarTotaisCarrinho();
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

        /// <summary>
        /// Ação principal disparada pelo catálogo repassando ID, nome, preço, quantidade e foto.
        /// </summary>
        private void AcaoSelecionarProduto(int idProduto, string nomeProduto, decimal precoVenda, int quantidade, string fotoUrl)
        {
            AdicionarOuIncrementarCarrinho(idProduto, nomeProduto, precoVenda, quantidade, fotoUrl);
        }

        /// <summary>
        /// Sobrecarga de compatibilidade caso o evento envie apenas os dados básicos.
        /// </summary>
        private void AcaoSelecionarProduto(int idProduto, string nomeProduto, decimal precoVenda, int quantidade)
        {
            AdicionarOuIncrementarCarrinho(idProduto, nomeProduto, precoVenda, quantidade, null);
        }

        private void AdicionarOuIncrementarCarrinho(int idProduto, string nomeProduto, decimal precoVenda, int quantidade, string fotoUrl)
        {
            if (panelCarrinho == null) return;

            panelCarrinho.SuspendLayout();

            // 1. Se o produto já estiver no carrinho, apenas incrementa a quantidade
            foreach (Control ctrl in panelCarrinho.Controls)
            {
                if (ctrl is UcCardVenda cardExistente && cardExistente.ProdutoId == idProduto)
                {
                    int novaQuantidade = cardExistente.Quantidade + quantidade;
                    cardExistente.CarregarItem(
                        idProduto,
                        cardExistente.NomeProduto,
                        precoVenda,
                        novaQuantidade,
                        cardExistente.EstoqueMaximo,
                        cardExistente.FotoOrigem ?? fotoUrl
                    );

                    panelCarrinho.ResumeLayout();
                    AtualizarTotaisCarrinho();
                    return;
                }
            }

            // 2. Se for um produto novo no carrinho, cria o card
            var novoItem = new UcCardVenda();
            novoItem.Dock = DockStyle.Top;
            novoItem.Margin = new Padding(0, 0, 0, 4);

            novoItem.CarregarItem(idProduto, nomeProduto, precoVenda, quantidade, 999, fotoUrl);

            // 3. Conecta eventos de recalcular totais e remoção
            novoItem.AoAlterarQuantidade += (id, novaQtd, novoTotalItem) =>
            {
                AtualizarTotaisCarrinho();
            };

            novoItem.AoRemoverItem += (id, cardRemover) =>
            {
                panelCarrinho.Controls.Remove(cardRemover);
                cardRemover.Dispose();
                AtualizarTotaisCarrinho();
            };

            panelCarrinho.Controls.Add(novoItem);
            novoItem.BringToFront(); // Mantém empilhado de cima para baixo

            panelCarrinho.ResumeLayout();
            AtualizarTotaisCarrinho();
        }

        /// <summary>
        /// Percorre todos os itens no painel do carrinho e atualiza os rótulos de valores na tela.
        /// </summary>
        private void AtualizarTotaisCarrinho()
        {
            decimal totalGeral = 0m;
            int totalItens = 0;

            if (panelCarrinho != null)
            {
                foreach (Control ctrl in panelCarrinho.Controls)
                {
                    if (ctrl is UcCardVenda item)
                    {
                        totalGeral += item.PrecoTotal;
                        totalItens += item.Quantidade;
                    }
                }
            }
        }

        /// <summary>
        /// Limpa todos os itens do carrinho e zera os totais.
        /// </summary>
        private void btnLimparCarrinho_Click(object sender, EventArgs e)
        {
            if (panelCarrinho == null || panelCarrinho.Controls.Count == 0) return;

            var confirmacao = MessageBox.Show(
                "Deseja realmente esvaziar o carrinho de compras?",
                "Limpar Carrinho",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacao == DialogResult.Yes)
            {
                panelCarrinho.SuspendLayout();
                while (panelCarrinho.Controls.Count > 0)
                {
                    Control c = panelCarrinho.Controls[0];
                    panelCarrinho.Controls.Remove(c);
                    c.Dispose();
                }
                panelCarrinho.ResumeLayout();

                AtualizarTotaisCarrinho();
            }
        }
    }
}