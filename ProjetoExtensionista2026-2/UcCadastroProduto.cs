using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using ProjetoExtensionista2026_2.SQL; // Ajuste se o namespace da sua classe Connection for diferente

namespace ProjetoExtensionista2026_2
{
    public partial class UcCadastroProduto : UserControl
    {
        public int? ProdutoIdEmEdicao { get; private set; }
        public event Action AoConcluirOperacao;

        public UcCadastroProduto()
        {
            InitializeComponent();

            txtCodigo.ReadOnly = true;
            txtCodigo.TabStop = false;

            numPrecoCompra.ValueChanged += (s, e) => CalcularMargem();
            numPrecoVenda.ValueChanged += (s, e) => CalcularMargem();

            if (!this.DesignMode)
            {
                _ = LimparCamposAsync(); // Inicialização limpa e assíncrona sem travar a interface
            }
        }

        /// <summary>
        /// Consulta assíncrona para buscar o próximo código sem congelar a tela
        /// </summary>
        private async Task GerarProximoCodigoAsync()
        {
            try
            {
                using (var db = new Connection())
                {
                    db.IniciarConexao();
                    string query = "SELECT COALESCE(MAX(id_product), 0) + 1 FROM product;";

                    using (var cmd = new NpgsqlCommand(query, db.Conexao))
                    {
                        object resultado = await cmd.ExecuteScalarAsync();
                        if (resultado != null && int.TryParse(resultado.ToString(), out int proximoId))
                        {
                            txtCodigo.Text = proximoId.ToString();
                        }
                        else
                        {
                            txtCodigo.Text = "1";
                        }
                    }
                }
            }
            catch
            {
                txtCodigo.Text = "1";
            }
        }

        public async void CarregarDadosParaEdicao(ProdutoDTO p)
        {
            if (p == null) return;

            ProdutoIdEmEdicao = p.Id;

            txtCodigo.Text = !string.IsNullOrWhiteSpace(p.Codigo) ? p.Codigo : p.Id.ToString();
            txtNome.Text = p.Nome;
            txtDescricao.Text = p.Descricao;
            txtLocalizacao.Text = p.Localizacao;
            txtFornecedor.Text = p.Fornecedor;

            numPrecoCompra.Value = p.PrecoCompra;
            numPrecoVenda.Value = p.PrecoVenda;
            numEstoque.Value = p.Estoque;
            numEstoqueMinimo.Value = p.EstoqueMinimo;

            if (!string.IsNullOrEmpty(p.Unidade))
                cboUnidade.Text = p.Unidade;

            if (!string.IsNullOrEmpty(p.Categoria))
                cboCategoria.Text = p.Categoria;

            rbAtivo.Checked = p.Ativo;
            rbInativo.Checked = !p.Ativo;

            txtFotoUrl.Text = p.FotoUrl;
            CalcularMargem();

            if (!string.IsNullOrWhiteSpace(p.FotoUrl))
            {
                await CarregarImagemPorUrlAsync(p.FotoUrl);
            }
            else
            {
                picFotoPreview.Image?.Dispose();
                picFotoPreview.Image = Properties.Resources.produto_ausente;
            }

            btnSalvar.Text = "Atualizar";
        }

        public async void LimparCampos()
        {
            await LimparCamposAsync();
        }

