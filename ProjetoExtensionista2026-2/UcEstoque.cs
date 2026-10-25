using Npgsql;
using ProjetoExtensionista2026_2.SQL;
using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace ProjetoExtensionista2026_2
{
    public partial class UcEstoque : UserControl
    {
        // Evento que notifica o formulário hospedeiro quando um item for selecionado/adicionado
        public event Action<int, decimal, int> AoAdicionarAoCarrinho;

        private bool _podeVerOcultos = true;
        private string _filtroAtual = "";

        public UcEstoque()
        {
            InitializeComponent();
            ConfigurarPainelFlutuante();
        }

        private void UcEstoque_Load(object sender, EventArgs e)
        {
            BuscarProdutosNoSupabase("");
        }

        /// <summary>
        /// Define as permissões de acesso com base no perfil.
        /// Se for vendedor/caixa, oculta os preços de custo, o painel de ferramentas e desativa a edição.
        /// </summary>
        public void ConfigurarPerfilVendedor(bool ehVendedor)
        {
            _podeVerOcultos = !ehVendedor;

            // Oculta o tableLayoutPanel2 (barra superior/ações de estoque) no formVenda
            if (panel2 != null)
            {
                panel2.Visible = !ehVendedor;
            }

            // Se existir botão de custo no próprio UserControl, ajusta a visibilidade
            if (this.Controls.ContainsKey("btnOculto"))
            {
                this.Controls["btnOculto"].Visible = _podeVerOcultos;
            }

            // Atualiza os cards que já se encontram carregados na tela
            foreach (Control controle in flowLayoutPanelProdutos.Controls)
            {
                if (controle is UcCardProduto card)
                {
                    AplicarPermissoesAoCard(card);
                }
            }
        }

        /// <summary>
        /// Aplica as travas de custo e cursor de edição a cada card individualmente.
        /// </summary>
        private void AplicarPermissoesAoCard(UcCardProduto card)
        {
            card.ConfigurarPermissoes(podeVerCusto: _podeVerOcultos, podeEditar: _podeVerOcultos);
        }

        /// <summary>
        /// Ação de pesquisa acionada pelo clique do botão
        /// </summary>
        private void searchBtn_Click(object sender, EventArgs e)
        {
            ExecutarPesquisa();
        }

        /// <summary>
        /// Ação de pesquisa acionada ao pressionar Enter na caixa de texto
        /// </summary>
        private void searchTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ExecutarPesquisa();
            }
        }

        private void ExecutarPesquisa()
        {
            string termo = searchTxtBox != null ? searchTxtBox.Text : "";
            BuscarProdutosNoSupabase(termo);
        }

        /// <summary>
        /// Ação do botão cadastrar produto
        /// </summary>
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            AbrirModalProduto();
        }

        /// <summary>
        /// Ativa o DoubleBuffered via reflexão para eliminar cintilações visuais no redimensionamento.
        /// </summary>
        private void ConfigurarPainelFlutuante()
        {
            if (flowLayoutPanelProdutos != null)
            {
                typeof(FlowLayoutPanel).InvokeMember("DoubleBuffered",
                    BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                    null, flowLayoutPanelProdutos, new object[] { true });

                flowLayoutPanelProdutos.AutoScroll = true;
                flowLayoutPanelProdutos.Resize += (s, ev) => CentralizarCards();
            }
        }

        /// <summary>
        /// Consulta a base de dados PostgreSQL/Supabase e preenche o FlowLayoutPanel com os cards.
        /// </summary>
        public void BuscarProdutosNoSupabase(string filtroTexto)
        {
            _filtroAtual = filtroTexto?.Trim() ?? "";
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
                        cmd.Parameters.AddWithValue("@filtro", _filtroAtual);
                        cmd.Parameters.AddWithValue("@filtro_like", $"%{_filtroAtual}%");

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
                                GerenciadorTema.AplicarTema(card);

                                // Ajusta visibilidade do custo e cursor
                                AplicarPermissoesAoCard(card);

                                // Clique de Edição (Apenas para Administrador / Estoquista)
                                card.AoClicarParaEditar += (produtoClicado) =>
                                {
                                    if (_podeVerOcultos)
                                    {
                                        AbrirModalProduto(produtoClicado);
                                    }
                                };

                                // Clique de Adicionar ao Carrinho (Repassado para a Venda)
                                card.AoAdicionarProduto += (prodId, preco, qtd) =>
                                {
                                    AoAdicionarAoCarrinho?.Invoke(prodId, preco, qtd);
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
                MessageBox.Show($"Erro ao consultar produtos: {ex.Message}", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Abre o UcCadastroProduto dentro de uma janela modal tanto para Inserção quanto para Edição.
        /// </summary>
        public void AbrirModalProduto(ProdutoDTO produto = null)
        {
            if (!_podeVerOcultos) return;

            using (var formModal = new Form())
            {
                var ucCadastro = new UcCadastroProduto();

                if (produto != null)
                {
                    ucCadastro.CarregarDadosParaEdicao(produto);
                    formModal.Text = $"Editar Produto - {produto.Nome}";
                }
                else
                {
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
                GerenciadorTema.AplicarTema(formModal);

                ucCadastro.AoConcluirOperacao += () =>
                {
                    formModal.DialogResult = DialogResult.OK;
                    formModal.Close();
                };

                if (formModal.ShowDialog(this) == DialogResult.OK)
                {
                    BuscarProdutosNoSupabase(_filtroAtual);
                }
            }
        }

        /// <summary>
        /// Distribui os cards uniformemente (space-between) respeitando o padding lateral do painel.
        /// </summary>
        private void CentralizarCards()
        {
            if (flowLayoutPanelProdutos == null || flowLayoutPanelProdutos.Controls.Count == 0)
                return;

            flowLayoutPanelProdutos.SuspendLayout();
            try
            {
                Control primeiroCard = flowLayoutPanelProdutos.Controls[0];
                int larguraCard = primeiroCard.Width;
                int margemPadrao = 15;
                int larguraDisponivel = flowLayoutPanelProdutos.ClientSize.Width - flowLayoutPanelProdutos.Padding.Horizontal - 2;
                int colunas = (larguraDisponivel + margemPadrao) / (larguraCard + margemPadrao);
                if (colunas < 1) colunas = 1;

                int totalCards = flowLayoutPanelProdutos.Controls.Count;

                if (totalCards == 1)
                {
                    primeiroCard.Margin = new Padding(0, primeiroCard.Margin.Top, 0, primeiroCard.Margin.Bottom);
                    return;
                }

                if (totalCards < colunas)
                {
                    for (int i = 0; i < totalCards; i++)
                    {
                        Control card = flowLayoutPanelProdutos.Controls[i];
                        int marginDir = (i == totalCards - 1) ? 0 : margemPadrao;
                        card.Margin = new Padding(0, card.Margin.Top, marginDir, card.Margin.Bottom);
                    }
                    return;
                }

                int sobra = larguraDisponivel - (colunas * larguraCard);
                int gap = (colunas > 1) ? (sobra / (colunas - 1)) : 0;

                for (int i = 0; i < totalCards; i++)
                {
                    Control card = flowLayoutPanelProdutos.Controls[i];
                    int colunaAtual = i % colunas;
                    bool ehUltimoDaLinha = (colunaAtual == colunas - 1);
                    int marginDir = ehUltimoDaLinha ? 0 : gap;

                    card.Margin = new Padding(0, card.Margin.Top, marginDir, card.Margin.Bottom);
                }
            }
            finally
            {
                flowLayoutPanelProdutos.ResumeLayout();
            }
        }
    }
}