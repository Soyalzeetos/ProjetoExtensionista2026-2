using Npgsql;
using ProjetoExtensionista2026_2.DTOs;
using ProjetoExtensionista2026_2.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoExtensionista2026_2
{
    public partial class formVenda : Form
    {
        private UcEstoque _ucEstoque;
        private long _descontoCentavos = 0;
        private int _descontoPorcentagem = 0;
        private bool _atualizandoDesconto = false;
        private decimal DescontoAtual => _descontoCentavos / 100m;

        private ClienteDTO _clienteSelecionado;
        private List<ClienteDTO> _clientesPesquisados = new List<ClienteDTO>();
        private CancellationTokenSource _ctsBuscaCliente;
        private bool _bloquearBuscaCliente = false;

        public long IdClienteSelecionado => _clienteSelecionado?.Id ?? 1;

        public formVenda()
        {
            InitializeComponent();

            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Maximized;
        }

        private void formVenda_Load(object sender, EventArgs e)
        {
            _ucEstoque = new UcEstoque
            {
                Dock = DockStyle.Fill
            };

            _ucEstoque.ConfigurarPerfilVendedor(true);
            _ucEstoque.AoAdicionarAoCarrinho += AcaoSelecionarProduto;

            panelConteudo.Controls.Clear();
            panelConteudo.Controls.Add(_ucEstoque);
            _ucEstoque.BringToFront();

            _ucEstoque.BuscarProdutosNoSupabase(string.Empty);

            if (panelCarrinho != null)
                panelCarrinho.AutoScroll = true;

            ConfigurarCamposDesconto();
            ConfigurarPesquisaCliente();
            DefinirClientePadrao();
            AtualizarTotaisCarrinho();
        }

        private void ConfigurarPesquisaCliente()
        {
            if (dgwPesquisa != null)
            {
                dgwPesquisa.Visible = false;
                dgwPesquisa.ReadOnly = true;
                dgwPesquisa.AllowUserToAddRows = false;
                dgwPesquisa.AllowUserToDeleteRows = false;
                dgwPesquisa.AllowUserToResizeRows = false;
                dgwPesquisa.RowHeadersVisible = false;
                dgwPesquisa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgwPesquisa.MultiSelect = false;
                dgwPesquisa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgwPesquisa.BringToFront();

                dgwPesquisa.CellClick += dgwPesquisa_CellClick;
                dgwPesquisa.KeyDown += dgwPesquisa_KeyDown;
                dgwPesquisa.Leave += ControlePesquisa_Leave;
            }

            if (txtBuscarCliente != null)
            {
                txtBuscarCliente.Click += (s, ev) => txtBuscarCliente.SelectAll();
                txtBuscarCliente.Enter += (s, ev) => txtBuscarCliente.SelectAll();
                txtBuscarCliente.TextChanged += txtBuscarCliente_TextChanged;
                txtBuscarCliente.KeyDown += txtBuscarCliente_KeyDown;
                txtBuscarCliente.Leave += ControlePesquisa_Leave;
            }
        }

        private void DefinirClientePadrao()
        {
            SelecionarCliente(new ClienteDTO
            {
                Id = 1,
                Nome = "CONSUMIDOR FINAL",
                Apelido = "BALCÃO",
                CpfCnpj = string.Empty,
                Telefone = string.Empty,
                LimiteCredito = 0m,
                Ativo = true
            });
        }

        private void SelecionarCliente(ClienteDTO cliente)
        {
            if (cliente == null) return;

            _clienteSelecionado = cliente;
            AtualizarExibicaoCliente();

            if (dgwPesquisa != null)
                dgwPesquisa.Visible = false;

            _bloquearBuscaCliente = true;
            try
            {
                if (txtBuscarCliente != null)
                {
                    txtBuscarCliente.Text = _clienteSelecionado.Nome;
                    txtBuscarCliente.SelectionStart = txtBuscarCliente.Text.Length;
                }
            }
            finally
            {
                _bloquearBuscaCliente = false;
            }
        }

        private void AtualizarExibicaoCliente()
        {
            if (_clienteSelecionado == null) return;

            if (lblDocumentoCliente != null)
                lblDocumentoCliente.Text = FormatarCpfCnpj(_clienteSelecionado.CpfCnpj);

            if (lblTelefoneCliente != null)
                lblTelefoneCliente.Text = FormatarTelefone(_clienteSelecionado.Telefone);

            if (lblEnderecoCliente != null)
                lblEnderecoCliente.Text = FormatarEndereco(_clienteSelecionado);

            if (lblStatusCliente != null)
                lblStatusCliente.Text = _clienteSelecionado.Ativo ? "Ativo" : "Inativo";

            if (lblLimiteCliente != null)
                lblLimiteCliente.Text = _clienteSelecionado.LimiteCredito.ToString("C2");
        }

        private async void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {
            if (_bloquearBuscaCliente) return;

            _ctsBuscaCliente?.Cancel();
            _ctsBuscaCliente?.Dispose();
            _ctsBuscaCliente = new CancellationTokenSource();
            var token = _ctsBuscaCliente.Token;

            string termo = txtBuscarCliente.Text.Trim();

            if (string.IsNullOrWhiteSpace(termo))
            {
                if (dgwPesquisa != null)
                    dgwPesquisa.Visible = false;
                return;
            }

            try
            {
                await Task.Delay(250, token);
                if (!token.IsCancellationRequested)
                {
                    await ExecutarBuscaClientesAsync(termo, token);
                }
            }
            catch (TaskCanceledException)
            {
                // Ignorado intencionalmente quando o usuário digita rápido
            }
        }

        private async Task ExecutarBuscaClientesAsync(string termo, CancellationToken token)
        {
            try
            {
                var resultados = await ObterClientesDoBancoAsync(termo, token);
                if (token.IsCancellationRequested || dgwPesquisa == null) return;

                _clientesPesquisados = resultados ?? new List<ClienteDTO>();

                if (_clientesPesquisados.Count > 0)
                {
                    dgwPesquisa.DataSource = _clientesPesquisados.Select(c => new
                    {
                        c.Id,
                        c.Nome,
                        Documento = FormatarCpfCnpj(c.CpfCnpj),
                        Telefone = FormatarTelefone(c.Telefone)
                    }).ToList();

                    ConfigurarColunaGrid("Id", "Cód.", 18);
                    ConfigurarColunaGrid("Nome", "Nome / Razão Social", 47);
                    ConfigurarColunaGrid("Documento", "CPF / CNPJ", 35);
                    ConfigurarColunaGrid("Telefone", "Telefone", 25);

                    dgwPesquisa.Visible = true;
                    dgwPesquisa.BringToFront();
                }
                else
                {
                    dgwPesquisa.Visible = false;
                }
            }
            catch
            {
                if (dgwPesquisa != null)
                    dgwPesquisa.Visible = false;
            }
        }

        private void ConfigurarColunaGrid(string nomeColuna, string titulo, float peso)
        {
            if (dgwPesquisa?.Columns[nomeColuna] is DataGridViewColumn col)
            {
                col.HeaderText = titulo;
                col.FillWeight = peso;
            }
        }

        private async Task<List<ClienteDTO>> ObterClientesDoBancoAsync(string termo, CancellationToken token)
        {
            var listaClientes = new List<ClienteDTO>();

            try
            {
                using (var conexaoDb = new Connection())
                {
                    conexaoDb.IniciarConexao();

                    const string sql = @"
                        SELECT 
                            id_customer, 
                            name, 
                            nickname, 
                            cpf_cnpj, 
                            rg_ie, 
                            phone, 
                            email, 
                            cep, 
                            street, 
                            number_address, 
                            neighborhood, 
                            complement, 
                            city, 
                            uf, 
                            credit_limit, 
                            is_active, 
                            notes
                        FROM public.customer
                        WHERE is_active = TRUE
                          AND (name ILIKE @termo OR cpf_cnpj ILIKE @termo OR nickname ILIKE @termo)
                        ORDER BY name ASC
                        LIMIT 10;";

                    using (var comando = new NpgsqlCommand(sql, conexaoDb.Conexao))
                    {
                        comando.Parameters.AddWithValue("@termo", $"%{termo}%");

                        using (var reader = await comando.ExecuteReaderAsync(token))
                        {
                            while (await reader.ReadAsync(token))
                            {
                                listaClientes.Add(new ClienteDTO
                                {
                                    Id = reader["id_customer"] != DBNull.Value ? Convert.ToInt64(reader["id_customer"]) : 1,
                                    Nome = reader["name"]?.ToString() ?? string.Empty,
                                    Apelido = reader["nickname"]?.ToString() ?? string.Empty,
                                    CpfCnpj = reader["cpf_cnpj"]?.ToString() ?? string.Empty,
                                    RgIe = reader["rg_ie"]?.ToString() ?? string.Empty,
                                    Telefone = reader["phone"]?.ToString() ?? string.Empty,
                                    Email = reader["email"]?.ToString() ?? string.Empty,
                                    Cep = reader["cep"]?.ToString() ?? string.Empty,
                                    Rua = reader["street"]?.ToString() ?? string.Empty,
                                    Numero = reader["number_address"]?.ToString() ?? string.Empty,
                                    Bairro = reader["neighborhood"]?.ToString() ?? string.Empty,
                                    Complemento = reader["complement"]?.ToString() ?? string.Empty,
                                    Cidade = reader["city"]?.ToString() ?? string.Empty,
                                    Uf = reader["uf"]?.ToString() ?? string.Empty,
                                    LimiteCredito = reader["credit_limit"] != DBNull.Value ? Convert.ToDecimal(reader["credit_limit"]) : 0m,
                                    Ativo = reader["is_active"] != DBNull.Value && Convert.ToBoolean(reader["is_active"]),
                                    Observacoes = reader["notes"]?.ToString() ?? string.Empty
                                });
                            }
                        }
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // Pesquisa cancelada por nova digitação
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao buscar clientes no banco: {ex.Message}",
                    "Erro de Conexão",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return listaClientes;
        }

        private void ConfirmarSelecaoCliente(int indiceLinha)
        {
            if (indiceLinha < 0 || indiceLinha >= _clientesPesquisados.Count) return;

            ClienteDTO clienteEscolhido = _clientesPesquisados[indiceLinha];
            SelecionarCliente(clienteEscolhido);
        }

        private void txtBuscarCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && dgwPesquisa != null && dgwPesquisa.Visible && dgwPesquisa.Rows.Count > 0)
            {
                e.Handled = true;
                dgwPesquisa.Focus();
                dgwPesquisa.Rows[0].Selected = true;
            }
            else if (e.KeyCode == Keys.Escape && dgwPesquisa != null)
            {
                dgwPesquisa.Visible = false;
            }
        }

        private void dgwPesquisa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                ConfirmarSelecaoCliente(e.RowIndex);
        }

        private void dgwPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                if (dgwPesquisa.CurrentRow != null && dgwPesquisa.CurrentRow.Index >= 0)
                    ConfirmarSelecaoCliente(dgwPesquisa.CurrentRow.Index);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                dgwPesquisa.Visible = false;
                txtBuscarCliente?.Focus();
            }
        }

        private void ControlePesquisa_Leave(object sender, EventArgs e)
        {
            BeginInvoke((Action)(() =>
            {
                if (dgwPesquisa != null && txtBuscarCliente != null && !dgwPesquisa.Focused && !txtBuscarCliente.Focused)
                {
                    dgwPesquisa.Visible = false;

                    // Se o operador apagou o campo de busca e saiu dele, volta para o Consumidor Final (ID 1)
                    if (string.IsNullOrWhiteSpace(txtBuscarCliente.Text))
                    {
                        DefinirClientePadrao();
                    }
                    else
                    {
                        // Garante que o texto reflita o cliente atualmente selecionado
                        _bloquearBuscaCliente = true;
                        txtBuscarCliente.Text = _clienteSelecionado?.Nome ?? "CONSUMIDOR FINAL";
                        _bloquearBuscaCliente = false;
                    }
                }
            }));
        }

        /// <summary>
        /// Formata no padrão: "Rua das Flores, 123, Apto 45, Centro, Frutal - MG, CEP: 38200-000"
        /// </summary>
        private static string FormatarEndereco(ClienteDTO c)
        {
            if (c == null) return "Não informado";

            var partes = new List<string>();

            if (!string.IsNullOrWhiteSpace(c.Rua))
                partes.Add(c.Rua.Trim());

            if (!string.IsNullOrWhiteSpace(c.Numero))
                partes.Add(c.Numero.Trim());

            if (!string.IsNullOrWhiteSpace(c.Complemento))
                partes.Add(c.Complemento.Trim());

            if (!string.IsNullOrWhiteSpace(c.Bairro))
                partes.Add(c.Bairro.Trim());

            string cidade = c.Cidade?.Trim();
            string uf = c.Uf?.Trim();

            if (!string.IsNullOrWhiteSpace(cidade) && !string.IsNullOrWhiteSpace(uf))
                partes.Add($"{cidade} - {uf}");
            else if (!string.IsNullOrWhiteSpace(cidade))
                partes.Add(cidade);
            else if (!string.IsNullOrWhiteSpace(uf))
                partes.Add(uf);

            if (!string.IsNullOrWhiteSpace(c.Cep))
                partes.Add($"CEP: {FormatarCep(c.Cep)}");

            return partes.Count > 0 ? string.Join(", ", partes) : "Não informado";
        }

        private static string FormatarCep(string cep)
        {
            string digitos = ExtrairDigitos(cep);
            return digitos.Length == 8
                ? $"{digitos.Substring(0, 5)}-{digitos.Substring(5, 3)}"
                : cep.Trim();
        }

        private static string FormatarCpfCnpj(string doc)
        {
            if (string.IsNullOrWhiteSpace(doc)) return "Não informado";

            string digitos = ExtrairDigitos(doc);
            if (digitos.Length == 11)
                return Convert.ToUInt64(digitos).ToString(@"000\.000\.000\-00");
            if (digitos.Length == 14)
                return Convert.ToUInt64(digitos).ToString(@"00\.000\.000\/0000\-00");

            return doc.Trim();
        }

        private static string FormatarTelefone(string fone)
        {
            if (string.IsNullOrWhiteSpace(fone)) return "Não informado";

            string digitos = ExtrairDigitos(fone);
            if (digitos.Length == 11)
                return Convert.ToUInt64(digitos).ToString(@"\(00\) 00000\-0000");
            if (digitos.Length == 10)
                return Convert.ToUInt64(digitos).ToString(@"\(00\) 0000\-0000");

            return fone.Trim();
        }

        private static string ExtrairDigitos(string texto)
        {
            return string.IsNullOrEmpty(texto) ? string.Empty : Regex.Replace(texto, @"\D", string.Empty);
        }

        private void AcaoSelecionarProduto(int idProduto, string nomeProduto, decimal precoVenda, int quantidade, string fotoUrl, int estoqueDisponivel)
        {
            AdicionarOuIncrementarCarrinho(idProduto, nomeProduto, precoVenda, quantidade, fotoUrl, estoqueDisponivel);
        }

        private void AdicionarOuIncrementarCarrinho(int idProduto, string nomeProduto, decimal precoVenda, int quantidade, string fotoUrl, int estoqueDisponivel)
        {
            if (panelCarrinho == null) return;

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

            var cardExistente = panelCarrinho.Controls
                .OfType<UcCardVenda>()
                .FirstOrDefault(c => c.ProdutoId == idProduto);

            if (cardExistente != null)
            {
                int limiteEstoque = cardExistente.EstoqueMaximo;
                int qtdAtual = cardExistente.Quantidade;

                if (qtdAtual >= limiteEstoque)
                {
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
                    int restantePermitido = limiteEstoque - qtdAtual;
                    MessageBox.Show(
                        $"Não é possível adicionar mais {quantidade} unidade(s). Você já tem {qtdAtual} no carrinho e restam apenas {restantePermitido} no estoque.",
                        "Estoque Insuficiente",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                cardExistente.CarregarItem(
                    idProduto,
                    cardExistente.NomeProduto,
                    precoVenda,
                    qtdAtual + quantidade,
                    limiteEstoque,
                    cardExistente.FotoOrigem ?? fotoUrl
                );

                AtualizarTotaisCarrinho();
                return;
            }

            if (quantidade > estoqueDisponivel)
            {
                MessageBox.Show(
                    $"Não é possível adicionar {quantidade} unidades de '{nomeProduto}'. O estoque atual possui apenas {estoqueDisponivel} unidade(s).",
                    "Estoque Insuficiente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            panelCarrinho.SuspendLayout();
            try
            {
                var novoItem = new UcCardVenda
                {
                    Dock = DockStyle.Top,
                    Margin = new Padding(0, 0, 0, 4)
                };

                novoItem.CarregarItem(idProduto, nomeProduto, precoVenda, quantidade, estoqueDisponivel, fotoUrl);
                novoItem.AoAlterarQuantidade += (id, novaQtd, novoTotalItem) => AtualizarTotaisCarrinho();
                novoItem.AoRemoverItem += (id, cardRemover) =>
                {
                    panelCarrinho.Controls.Remove(cardRemover);
                    cardRemover.Dispose();
                    AtualizarTotaisCarrinho();
                };

                panelCarrinho.Controls.Add(novoItem);
                novoItem.BringToFront();
            }
            finally
            {
                panelCarrinho.ResumeLayout();
            }

            AtualizarTotaisCarrinho();
        }

        private (decimal Subtotal, int TotalItens) CalcularMetricasCarrinho()
        {
            decimal subtotal = 0m;
            int totalItens = 0;

            if (panelCarrinho != null)
            {
                foreach (UcCardVenda item in panelCarrinho.Controls.OfType<UcCardVenda>())
                {
                    subtotal += item.PrecoTotal;
                    totalItens += item.Quantidade;
                }
            }

            return (subtotal, totalItens);
        }

        private decimal ObterSubtotalAtual() => CalcularMetricasCarrinho().Subtotal;

        private void AtualizarTotaisCarrinho()
        {
            var (subtotal, totalItens) = CalcularMetricasCarrinho();

            if (DescontoAtual > subtotal)
            {
                _descontoCentavos = (long)Math.Round(subtotal * 100m);
                SincronizarCamposDesconto(subtotal, originadoPorValor: true);
            }

            decimal totalFinal = Math.Max(0m, subtotal - DescontoAtual);

            if (lblSubtotal != null)
                lblSubtotal.Text = subtotal.ToString("C2");

            if (lblTotal != null)
                lblTotal.Text = totalFinal.ToString("C2");

            if (lblQtdItens != null)
                lblQtdItens.Text = $"{totalItens} item(ns)";
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

        private void txtDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (!char.IsDigit(e.KeyChar)) return;

            int digito = e.KeyChar - '0';
            long proximoCentavos = (_descontoCentavos * 10) + digito;
            decimal subtotal = ObterSubtotalAtual();
            long subtotalCentavos = (long)Math.Round(subtotal * 100m);

            _descontoCentavos = Math.Min(proximoCentavos, subtotalCentavos);
            SincronizarCamposDesconto(subtotal, originadoPorValor: true);
            AtualizarTotaisCarrinho();
        }

        private void txtDesconto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = true;
                _descontoCentavos /= 10;
            }
            else if (e.KeyCode == Keys.Delete)
            {
                e.SuppressKeyPress = true;
                _descontoCentavos = 0;
            }
            else return;

            SincronizarCamposDesconto(ObterSubtotalAtual(), originadoPorValor: true);
            AtualizarTotaisCarrinho();
        }

        private void txtDescontoPorcentagem_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (!char.IsDigit(e.KeyChar)) return;

            int digito = e.KeyChar - '0';
            _descontoPorcentagem = Math.Min(100, (_descontoPorcentagem * 10) + digito);

            SincronizarCamposDesconto(ObterSubtotalAtual(), originadoPorValor: false);
            AtualizarTotaisCarrinho();
        }

        private void txtDescontoPorcentagem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = true;
                _descontoPorcentagem /= 10;
            }
            else if (e.KeyCode == Keys.Delete)
            {
                e.SuppressKeyPress = true;
                _descontoPorcentagem = 0;
            }
            else return;

            SincronizarCamposDesconto(ObterSubtotalAtual(), originadoPorValor: false);
            AtualizarTotaisCarrinho();
        }

        private void SincronizarCamposDesconto(decimal subtotal, bool originadoPorValor)
        {
            if (_atualizandoDesconto) return;
            _atualizandoDesconto = true;

            try
            {
                if (originadoPorValor)
                {
                    if (DescontoAtual > subtotal)
                        _descontoCentavos = (long)Math.Round(subtotal * 100m);

                    int pctCalculada = subtotal > 0m ? (int)Math.Round((DescontoAtual / subtotal) * 100m) : 0;
                    _descontoPorcentagem = Math.Min(100, Math.Max(0, pctCalculada));
                }
                else
                {
                    _descontoPorcentagem = Math.Min(100, Math.Max(0, _descontoPorcentagem));
                    decimal valorCalculado = Math.Min(subtotal, Math.Round(subtotal * (_descontoPorcentagem / 100m), 2));
                    _descontoCentavos = (long)Math.Round(valorCalculado * 100m);
                }

                if (txtDesconto != null)
                {
                    txtDesconto.Text = $"- R$ {DescontoAtual:N2}";
                    txtDesconto.SelectionStart = txtDesconto.Text.Length;
                }

                if (txtDescontoPorcentagem != null)
                {
                    txtDescontoPorcentagem.Text = $"{_descontoPorcentagem} %";
                    txtDescontoPorcentagem.SelectionStart = txtDescontoPorcentagem.Text.Length;
                }
            }
            finally
            {
                _atualizandoDesconto = false;
            }
        }

        private void splitContainer_menu_SplitterMoved(object sender, SplitterEventArgs e)
        {
            LimitarSplitter(splitContainer_menu, 0.18, 0.25);
        }

        private void splitContainer_catalogo_SplitterMoved(object sender, SplitterEventArgs e)
        {
            LimitarSplitter(splitContainer_catalogo, 0.60, 0.70);
        }

        private static void LimitarSplitter(SplitContainer split, double percMin, double percMax)
        {
            if (split == null || split.Width <= 0) return;

            int min = (int)(split.Width * percMin);
            int max = (int)(split.Width * percMax);

            if (split.SplitterDistance < min)
                split.SplitterDistance = min;
            else if (split.SplitterDistance > max)
                split.SplitterDistance = max;
        }

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
                try
                {
                    while (panelCarrinho.Controls.Count > 0)
                    {
                        Control c = panelCarrinho.Controls[0];
                        panelCarrinho.Controls.Remove(c);
                        c.Dispose();
                    }
                }
                finally
                {
                    panelCarrinho.ResumeLayout();
                }

                _descontoCentavos = 0;
                _descontoPorcentagem = 0;
                SincronizarCamposDesconto(0m, originadoPorValor: true);
                AtualizarTotaisCarrinho();
            }
        }
    }
}