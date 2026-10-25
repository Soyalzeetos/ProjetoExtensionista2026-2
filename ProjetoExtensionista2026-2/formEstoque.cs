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
            CarregarProdutosExemplo();
            RenderizarLista();
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

        private void RenderizarLista()
        {
            // Evita que a tela pisque enquanto adiciona múltiplos controles
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.Controls.Clear();

            foreach (var produto in listaProdutos)
            {
                var card = new UcUserControlEstoque();
                card.AtualizarProduto(produto);

                flowLayoutPanel1.Controls.Add(card);
            }

            flowLayoutPanel1.ResumeLayout();
        }

        private void formEstoque_Load(object sender, EventArgs e)
        {
            
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string searchValue = searchTxtBox.Text.Trim();
            MessageBox.Show($"Você pesquisou por: {searchValue}", "Pesquisa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
