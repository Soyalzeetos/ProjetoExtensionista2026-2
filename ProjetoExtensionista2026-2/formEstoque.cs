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
    public partial class formEstoque : Form
    {
        private UcEstoque _ucEstoque;
        private List<Produto> listaProdutos = new List<Produto>();

        public class Produto
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public int Quantidade { get; set; }
            public int EstoqueMinimo { get; set; }
            public decimal Preco { get; set; }
        }

        public formEstoque()
        {
            InitializeComponent();
        }

        private void CarregarProdutosExemplo()
        {
            listaProdutos = new List<Produto>
            {
                new Produto { Id = 1, Nome = "Teclado Mecânico RGB", Quantidade = 8, EstoqueMinimo = 5 },
                new Produto { Id = 2, Nome = "Mouse Sem Fio 1600 DPI", Quantidade = 2, EstoqueMinimo = 4 },
                new Produto { Id = 3, Nome = "Monitor 24 Pol IPS", Quantidade = 15, EstoqueMinimo = 3 },
                new Produto { Id = 3, Nome = "Monitor 24 Pol IPS", Quantidade = 15, EstoqueMinimo = 3 },
                new Produto { Id = 3, Nome = "Monitor 24 Pol IPS", Quantidade = 15, EstoqueMinimo = 3 },
                new Produto { Id = 3, Nome = "Monitor 24 Pol IPS", Quantidade = 15, EstoqueMinimo = 3 },
                new Produto { Id = 3, Nome = "Monitor 24 Pol IPS", Quantidade = 15, EstoqueMinimo = 3 },
                new Produto { Id = 3, Nome = "Monitor 24 Pol IPS", Quantidade = 15, EstoqueMinimo = 3 },
                new Produto { Id = 3, Nome = "Monitor 24 Pol IPS", Quantidade = 15, EstoqueMinimo = 3 },
                new Produto { Id = 3, Nome = "Monitor 24 Pol IPS", Quantidade = 15, EstoqueMinimo = 3 },
                new Produto { Id = 3, Nome = "Monitor 24 Pol IPS", Quantidade = 15, EstoqueMinimo = 3 },
                new Produto { Id = 3, Nome = "Monitor 24 Pol IPS", Quantidade = 15, EstoqueMinimo = 3 },
                new Produto { Id = 3, Nome = "Monitor 24 Pol IPS", Quantidade = 15, EstoqueMinimo = 3 }
            };
        }

        private void formEstoque_Load(object sender, EventArgs e)
        {
            _ucEstoque = new UcEstoque();
            _ucEstoque.Dock = DockStyle.Fill;

            _ucEstoque.ConfigurarPerfilVendedor(false);
            panelConteudo.Controls.Clear();
            panelConteudo.Controls.Add(_ucEstoque);
            _ucEstoque.BringToFront();
            _ucEstoque.BuscarProdutosNoSupabase("");
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string searchValue = searchTxtBox.Text.Trim();
            MessageBox.Show($"Você pesquisou por: {searchValue}", "Pesquisa", MessageBoxButtons.OK, MessageBoxIcon.Information);

            _ucEstoque?.BuscarProdutosNoSupabase(searchValue);
        }

        private void searchTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string searchValue = searchTxtBox.Text.Trim();
                _ucEstoque?.BuscarProdutosNoSupabase(searchValue);
            }
        }
    }
}