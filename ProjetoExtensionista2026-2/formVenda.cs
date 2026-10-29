using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjetoExtensionista2026_2
{
    public partial class formVenda : Form
    {
        private UcEstoque _ucEstoque;

        // Controle numérico dos descontos
        private long _descontoCentavos = 0;    
        private int _descontoPorcentagem = 0;
        private bool _atualizandoDesconto = false;

        private decimal DescontoAtual => _descontoCentavos / 100m;

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

            if (panel != null)
            {
                panel.AutoScroll = true;
            }

            ConfigurarCamposDesconto();
            AtualizarTotaisCarrinho();
        }

        private void ConfigurarCamposDesconto()
        {

            if (txtDesconto != null)
            {
                txtDesconto.ShortcutsEnabled = false;
                txtDesconto.Text = "- R$ 0,00";

                txtDesconto.KeyPress += txtDesconto_KeyPress;
                txtDesconto.KeyDown += txtDesconto_KeyDown;
                txtDesconto.MouseDown += (s, ev) => txtDesconto.Select(txtDesconto.Text.Length, 0);
                txtDesconto.GotFocus += (s, ev) => txtDesconto.Select(txtDesconto.Text.Length, 0);
            }

            if (txtDescontoPorcentagem != null)
            {
                txtDescontoPorcentagem.ShortcutsEnabled = false;
                txtDescontoPorcentagem.Text = "0 %";

                txtDescontoPorcentagem.KeyPress += txtDescontoPorcentagem_KeyPress;
                txtDescontoPorcentagem.KeyDown += txtDescontoPorcentagem_KeyDown;
                txtDescontoPorcentagem.MouseDown += (s, ev) => txtDescontoPorcentagem.Select(txtDescontoPorcentagem.Text.Length, 0);
                txtDescontoPorcentagem.GotFocus += (s, ev) => txtDescontoPorcentagem.Select(txtDescontoPorcentagem.Text.Length, 0);
            }
        }

        private void splitContainer_menu_SplitterMoved(object sender, SplitterEventArgs e)
        {
            double percMin = 0.18;
            double percMax = 0.25;

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

        private void AcaoSelecionarProduto(int idProduto, string nomeProduto, decimal precoVenda, int quantidade, string fotoUrl, int estoqueDisponivel)
        {
            AdicionarOuIncrementarCarrinho(idProduto, nomeProduto, precoVenda, quantidade, fotoUrl, estoqueDisponivel);
        }

        private void AdicionarOuIncrementarCarrinho(int idProduto, string nomeProduto, decimal precoVenda, int quantidade, string fotoUrl, int estoqueDisponivel)
        {
            if (panel == null) return;

            if (estoqueDisponivel <= 0)
            {
                MessageBox.Show(
                    $"O produto '{nomeProduto}' está com o estoque esgotado!",
                    "Estoque Indisponível",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            panel.SuspendLayout();

            foreach (Control ctrl in panel.Controls)
            {
                if (ctrl is UcCardVenda cardExistente && cardExistente.ProdutoId == idProduto)
                {
                    int limiteEstoque = cardExistente.EstoqueMaximo;
                    int qtdAtual = cardExistente.Quantidade;

                    if (qtdAtual >= limiteEstoque)
                    {
                        panel.ResumeLayout();
                        MessageBox.Show(
                            $"Limite atingido! O carrinho já possui todas as {limiteEstoque} unidade(s) disponíveis no estoque para '{cardExistente.NomeProduto}'.",
                            "Estoque Máximo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }

                    if (qtdAtual + quantidade > limiteEstoque)
                    {
                        panel.ResumeLayout();
                        int restantePermitido = limiteEstoque - qtdAtual;
                        MessageBox.Show(
                            $"Não é possível adicionar mais {quantidade} unidade(s). Você já tem {qtdAtual} no carrinho e restam apenas {restantePermitido} no estoque.",
                            "Estoque Insuficiente",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }

                    int novaQuantidade = qtdAtual + quantidade;
                    cardExistente.CarregarItem(
                        idProduto,
                        cardExistente.NomeProduto,
                        precoVenda,
                        novaQuantidade,
                        limiteEstoque,
                        cardExistente.FotoOrigem ?? fotoUrl
                    );

                    panel.ResumeLayout();
                    AtualizarTotaisCarrinho();
                    return;
                }
            }

            if (quantidade > estoqueDisponivel)
            {
                panel.ResumeLayout();
                MessageBox.Show(
                    $"Não é possível adicionar {quantidade} unidades de '{nomeProduto}'. O estoque atual possui apenas {estoqueDisponivel} unidade(s).",
                    "Estoque Insuficiente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            var novoItem = new UcCardVenda();
            novoItem.Dock = DockStyle.Top;
            novoItem.Margin = new Padding(0, 0, 0, 4);

            novoItem.CarregarItem(idProduto, nomeProduto, precoVenda, quantidade, estoqueDisponivel, fotoUrl);

            novoItem.AoAlterarQuantidade += (id, novaQtd, novoTotalItem) =>
            {
                AtualizarTotaisCarrinho();
            };

            novoItem.AoRemoverItem += (id, cardRemover) =>
            {
                panel.Controls.Remove(cardRemover);
                cardRemover.Dispose();
                AtualizarTotaisCarrinho();
            };

            panel.Controls.Add(novoItem);
            novoItem.BringToFront();

            panel.ResumeLayout();
            AtualizarTotaisCarrinho();
        }

        private decimal ObterSubtotalAtual()
        {
            decimal subtotal = 0m;
            if (panel != null)
            {
                foreach (Control ctrl in panel.Controls)
                {
                    if (ctrl is UcCardVenda item)
                    {
                        subtotal += item.PrecoTotal;
                    }
                }
            }
            return subtotal;
        }

        private void AtualizarTotaisCarrinho()
        {
            decimal subtotal = ObterSubtotalAtual();
            int totalItens = 0;

            if (panel != null)
            {
                foreach (Control ctrl in panel.Controls)
                {
                    if (ctrl is UcCardVenda item)
                        totalItens += item.Quantidade;
                }
            }

            if (DescontoAtual > subtotal)
            {
                _descontoCentavos = (long)Math.Round(subtotal * 100m);
                AtualizarDescontoPorValor();
            }

            decimal totalFinal = Math.Max(0m, subtotal - DescontoAtual);

            if (lblSubtotal != null)
                lblSubtotal.Text = subtotal.ToString("C2");

            if (lblTotal != null)
                lblTotal.Text = totalFinal.ToString("C2");

            if (lblQtdItens != null)
                lblQtdItens.Text = $"{totalItens} item(ns)";
        }

        private void txtDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            if (char.IsDigit(e.KeyChar))
            {
                int digito = e.KeyChar - '0';
                long proximoCentavos = (_descontoCentavos * 10) + digito;
                decimal subtotal = ObterSubtotalAtual();
                long subtotalCentavos = (long)Math.Round(subtotal * 100m);

                if (proximoCentavos > subtotalCentavos)
                {
                    _descontoCentavos = subtotalCentavos;
                }
                else
                {
                    _descontoCentavos = proximoCentavos;
                }

                AtualizarDescontoPorValor();
            }
        }

        private void txtDesconto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = true;
                _descontoCentavos /= 10;
                AtualizarDescontoPorValor();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                e.SuppressKeyPress = true;
                _descontoCentavos = 0;
                AtualizarDescontoPorValor();
            }
        }

        private void AtualizarDescontoPorValor()
        {
            if (_atualizandoDesconto) return;
            _atualizandoDesconto = true;

            try
            {
                decimal subtotal = ObterSubtotalAtual();

                if (DescontoAtual > subtotal)
                    _descontoCentavos = (long)Math.Round(subtotal * 100m);

                int pctCalculada = (subtotal > 0m) ? (int)Math.Round((DescontoAtual / subtotal) * 100m) : 0;
                _descontoPorcentagem = Math.Min(100, Math.Max(0, pctCalculada));

                if (txtDesconto != null)
                {
                    txtDesconto.Text = $"- R$ {DescontoAtual:N2}";
                    txtDesconto.SelectionStart = txtDesconto.Text.Length;
                }

                if (txtDescontoPorcentagem != null)
                {
                    txtDescontoPorcentagem.Text = $"{_descontoPorcentagem} %";
                }

                AtualizarTotaisCarrinho();
            }
            finally
            {
                _atualizandoDesconto = false;
            }
        }

        private void txtDescontoPorcentagem_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            if (char.IsDigit(e.KeyChar))
            {
                int digito = e.KeyChar - '0';
                int proximoValor = (_descontoPorcentagem * 10) + digito;

                _descontoPorcentagem = Math.Min(100, proximoValor);

                AtualizarDescontoPorPorcentagem();
            }
        }

        private void txtDescontoPorcentagem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = true;
                _descontoPorcentagem /= 10;
                AtualizarDescontoPorPorcentagem();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                e.SuppressKeyPress = true;
                _descontoPorcentagem = 0;
                AtualizarDescontoPorPorcentagem();
            }
        }

        private void AtualizarDescontoPorPorcentagem()
        {
            if (_atualizandoDesconto) return;
            _atualizandoDesconto = true;

            try
            {
                if (_descontoPorcentagem > 100)
                    _descontoPorcentagem = 100;

                decimal subtotal = ObterSubtotalAtual();
                decimal valorCalculado = subtotal * (_descontoPorcentagem / 100m);

                valorCalculado = Math.Min(subtotal, Math.Round(valorCalculado, 2));
                _descontoCentavos = (long)Math.Round(valorCalculado * 100m);

                if (txtDescontoPorcentagem != null)
                {
                    txtDescontoPorcentagem.Text = $"{_descontoPorcentagem} %";
                    txtDescontoPorcentagem.SelectionStart = txtDescontoPorcentagem.Text.Length;
                }

                if (txtDesconto != null)
                {
                    txtDesconto.Text = $"- R$ {DescontoAtual:N2}";
                }

                AtualizarTotaisCarrinho();
            }
            finally
            {
                _atualizandoDesconto = false;
            }
        }

        private void btnLimparCarrinho_Click(object sender, EventArgs e)
        {
            if (panel == null || panel.Controls.Count == 0) return;

            var confirmacao = MessageBox.Show(
                "Deseja realmente esvaziar o carrinho de compras?",
                "Limpar Carrinho",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacao == DialogResult.Yes)
            {
                panel.SuspendLayout();
                while (panel.Controls.Count > 0)
                {
                    Control c = panel.Controls[0];
                    panel.Controls.Remove(c);
                    c.Dispose();
                }
                panel.ResumeLayout();

                _descontoCentavos = 0;
                _descontoPorcentagem = 0;

                if (txtDesconto != null)
                    txtDesconto.Text = "- R$ 0,00";

                if (txtDescontoPorcentagem != null)
                    txtDescontoPorcentagem.Text = "0 %";

                AtualizarTotaisCarrinho();
            }
        }
    }
}