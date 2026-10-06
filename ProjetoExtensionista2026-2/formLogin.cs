using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoExtensionista2026_2
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
            ConfigurarPlaceholder();
            lockIcon.Image = Properties.Resources.cadeado;
        }

        private bool verificarHash()
        {
            string senha = pwdTxtBox.Text;
            string hash = senha.GetHashCode().ToString();
            return Program.verificarHash2(hash, "Pablo é lindo");
        }

        private void AlternarCadeado(object sender, EventArgs e)
        {
            if (verificarHash())
            {
                lockIcon.Image = Properties.Resources.cadeado_aberto; // Altere para o ícone de cadeado aberto

                formCadastro cadastro = new formCadastro();
                cadastro.FormClosed += (s, args) => this.Close();

                cadastro.Show();
                this.Hide();
            }
            else
            {
                lockIcon.Image = Properties.Resources.cadeado; // Altere para o ícone de cadeado fechado
            }
        }

        private void ConfigurarPlaceholder()
        {
            userTxtBox.Text = "Insira seu usuário";
            pwdTxtBox.Text = "Insira sua senha";
            userTxtBox.ForeColor = Color.Gray;
            pwdTxtBox.ForeColor = Color.Gray;
            pwdTxtBox.UseSystemPasswordChar = false;
            userTxtBox.Enter += TextBox_Enter;
            pwdTxtBox.Enter += TextBox_Enter;
            userTxtBox.Leave += TxtSenha_Leave;
            pwdTxtBox.Leave += TxtSenha_Leave;
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox textBox && (textBox.Text == "Insira seu usuário" || textBox.Text == "Insira sua senha"))
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
                if (textBox == pwdTxtBox)
                {
                    textBox.UseSystemPasswordChar = true;
                }
            }
        }

        private void TxtSenha_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Insira seu usuário";
                textBox.ForeColor = Color.Gray;
                textBox.UseSystemPasswordChar = false;
            }

        }
    }
}
