using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoExtensionista2026_2
{
    public partial class UcCadastroProduto : UserControl
    {
        public UcCadastroProduto()
        {
            InitializeComponent();
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

                        // Salva o caminho ou marca que usará esse arquivo
                        txtFotoUrl.Text = ofd.FileName;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao carregar a imagem selecionada: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCarregarFoto_Click(object sender, EventArgs e)
        {
            CarregarImagemPorUrl(txtFotoUrl.Text.Trim());
        }

        private void txtFotoUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                CarregarImagemPorUrl(txtFotoUrl.Text.Trim());
            }
        }

        /// <summary>
        /// Baixa e exibe a imagem da URL informada no PictureBox de preview
        /// </summary>
        private void CarregarImagemPorUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("Por favor, informe a URL da imagem.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFotoUrl.Focus();
                return;
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

                    byte[] dadosImagem = clienteWeb.DownloadData(url);

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

        // Variável interna para saber se está atualizando ou criando um novo
        public int? ProdutoIdEmEdicao { get; private set; }

        public void CarregarDadosParaEdicao(int id, string nome, string descricao, decimal precoVenda, decimal precoCompra, int estoque, string fotoUrl)
        {
            ProdutoIdEmEdicao = id;

            // Preenche os componentes visuais do seu UserControl
            txtNome.Text = nome;
            txtDescricao.Text = descricao;
            numPrecoVenda.Value = precoVenda;
            numPrecoVenda.Value = precoCompra;
            numEstoque.Value = estoque;
            txtFotoUrl.Text = fotoUrl;

            // Altera o texto do botão principal se necessário
            btnSalvar.Text = "Atualizar Produto";
        }

        public void LimparCamposParaNovoCadastro()
        {
            ProdutoIdEmEdicao = null;

            txtNome.Clear();
            txtDescricao.Clear();
            numPrecoVenda.Value = 0;
            numPrecoVenda.Value = 0;
            numEstoque.Value = 0;
            txtFotoUrl.Clear();

            btnSalvar.Text = "Cadastrar Produto";
        }
    }
}
