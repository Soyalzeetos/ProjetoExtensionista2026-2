using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using ProjetoExtensionista2026_2.SQL;

namespace ProjetoExtensionista2026_2
{
    public partial class UcCadastroProduto : UserControl
    {
        private static readonly HttpClient _httpClient = CriarHttpClient();
        private static readonly ConcurrentDictionary<string, byte[]> _imageBytesCache = new ConcurrentDictionary<string, byte[]>();

        private ProdutoDTO _produtoRef; 
        public int? ProdutoIdEmEdicao { get; private set; }
        public event Action AoConcluirOperacao;

        public UcCadastroProduto()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            ConfigurarControlesIniciais();
        }

        private static HttpClient CriarHttpClient()
        {
            var client = new HttpClient { Timeout = TimeSpan.FromSeconds(8) };
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");
            return client;
        }

        /// <summary>
        /// Configura Unidade (UNID/JG), Categoria, TextBoxes e RadioButtons de Status
        /// </summary>
        private void ConfigurarControlesIniciais()
        {
            txtCodigo.ReadOnly = true;
            txtCodigo.TabStop = false;
            txtMargem.ReadOnly = true;
            txtMargem.TabStop = false;

            // 1. Configuração da Unidade (UNID ou JG)
            cboUnidade.DropDownStyle = ComboBoxStyle.DropDownList;
            if (cboUnidade.Items.Count == 0)
            {
                cboUnidade.Items.AddRange(new object[] { "UNID", "JG" });
            }
            cboUnidade.SelectedIndex = 0; // Padrão: UNID

            // 2. Configuração da Categoria (ComboBox)
            cboCategoria.DropDownStyle = ComboBoxStyle.DropDown;
            if (cboCategoria.Items.Count == 0)
            {
                cboCategoria.Items.AddRange(new object[]
                {
                    "Motor",
                    "Freios",
                    "Suspensão",
                    "Elétrica / Ignição",
                    "Transmissão",
                    "Lubrificantes e Fluidos",
                    "Filtros",
                    "Pneus e Rodas",
                    "Acessórios",
                    "Outros"
                });
            }

            // 3. Status inicial via RadioButtons
            DefinirStatusProduto(true);

            // Eventos para cálculo instantâneo da margem
            numPrecoCompra.ValueChanged += (s, e) => CalcularMargem();
            numPrecoVenda.ValueChanged += (s, e) => CalcularMargem();
        }

        /// <summary>
        /// Define e lê o status Ativo / Inativo através dos RadioButtons
        /// </summary>
        public void DefinirStatusProduto(bool ativo)
        {
            rbAtivo.Checked = ativo;
            rbInativo.Checked = !ativo;
        }

        public bool ObterStatusProduto()
        {
            return rbAtivo.Checked;
        }

        /// <summary>
        /// Consulta o próximo código em background sem nunca travar a abertura da tela
        /// </summary>
        public async Task GerarProximoCodigoAsync()
        {
            try
            {
                string codigoGerado = await Task.Run(async () =>
                {
                    using (var db = new Connection())
                    {
                        db.IniciarConexao();
                        const string query = "SELECT COALESCE(MAX(id_product), 0) + 1 FROM product;";
                        using (var cmd = new NpgsqlCommand(query, db.Conexao))
                        {
                            object resultado = await cmd.ExecuteScalarAsync();
                            return (resultado != null && int.TryParse(resultado.ToString(), out int prox))
                                ? prox.ToString()
                                : "1";
                        }
                    }
                });

                if (!this.IsDisposed && !ProdutoIdEmEdicao.HasValue)
                {
                    txtCodigo.Text = codigoGerado;
                }
            }
            catch
            {
                if (!this.IsDisposed && !ProdutoIdEmEdicao.HasValue)
                {
                    txtCodigo.Text = "1";
                }
            }
        }

