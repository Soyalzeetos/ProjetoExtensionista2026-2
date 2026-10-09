using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoExtensionista2026_2
{
    public partial class formVenda : Form
    {
        private DataTable tabelaVisual = new DataTable();
        private const string TEXTO_PADRAO = "Pesquisar por Código, Nome ou Categoria...";

        public formVenda()
        {
            InitializeComponent();
        }

        private void formVenda_Load(object sender, EventArgs e)
        {
            ConfigurarPlaceholder();
            ConfigurarEstruturaGrid();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ConfigurarEstruturaGrid()
        {
            // Estrutura de colunas apenas para exibição em tela
            tabelaVisual.Columns.Add("Código", typeof(string));
            tabelaVisual.Columns.Add("Descrição", typeof(string));
            tabelaVisual.Columns.Add("Categoria", typeof(string));
            tabelaVisual.Columns.Add("Preço", typeof(string));
            tabelaVisual.Columns.Add("Estoque", typeof(string));

            // Itens visuais fictícios para você ver o filtro funcionando
            tabelaVisual.Rows.Add("001", "Item Exemplo A", "Geral", "R$ 50,00", "10");
            tabelaVisual.Rows.Add("002", "Item Exemplo B", "Ferramentas", "R$ 120,00", "5");
            tabelaVisual.Rows.Add("003", "Peça Teste C", "Acessórios", "R$ 35,00", "20");

            dgvProdutos.DataSource = tabelaVisual;

            // Ajustes visuais do DataGridView
            dgvProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProdutos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProdutos.ReadOnly = true;
            dgvProdutos.AllowUserToAddRows = false;
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (txtPesquisa.Text == TEXTO_PADRAO)
                return;

            string termo = txtPesquisa.Text.Trim().Replace("'", "''");

            if (string.IsNullOrWhiteSpace(termo))
            {
                tabelaVisual.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                // Filtra qualquer uma das colunas que contenha o texto digitado
                tabelaVisual.DefaultView.RowFilter = $"[Código] LIKE '%{termo}%' OR [Descrição] LIKE '%{termo}%' OR [Categoria] LIKE '%{termo}%'";
            }
        }

        #region Placeholder Visual (Texto Fantasma)

        private void ConfigurarPlaceholder()
        {
            txtPesquisa.Text = TEXTO_PADRAO;
            txtPesquisa.ForeColor = Color.Gray;

            txtPesquisa.Enter += TxtPesquisa_Enter;
            txtPesquisa.Leave += TxtPesquisa_Leave;
        }

        private void TxtPesquisa_Enter(object sender, EventArgs e)
        {
            if (txtPesquisa.Text == TEXTO_PADRAO)
            {
                txtPesquisa.Text = "";
                txtPesquisa.ForeColor = Color.Black;
            }
        }

        private void TxtPesquisa_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPesquisa.Text))
            {
                txtPesquisa.Text = TEXTO_PADRAO;
                txtPesquisa.ForeColor = Color.Gray;
                tabelaVisual.DefaultView.RowFilter = string.Empty;
            }
        }

        #endregion
    }
}