        private async Task LimparCamposAsync()
        {
            ProdutoIdEmEdicao = null;

            await GerarProximoCodigoAsync();

            txtNome.Clear();
            txtDescricao.Clear();
            txtLocalizacao.Clear();
            txtFornecedor.Clear();

            numPrecoCompra.Value = 0;
            numPrecoVenda.Value = 0;
            numEstoque.Value = 0;
            numEstoqueMinimo.Value = 0;

            cboUnidade.SelectedIndex = -1;
            cboCategoria.SelectedIndex = -1;

            rbAtivo.Checked = true;
            rbInativo.Checked = false;

            txtFotoUrl.Clear();
            picFotoPreview.Image?.Dispose();
            picFotoPreview.Image = Properties.Resources.produto_ausente;

            txtMargem.Text = "0,00%";
            btnSalvar.Text = "Salvar";

            txtNome.Focus();
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

            try
            {
                using (var db = new Connection())
                {
                    db.IniciarConexao();

                    if (!ProdutoIdEmEdicao.HasValue)
                    {
                        await GerarProximoCodigoAsync();
                    }

                    string query;
                    if (ProdutoIdEmEdicao.HasValue)
                    {
                        query = @"
                            UPDATE product SET
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
                            WHERE id_product = @id;";
                    }
                    else
                    {
                        query = @"
                            INSERT INTO product (
                                code_product, name_product, description_product, price_buy, price_sell,
                                location_product, stock_quantity, min_stock_quantity, unit_measure,
                                category_product, supplier_product, active, picture_url
                            ) VALUES (
                                @codigo, @nome, @descricao, @preco_compra, @preco_venda,
                                @localizacao, @estoque, @estoque_min, @unidade,
                                @categoria, @fornecedor, @ativo, @foto_url
                            );";
                    }

                    using (var cmd = new NpgsqlCommand(query, db.Conexao))
                    {
                        if (ProdutoIdEmEdicao.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@id", ProdutoIdEmEdicao.Value);
                        }

                        cmd.Parameters.AddWithValue("@codigo", txtCodigo.Text.Trim());
                        cmd.Parameters.AddWithValue("@nome", txtNome.Text.Trim());
                        cmd.Parameters.AddWithValue("@descricao", txtDescricao.Text.Trim());
                        cmd.Parameters.AddWithValue("@preco_compra", numPrecoCompra.Value);
                        cmd.Parameters.AddWithValue("@preco_venda", numPrecoVenda.Value);
                        cmd.Parameters.AddWithValue("@localizacao", txtLocalizacao.Text.Trim());
                        cmd.Parameters.AddWithValue("@estoque", (int)numEstoque.Value);
                        cmd.Parameters.AddWithValue("@estoque_min", (int)numEstoqueMinimo.Value);
                        cmd.Parameters.AddWithValue("@unidade", cboUnidade.Text);
                        cmd.Parameters.AddWithValue("@categoria", cboCategoria.Text);
                        cmd.Parameters.AddWithValue("@fornecedor", txtFornecedor.Text.Trim());
                        cmd.Parameters.AddWithValue("@ativo", rbAtivo.Checked);

                        object valorFoto = string.IsNullOrWhiteSpace(txtFotoUrl.Text)
                            ? (object)DBNull.Value
                            : txtFotoUrl.Text.Trim();
                        cmd.Parameters.AddWithValue("@foto_url", valorFoto);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }

                string mensagem = ProdutoIdEmEdicao.HasValue
                    ? "Produto atualizado com sucesso!"
                    : "Produto cadastrado com sucesso!";

                MessageBox.Show(mensagem, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            AoConcluirOperacao?.Invoke();
        }

        private void btnExcluirFoto_Click(object sender, EventArgs e)
        {
            picFotoPreview.Image?.Dispose();
            picFotoPreview.Image = Properties.Resources.produto_ausente;
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
                        using (var stream = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                        {
                            picFotoPreview.Image?.Dispose();
                            picFotoPreview.Image = Image.FromStream(stream);
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
            await CarregarImagemPorUrlAsync(txtFotoUrl.Text.Trim());
        }

        private async void txtFotoUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                await CarregarImagemPorUrlAsync(txtFotoUrl.Text.Trim());
            }
        }

        private async Task CarregarImagemPorUrlAsync(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("Por favor, informe a URL da imagem.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFotoUrl.Focus();
                return;
            }

            if (File.Exists(url))
            {
                try
                {
                    using (var stream = new FileStream(url, FileMode.Open, FileAccess.Read))
                    {
                        picFotoPreview.Image?.Dispose();
                        picFotoPreview.Image = Image.FromStream(stream);
                    }
                    return;
                }
                catch
                {
                    picFotoPreview.Image?.Dispose();
                    picFotoPreview.Image = Properties.Resources.produto_ausente;
                    return;
                }
            }

            if (!Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult) ||
                (uriResult.Scheme != Uri.UriSchemeHttp && uriResult.Scheme != Uri.UriSchemeHttps))
            {
                MessageBox.Show("Informe uma URL válida iniciada por http:// ou https://", "URL Inválida",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                using (var clienteWeb = new System.Net.WebClient())
                {
                    clienteWeb.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");
                    byte[] dadosImagem = await clienteWeb.DownloadDataTaskAsync(uriResult);

                    using (var ms = new MemoryStream(dadosImagem))
                    {
                        using (var imgOriginal = Image.FromStream(ms))
                        {
                            picFotoPreview.Image?.Dispose();
                            picFotoPreview.Image = new Bitmap(imgOriginal);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível carregar a imagem do link informado.\n\nDetalhes: {ex.Message}",
                                "Falha ao Carregar Imagem", MessageBoxButtons.OK, MessageBoxIcon.Error);

                picFotoPreview.Image?.Dispose();
                picFotoPreview.Image = Properties.Resources.produto_ausente;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}