        /// <summary>
        /// Preenche todos os campos instantaneamente ao clicar no Card
        /// </summary>
        public void CarregarDadosParaEdicao(ProdutoDTO p)
        {
            if (p == null) return;

            this.SuspendLayout();

            _produtoRef = p;
            ProdutoIdEmEdicao = p.Id;

            // Código e TextBoxes (Nome, Descrição, Localização, Fornecedor)
            txtCodigo.Text = !string.IsNullOrWhiteSpace(p.Codigo) ? p.Codigo : p.Id.ToString();
            txtNome.Text = p.Nome ?? string.Empty;
            txtDescricao.Text = p.Descricao ?? string.Empty;
            txtLocalizacao.Text = p.Localizacao ?? string.Empty;
            txtFornecedor.Text = p.Fornecedor ?? string.Empty;

            numPrecoCompra.Value = Math.Max(numPrecoCompra.Minimum, Math.Min(numPrecoCompra.Maximum, p.PrecoCompra));
            numPrecoVenda.Value = Math.Max(numPrecoVenda.Minimum, Math.Min(numPrecoVenda.Maximum, p.PrecoVenda));
            numEstoque.Value = Math.Max(numEstoque.Minimum, Math.Min(numEstoque.Maximum, (decimal)p.Estoque));
            numEstoqueMinimo.Value = Math.Max(numEstoqueMinimo.Minimum, Math.Min(numEstoqueMinimo.Maximum, (decimal)p.EstoqueMinimo));

            // Unidade (UNID ou JG)
            string unidade = string.IsNullOrWhiteSpace(p.Unidade) ? "UNID" : p.Unidade.Trim().ToUpper();
            if (unidade == "UN") unidade = "UNID"; // Compatibilidade caso venha "UN" dos dados de teste
            if (!cboUnidade.Items.Contains(unidade))
            {
                cboUnidade.Items.Add(unidade);
            }
            cboUnidade.SelectedItem = unidade;

            // Categoria (ComboBox)
            if (!string.IsNullOrWhiteSpace(p.Categoria))
            {
                if (!cboCategoria.Items.Contains(p.Categoria))
                {
                    cboCategoria.Items.Add(p.Categoria);
                }
                cboCategoria.SelectedItem = p.Categoria;
            }
            else
            {
                cboCategoria.SelectedIndex = -1;
                cboCategoria.Text = string.Empty;
            }

            // Status (RadioButtons Ativo / Inativo)
            DefinirStatusProduto(p.Ativo);

            // Margem e Imagem
            CalcularMargem();
            txtFotoUrl.Text = p.FotoUrl ?? string.Empty;
            btnSalvar.Text = "Atualizar";

            DefinirImagemPreview(Properties.Resources.produto_ausente);

            this.ResumeLayout();

            if (!string.IsNullOrWhiteSpace(p.FotoUrl))
            {
                _ = CarregarImagemPorUrlAsync(p.FotoUrl, exibirErros: false);
            }
        }

        public async void LimparCampos()
        {
            await LimparCamposAsync();
        }

        public async Task LimparCamposAsync()
        {
            this.SuspendLayout();

            _produtoRef = null;
            ProdutoIdEmEdicao = null;

            txtCodigo.Text = "...";
            txtNome.Clear();
            txtDescricao.Clear();
            txtLocalizacao.Clear();
            txtFornecedor.Clear();

            numPrecoCompra.Value = 0;
            numPrecoVenda.Value = 0;
            numEstoque.Value = 0;
            numEstoqueMinimo.Value = 0;

            cboUnidade.SelectedItem = "UNID";
            cboCategoria.SelectedIndex = -1;
            cboCategoria.Text = string.Empty;

            DefinirStatusProduto(true);

            txtFotoUrl.Clear();
            DefinirImagemPreview(Properties.Resources.produto_ausente);

            txtMargem.Text = "0,00%";
            btnSalvar.Text = "Salvar";

            this.ResumeLayout();
            txtNome.Focus();

            await GerarProximoCodigoAsync();
        }

