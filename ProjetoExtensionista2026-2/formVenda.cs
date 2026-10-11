using Npgsql; // Necessário para a conexão com o Supabase (PostgreSQL)
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace ProjetoExtensionista2026_2
{
    public partial class formVenda : Form
    {
        private readonly string stringConexao = Environment.GetEnvironmentVariable("SUPABASE_CONNECTION");

        public formVenda()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void formVenda_Load(object sender, EventArgs e)
        {
            if (flowLayoutPanelProdutos != null)
            {
                typeof(FlowLayoutPanel).InvokeMember("DoubleBuffered",
                    BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                    null, flowLayoutPanelProdutos, new object[] { true });
            }

            // 2. Carrega os produtos iniciais ao abrir a tela de vendas
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
        /// Realiza a busca no Supabase e preenche o FlowLayoutPanel com os cards
        /// </summary>
        private void BuscarProdutosNoSupabase(string filtroTexto)
        {
            // Validação de segurança caso a string de conexão não tenha sido carregada do .env
            if (string.IsNullOrWhiteSpace(stringConexao))
            {
                MessageBox.Show("String de conexão com o Supabase não encontrada nas variáveis de ambiente (.env).",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Limpa os cards da pesquisa anterior
            flowLayoutPanelProdutos.Controls.Clear();

            string query = @"
                SELECT id, nome, descricao, preco_venda, preco_compra, foto_url 
                FROM produtos 
                WHERE (@filtro = '' OR nome ILIKE @filtro_like OR descricao ILIKE @filtro_like)
                ORDER BY nome ASC 
                LIMIT 40;";

            try
            {
                using (var conn = new NpgsqlConnection(stringConexao))
                {
                    conn.Open();

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@filtro", filtroTexto.Trim());
                        cmd.Parameters.AddWithValue("@filtro_like", $"%{filtroTexto.Trim()}%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            flowLayoutPanelProdutos.SuspendLayout();

                            while (reader.Read())
                            {
                                int id = reader.GetInt32(reader.GetOrdinal("id"));
                                string nome = reader.GetString(reader.GetOrdinal("nome"));
                                string descricao = reader.IsDBNull(reader.GetOrdinal("descricao")) ? "" : reader.GetString(reader.GetOrdinal("descricao"));
                                decimal precoVenda = reader.IsDBNull(reader.GetOrdinal("preco_venda")) ? 0m : reader.GetDecimal(reader.GetOrdinal("preco_venda"));
                                decimal precoCompra = reader.IsDBNull(reader.GetOrdinal("preco_compra")) ? 0m : reader.GetDecimal(reader.GetOrdinal("preco_compra"));
                                string fotoUrl = reader.IsDBNull(reader.GetOrdinal("foto_url")) ? null : reader.GetString(reader.GetOrdinal("foto_url"));

                                // Instanciação do card customizado
                                var card = new UcCardProduto();
                                card.CarregarDados(id, nome, descricao, precoVenda, precoCompra, fotoUrl);
                                card.Margin = new Padding(8); // Espaçamento entre os cartões

                                // Evento disparado ao clicar no produto
                                card.Click += (s, ev) =>
                                {
                                    AcaoSelecionarProduto(card.ProdutoId, card.PrecoVenda);
                                };

                                flowLayoutPanelProdutos.Controls.Add(card);
                            }

                            // Retoma o desenho do painel com os novos cards inseridos
                            flowLayoutPanelProdutos.ResumeLayout();
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
        private void AcaoSelecionarProduto(int idProduto, decimal precoVenda)
        {
            int quantidade = (int)numericUpDown1.Value;
            MessageBox.Show($"Produto selecionado: ID {idProduto}\nQuantidade: {quantidade}\nValor Unitário: {precoVenda:C2}",
                            "Item Selecionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public class ProdutoMock
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Descricao { get; set; }
            public decimal PrecoVenda { get; set; }
            public decimal PrecoCompra { get; set; }
            public string FotoUrl { get; set; }
        }
    }
}