using Npgsql;
using ProjetoExtensionista2026_2.SQL;
using System;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace ProjetoExtensionista2026_2
{
    public partial class formVenda : Form
    {
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
            if (flowLayoutPanelProdutos != null)
            {
                typeof(FlowLayoutPanel).InvokeMember("DoubleBuffered",
                    BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                    null, flowLayoutPanelProdutos, new object[] { true });

                flowLayoutPanelProdutos.AutoScroll = true;
                flowLayoutPanelProdutos.Resize += (s, ev) => CentralizarCards();
            }

            BuscarProdutosNoSupabase("");
        }

        private void splitContainer_menu_SplitterMoved(object sender, SplitterEventArgs e)
        {
            double percMin = 0.15;
            double percMax = 0.22;

            int larguraTotal = splitContainer_menu.Width;
            int limiteMinimo = (int)(larguraTotal * percMin);
            int limiteMaximo = (int)(larguraTotal * percMax);

            if (splitContainer_menu.SplitterDistance < limiteMinimo)
            {
                splitContainer_menu.SplitterDistance = limiteMinimo;
            }
            else if (splitContainer_menu.SplitterDistance > limiteMaximo)
            {
                splitContainer_menu.SplitterDistance = limiteMaximo;
            }
        }

        private void splitContainer_catalogo_SplitterMoved(object sender, SplitterEventArgs e)
        {
            double percMin = 0.60;
            double percMax = 0.70;

            int larguraTotal = splitContainer_catalogo.Width;
            int limiteMinimo = (int)(larguraTotal * percMin);
            int limiteMaximo = (int)(larguraTotal * percMax);

            if (splitContainer_catalogo.SplitterDistance < limiteMinimo)
            {
                splitContainer_catalogo.SplitterDistance = limiteMinimo;
            }
            else if (splitContainer_catalogo.SplitterDistance > limiteMaximo)
            {
                splitContainer_catalogo.SplitterDistance = limiteMaximo;
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            BuscarProdutosNoSupabase(txtPesquisa.Text);
        }

        private void txtPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                BuscarProdutosNoSupabase(txtPesquisa.Text);
            }
        }

        /// <summary>
        /// Consulta a tabela 'product' no Supabase usando a classe Connection e popula o FlowLayoutPanel.
        /// </summary>
        private void BuscarProdutosNoSupabase(string filtroTexto)
        {
            flowLayoutPanelProdutos.Controls.Clear();

            string query = @"
        SELECT 
            p.id_product,
            p.name AS name_product,
            p.description AS description_product,
            p.purchase_price AS price_buy,
            p.sale_price AS price_sell,
            p.location AS location_product,
            p.stock_quantity,
            p.min_stock AS min_stock_quantity,
            p.unit AS unit_measure,
            c.name_category AS category_product,
            s.name AS supplier_product,
            p.is_active AS active,
            p.image_url AS picture_url
        FROM public.product p
        LEFT JOIN public.category c ON c.id_category = p.id_category
        LEFT JOIN public.supplier s ON s.id_supplier = p.id_supplier
        WHERE p.is_active = TRUE
          AND (
              @filtro = '' 
              OR p.name ILIKE @filtro_like 
              OR p.description ILIKE @filtro_like
          )
        ORDER BY p.id_product ASC
        LIMIT 40;";

            try
            {
                using (var db = new Connection())
                {
                    db.IniciarConexao();

                    using (var cmd = new NpgsqlCommand(query, db.Conexao))
                    {
                        string filtro = filtroTexto?.Trim() ?? "";
                        cmd.Parameters.AddWithValue("@filtro", filtro);
                        cmd.Parameters.AddWithValue("@filtro_like", $"%{filtro}%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            flowLayoutPanelProdutos.SuspendLayout();

                            while (reader.Read())
                            {
                                var prod = new ProdutoDTO
                                {
                                    Id = Convert.ToInt32(reader["id_product"]),
                                    Nome = reader.IsDBNull(reader.GetOrdinal("name_product")) ? "" : reader.GetString(reader.GetOrdinal("name_product")),
                                    Descricao = reader.IsDBNull(reader.GetOrdinal("description_product")) ? "" : reader.GetString(reader.GetOrdinal("description_product")),
                                    PrecoCompra = reader.IsDBNull(reader.GetOrdinal("price_buy")) ? 0m : reader.GetDecimal(reader.GetOrdinal("price_buy")),
                                    PrecoVenda = reader.IsDBNull(reader.GetOrdinal("price_sell")) ? 0m : reader.GetDecimal(reader.GetOrdinal("price_sell")),
                                    Localizacao = reader.IsDBNull(reader.GetOrdinal("location_product")) ? "" : reader.GetString(reader.GetOrdinal("location_product")),
                                    Estoque = reader.IsDBNull(reader.GetOrdinal("stock_quantity")) ? 0 : Convert.ToInt32(reader.GetDecimal(reader.GetOrdinal("stock_quantity"))),
                                    EstoqueMinimo = reader.IsDBNull(reader.GetOrdinal("min_stock_quantity")) ? 0 : reader.GetInt32(reader.GetOrdinal("min_stock_quantity")),
                                    Unidade = reader.IsDBNull(reader.GetOrdinal("unit_measure")) ? "" : reader.GetString(reader.GetOrdinal("unit_measure")),
                                    Categoria = reader.IsDBNull(reader.GetOrdinal("category_product")) ? "" : reader.GetString(reader.GetOrdinal("category_product")),
                                    Fornecedor = reader.IsDBNull(reader.GetOrdinal("supplier_product")) ? "" : reader.GetString(reader.GetOrdinal("supplier_product")),
                                    Ativo = reader.GetBoolean(reader.GetOrdinal("active")),
                                    FotoUrl = reader.IsDBNull(reader.GetOrdinal("picture_url")) ? null : reader.GetString(reader.GetOrdinal("picture_url"))
                                };

                                var card = new UcCardProduto();
                                card.Margin = new Padding(8);
                                card.CarregarDados(prod);

                                card.AoAdicionarProduto += (prodId, preco, qtd) =>
                                {
                                    AcaoSelecionarProduto(prodId, preco, qtd);
                                };

                                card.AoClicarParaEditar += (produtoClicado) =>
                                {
                                    AbrirModalProduto(produtoClicado);
                                };

                                flowLayoutPanelProdutos.Controls.Add(card);
                            }

                            flowLayoutPanelProdutos.ResumeLayout();
                            CentralizarCards();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao consultar produtos no Supabase: {ex.Message}",
                                "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Método unificado: abre o UcCadastroProduto tanto para Cadastrar (produto == null) quanto para Editar
        /// </summary>
        private void AbrirModalProduto(ProdutoDTO produto = null)
        {
            using (var formModal = new Form())
            {
                var ucCadastro = new UcCadastroProduto();

                if (produto != null)
                {
                    // Modo Edição: preenche os campos com os dados existentes
                    ucCadastro.CarregarDadosParaEdicao(produto);
                    formModal.Text = $"Editar Produto - {produto.Nome}";
                }
                else
                {
                    // Modo Novo Cadastro: limpa os campos e gera o próximo código automático
                    ucCadastro.LimparCampos();
                    formModal.Text = "Cadastrar Novo Produto";
                }

                ucCadastro.Dock = DockStyle.Fill;
                formModal.ClientSize = ucCadastro.Size;
                formModal.StartPosition = FormStartPosition.CenterParent;
                formModal.FormBorderStyle = FormBorderStyle.FixedDialog;
                formModal.MaximizeBox = false;
                formModal.MinimizeBox = false;
                formModal.Controls.Add(ucCadastro);

                ucCadastro.AoConcluirOperacao += () =>
                {
                    formModal.DialogResult = DialogResult.OK;
                    formModal.Close();
                };

                if (formModal.ShowDialog(this) == DialogResult.OK)
                {
                    BuscarProdutosNoSupabase(txtPesquisa.Text);
                }
            }
        }

        private void AcaoSelecionarProduto(int idProduto, decimal precoVenda, int quantidade)
        {
            decimal totalItem = precoVenda * quantidade;

            MessageBox.Show($"Produto ID: {idProduto}\nQuantidade: {quantidade}\nUnitário: {precoVenda:C2}\nTotal: {totalItem:C2}",
                            "Item Adicionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CentralizarCards()
        {
            if (flowLayoutPanelProdutos == null || flowLayoutPanelProdutos.Controls.Count == 0)
                return;

            Control primeiroCard = flowLayoutPanelProdutos.Controls[0];
            int larguraTotalDoCard = primeiroCard.Width + primeiroCard.Margin.Horizontal;

            int larguraDisponivel = flowLayoutPanelProdutos.ClientSize.Width;

            int colunas = larguraDisponivel / larguraTotalDoCard;
            if (colunas < 1)
                colunas = 1;

            if (flowLayoutPanelProdutos.Controls.Count < colunas)
            {
                colunas = flowLayoutPanelProdutos.Controls.Count;
            }

            int larguraOcupadaPelosCards = colunas * larguraTotalDoCard;
            int sobra = (larguraDisponivel - larguraOcupadaPelosCards) / 2;

            if (sobra < 0)
                sobra = 0;

            flowLayoutPanelProdutos.Padding = new Padding(sobra, flowLayoutPanelProdutos.Padding.Top, 0, flowLayoutPanelProdutos.Padding.Bottom);
        }

        private void btnCadastrarProduto_Click(object sender, EventArgs e)
        {
            // Abre o mesmo modal, porém vazio para novo registro
            AbrirModalProduto();
        }
    }
}