        private void CalcularMargem()
        {
            decimal compra = numPrecoCompra.Value;
            decimal venda = numPrecoVenda.Value;

            if (compra > 0)
            {
                decimal margem = ((venda - compra) / compra) * 100m;
                txtMargem.Text = $"{margem:F2}%";
            }
            else
            {
                txtMargem.Text = "0,00%";
            }
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("O nome do produto é obrigatório.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(cboUnidade.Text))
            {
                MessageBox.Show("Selecione a unidade de medida (UNID ou JG).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboUnidade.Focus();
                return;
            }

            btnSalvar.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;

            // Captura os valores dos controles na thread de interface
            string codigo = txtCodigo.Text.Trim();
            string nome = txtNome.Text.Trim();
            string descricao = txtDescricao.Text.Trim();
            decimal precoCompra = numPrecoCompra.Value;
            decimal precoVenda = numPrecoVenda.Value;
            string localizacao = txtLocalizacao.Text.Trim();
            int estoque = (int)numEstoque.Value;
            int estoqueMin = (int)numEstoqueMinimo.Value;
            string unidade = cboUnidade.Text.Trim();
            string categoria = cboCategoria.Text.Trim();
            string fornecedor = txtFornecedor.Text.Trim();
            bool statusAtivo = ObterStatusProduto();
            string fotoUrl = txtFotoUrl.Text.Trim();

            // Atualiza também a referência em memória (útil para ver a edição funcionando mesmo sem banco)
            if (_produtoRef != null)
            {
                _produtoRef.Codigo = codigo;
                _produtoRef.Nome = nome;
                _produtoRef.Descricao = descricao;
                _produtoRef.PrecoCompra = precoCompra;
                _produtoRef.PrecoVenda = precoVenda;
                _produtoRef.Localizacao = localizacao;
                _produtoRef.Estoque = estoque;
                _produtoRef.EstoqueMinimo = estoqueMin;
                _produtoRef.Unidade = unidade;
                _produtoRef.Categoria = categoria;
                _produtoRef.Fornecedor = fornecedor;
                _produtoRef.Ativo = statusAtivo;
                _produtoRef.FotoUrl = string.IsNullOrWhiteSpace(fotoUrl) ? null : fotoUrl;
            }

            try
            {
                await Task.Run(async () =>
                {
                    using (var db = new Connection())
                    {
                        db.IniciarConexao();

                        if (!ProdutoIdEmEdicao.HasValue && (string.IsNullOrEmpty(codigo) || codigo == "..."))
                        {
                            const string sqlMax = "SELECT COALESCE(MAX(id_product), 0) + 1 FROM product;";
                            using (var cmdMax = new NpgsqlCommand(sqlMax, db.Conexao))
                            {
                                object res = await cmdMax.ExecuteScalarAsync();
                                codigo = res?.ToString() ?? "1";
                            }
                        }

                        string query = ProdutoIdEmEdicao.HasValue
                            ? @"UPDATE product SET
                                    code_product = @codigo,
                                    name_product = @nome,
                                    description_product = @descricao,
                                    price_buy = @preco_compra,
                                    price_sell = @preco_venda,
                                    location_product = @localizacao,
                                    stock_quantity = @estoque,
                                    min_stock_quantity = @estoque_min,
                                    unit_measure = @unidade,
                                    category_product = @categoria,
                                    supplier_product = @fornecedor,
                                    active = @ativo,
                                    picture_url = @foto_url
                                WHERE id_product = @id;"
                            : @"INSERT INTO product (
                                    code_product, name_product, description_product, price_buy, price_sell,
                                    location_product, stock_quantity, min_stock_quantity, unit_measure,
                                    category_product, supplier_product, active, picture_url
                                ) VALUES (
                                    @codigo, @nome, @descricao, @preco_compra, @preco_venda,
                                    @localizacao, @estoque, @estoque_min, @unidade,
                                    @categoria, @fornecedor, @ativo, @foto_url
                                );";

                        using (var cmd = new NpgsqlCommand(query, db.Conexao))
                        {
                            if (ProdutoIdEmEdicao.HasValue)
                                cmd.Parameters.AddWithValue("@id", ProdutoIdEmEdicao.Value);

                            cmd.Parameters.AddWithValue("@codigo", codigo);
                            cmd.Parameters.AddWithValue("@nome", nome);
                            cmd.Parameters.AddWithValue("@descricao", descricao);
                            cmd.Parameters.AddWithValue("@preco_compra", precoCompra);
                            cmd.Parameters.AddWithValue("@preco_venda", precoVenda);
                            cmd.Parameters.AddWithValue("@localizacao", localizacao);
                            cmd.Parameters.AddWithValue("@estoque", estoque);
                            cmd.Parameters.AddWithValue("@estoque_min", estoqueMin);
                            cmd.Parameters.AddWithValue("@unidade", unidade);
                            cmd.Parameters.AddWithValue("@categoria", categoria);
                            cmd.Parameters.AddWithValue("@fornecedor", fornecedor);
                            cmd.Parameters.AddWithValue("@ativo", statusAtivo);
                            cmd.Parameters.AddWithValue("@foto_url", string.IsNullOrWhiteSpace(fotoUrl) ? (object)DBNull.Value : fotoUrl);

                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                });

                string msg = ProdutoIdEmEdicao.HasValue
                    ? "Produto atualizado com sucesso!"
                    : "Produto cadastrado com sucesso!";

                MessageBox.Show(msg, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (!ProdutoIdEmEdicao.HasValue)
                {
                    await LimparCamposAsync();
                }

                AoConcluirOperacao?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar no banco de dados:\n{ex.Message}", "Erro de Operação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!this.IsDisposed)
                {
                    btnSalvar.Enabled = true;
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private async void btnLimpar_Click(object sender, EventArgs e)
        {
            await LimparCamposAsync();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            AoConcluirOperacao?.Invoke();
        }

        private void btnExcluirFoto_Click(object sender, EventArgs e)
        {
            DefinirImagemPreview(Properties.Resources.produto_ausente);
            txtFotoUrl.Clear();
        }

        private void btnEscolherArquivo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Selecione a imagem do produto";
                ofd.Filter = "Imagens (*.jpg;*.jpeg;*.png;*.webp)|*.jpg;*.jpeg;*.png;*.webp|Todos os arquivos (*.*)|*.*";
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        byte[] bytes = File.ReadAllBytes(ofd.FileName);
                        using (var ms = new MemoryStream(bytes))
                        using (var tempImg = Image.FromStream(ms))
                        {
                            DefinirImagemPreview(new Bitmap(tempImg));
                        }
                        txtFotoUrl.Text = ofd.FileName;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao carregar a imagem selecionada: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void btnCarregarFoto_Click(object sender, EventArgs e)
        {
            await CarregarImagemPorUrlAsync(txtFotoUrl.Text.Trim(), exibirErros: true);
        }

        private async void txtFotoUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                await CarregarImagemPorUrlAsync(txtFotoUrl.Text.Trim(), exibirErros: true);
            }
        }

        private async Task CarregarImagemPorUrlAsync(string url, bool exibirErros = true)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                if (exibirErros)
                {
                    MessageBox.Show("Por favor, informe a URL da imagem.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFotoUrl.Focus();
                }
                return;
            }

            try
            {
                byte[] dadosImagem = null;

                // 1. Verifica se já está no cache em memória
                if (!_imageBytesCache.TryGetValue(url, out dadosImagem))
                {
                    if (File.Exists(url))
                    {
                        dadosImagem = await Task.Run(() => File.ReadAllBytes(url));
                    }
                    else if (Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult) &&
                            (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
                    {
                        dadosImagem = await _httpClient.GetByteArrayAsync(uriResult);
                    }
                    else
                    {
                        if (exibirErros)
                            MessageBox.Show("Informe uma URL válida iniciada por http:// ou https://", "URL Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (dadosImagem != null && dadosImagem.Length > 0)
                    {
                        _imageBytesCache.TryAdd(url, dadosImagem);
                    }
                }

                if (dadosImagem != null && !this.IsDisposed)
                {
                    using (var ms = new MemoryStream(dadosImagem))
                    using (var imgOriginal = Image.FromStream(ms))
                    {
                        DefinirImagemPreview(new Bitmap(imgOriginal));
                    }
                }
            }
            catch (Exception ex)
            {
                if (!this.IsDisposed)
                {
                    DefinirImagemPreview(Properties.Resources.produto_ausente);
                    if (exibirErros)
                    {
                        MessageBox.Show($"Não foi possível carregar a imagem do link informado.\n\nDetalhes: {ex.Message}",
                                        "Falha ao Carregar Imagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DefinirImagemPreview(Image novaImagem)
        {
            if (picFotoPreview.Image != null && !ReferenceEquals(picFotoPreview.Image, Properties.Resources.produto_ausente))
            {
                picFotoPreview.Image.Dispose();
            }
            picFotoPreview.SizeMode = PictureBoxSizeMode.Zoom;
            picFotoPreview.Image = novaImagem;
        }
    }
}