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
            this.WindowState = FormWindowState.Maximized;
        }

        private void formVenda_Load(object sender, EventArgs e)
        {
            // Ativa DoubleBuffered para renderização suave dos cards sem cintilação
            if (flowLayoutPanelProdutos != null)
            {
                typeof(FlowLayoutPanel).InvokeMember("DoubleBuffered",
                    BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                    null, flowLayoutPanelProdutos, new object[] { true });

                flowLayoutPanelProdutos.Resize += (s, ev) => CentralizarCards();
            }

            // ATENÇÃO: Enquanto a tabela 'product' não for criada no Supabase,
            // chamamos o teste local abaixo para desenhar os cards na tela imediatamente:
            TestarCardsSemBanco();

            // Quando a tabela estiver criada e populada no Supabase, comente a linha acima e use:
            // BuscarProdutosNoSupabase("");
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
                SELECT id_product, name_product, description_product, price_sell, price_buy, picture_url 
                FROM product 
                WHERE active = TRUE 
                  AND (@filtro = '' OR name_product ILIKE @filtro_like OR description_product ILIKE @filtro_like)
                ORDER BY name_product ASC 
                LIMIT 40;";

            try
            {
                using (var db = new Connection())
                {
                    db.IniciarConexao();

                    using (var cmd = new NpgsqlCommand(query, db.Conexao))
                    {
                        cmd.Parameters.AddWithValue("@filtro", filtroTexto.Trim());
                        cmd.Parameters.AddWithValue("@filtro_like", $"%{filtroTexto.Trim()}%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            flowLayoutPanelProdutos.SuspendLayout();

                            while (reader.Read())
                            {
                                int id = reader.GetInt32(reader.GetOrdinal("id_product"));
                                string nome = reader.GetString(reader.GetOrdinal("name_product"));
                                string descricao = reader.IsDBNull(reader.GetOrdinal("description_product")) ? "" : reader.GetString(reader.GetOrdinal("description_product"));
                                decimal precoVenda = reader.IsDBNull(reader.GetOrdinal("price_sell")) ? 0m : reader.GetDecimal(reader.GetOrdinal("price_sell"));
                                decimal precoCompra = reader.IsDBNull(reader.GetOrdinal("price_buy")) ? 0m : reader.GetDecimal(reader.GetOrdinal("price_buy"));
                                string fotoUrl = reader.IsDBNull(reader.GetOrdinal("picture_url")) ? null : reader.GetString(reader.GetOrdinal("picture_url"));

                                var card = new UcCardProduto();
                                card.Margin = new Padding(8);
                                card.CarregarDados(id, nome, descricao, precoVenda, precoCompra, fotoUrl);

                                card.AoAdicionarProduto += (prodId, preco, qtd) =>
                                {
                                    AcaoSelecionarProduto(prodId, preco, qtd);
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

            // ClientSize já desconta a barra de rolagem se ela estiver visível
            int larguraDisponivel = flowLayoutPanelProdutos.ClientSize.Width;

            int colunas = larguraDisponivel / larguraTotalDoCard;
            if (colunas < 1)
                colunas = 1;

            // Se existirem menos cards no total do que o número de colunas da tela inteira, centraliza apenas o grupo existente
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

        /// <summary>
        /// Popula o painel com produtos mockados para testar interface sem depender do banco
        /// </summary>
        private void TestarCardsSemBanco()
        {
            flowLayoutPanelProdutos.Controls.Clear();
            flowLayoutPanelProdutos.SuspendLayout();

            var produtosTeste = new[]
            {
                new {
                    Id = 1,
                    Nome = "Óleo Motor 10W30",
                    Desc = "Lubrificante semissintético",
                    Venda = 38.50m,
                    Compra = 22.00m,
                    Foto = "https://images.unsplash.com/photo-1619642751034-765dfdf7c58e?w=200"
                },
                new {
                    Id = 2,
                    Nome = "Vela de Ignição Iridium",
                    Desc = "Partida rápida, queima limpa e durabilidade estendida",
                    Venda = 65.00m,
                    Compra = 40.00m,
                    Foto = "https://images.unsplash.com/photo-1486006920555-c77dce18193b?w=200"
                },
                new {
                    Id = 3,
                    Nome = "Pastilha de Freio Dianteira",
                    Desc = "Composto cerâmico de alto coeficiente de atrito",
                    Venda = 45.00m,
                    Compra = 25.00m,
                    Foto = (string)null
                },
                new {
                    Id = 4,
                    Nome = "Kit de Transmissão Coroa Pinhão e Corrente com Retentor Reforçado Aço 1045",
                    Desc = "Conjunto completo linha pesada",
                    Venda = 189.90m,
                    Compra = 120.00m,
                    Foto = (string)null
                },
                new {
                    Id = 5,
                    Nome = "Filtro de Ar Esportivo",
                    Desc = "Elemento filtrante de algodão cirúrgico multicamadas de alto fluxo lavável e reutilizável com vedação de poliuretano vulcanizado para evitar passagem de impurezas mesmo em estradas de terra severas",
                    Venda = 82.00m,
                    Compra = 50.00m,
                    Foto = (string)null
                },
                new {
                    Id = 6,
                    Nome = "Pneu Traseiro Sem Câmara 140/70-17 66H Radial Tubeless para Pista e Uso Urbano Misto",
                    Desc = "Borracha com duplo composto de sílica para máxima aderência em curvas com piso molhado e carcaça estruturada em lonas diagonais super resistentes a furos",
                    Venda = 420.00m,
                    Compra = 295.00m,
                    Foto = (string)null
                },
                new {
                    Id = 7,
                    Nome = "Módulo de Injeção Eletrônica ECU",
                    Desc = "Unidade central de controle e mapeamento",
                    Venda = 15890.50m,
                    Compra = 11200.00m,
                    Foto = (string)null
                },
                new {
                    Id = 8,
                    Nome = "Brinde / Adesivo Resinador",
                    Desc = "Item promocional",
                    Venda = 0.00m,
                    Compra = 0.00m,
                    Foto = (string)null
                },
                new {
                    Id = 9,
                    Nome = "SUPERHIPERMEGADESENGRAXANTEDEALTAPRECISAO",
                    Desc = "SemEspacosNoTextoParaValidarQuebraDePalavraLongaNoComponenteDeLabel",
                    Venda = 29.90m,
                    Compra = 15.00m,
                    Foto = (string)null
                },
                new {
                    Id = 10,
                    Nome = "Cabo de Embreagem",
                    Desc = "Aço flexível com capa lubrificada",
                    Venda = 22.00m,
                    Compra = 10.50m,
                    Foto = (string)null
                }
            };

            foreach (var item in produtosTeste)
            {
                var card = new UcCardProduto();
                card.Margin = new Padding(8);
                card.CarregarDados(item.Id, item.Nome, item.Desc, item.Venda, item.Compra, item.Foto);

                card.AoAdicionarProduto += (id, preco, qtd) =>
                {
                    AcaoSelecionarProduto(id, preco, qtd);
                };

                flowLayoutPanelProdutos.Controls.Add(card);
            }

            flowLayoutPanelProdutos.ResumeLayout();
            CentralizarCards();
        }
    }
}