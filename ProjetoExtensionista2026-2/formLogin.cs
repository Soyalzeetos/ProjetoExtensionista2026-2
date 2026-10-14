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
using ProjetoExtensionista2026_2.SQL;

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
            bool isConnected = ProjetoExtensionista2026_2.SQL.Connection.TestConnection();
            if (!isConnected)
            {
                MessageBox.Show("Falha na conexão com o banco de dados. Verifique sua conexão e tente novamente.", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                MessageBox.Show("Conexão com o banco de dados estabelecida com sucesso.", "Conexão Estabelecida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return Program.verificarHash2(hash, "Pablo é lindo");
            }
              
        }

        private void AlternarCadeado(object sender, EventArgs e)
        {
            if (verificarHash())
            {
                lockIcon.Image = Properties.Resources.cadeado_aberto; // Altere para o ícone de cadeado aberto

                formPrincipal principal = new formPrincipal();
                principal.FormClosed += (s, args) => this.Close();

                principal.Show();
                this.Hide();
            }
            else
            {
                lockIcon.Image = Properties.Resources.cadeado; // Altere para o ícone de cadeado fechado
            }
        }

        private void ConfigurarPlaceholder()
        {
            userTxtBox.Text = "Insira seu nome de usuário";
            pwdTxtBox.Text = "Insira sua senha";
            userTxtBox.ForeColor = Color.Gray;
            pwdTxtBox.ForeColor = Color.Gray;
            pwdTxtBox.UseSystemPasswordChar = false;
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            if (sender == userTxtBox && userTxtBox.Text == "Insira seu nome de usuário")
            {
                userTxtBox.Text = "";
                userTxtBox.ForeColor = Color.Black;
            }
            else if (sender == pwdTxtBox && pwdTxtBox.Text == "Insira sua senha")
            {
                pwdTxtBox.Text = "";
                pwdTxtBox.ForeColor = Color.Black;
                pwdTxtBox.UseSystemPasswordChar = true;
            }
        }

        private void TxtSenha_Leave(object sender, EventArgs e)
        {
            if (sender == userTxtBox && string.IsNullOrWhiteSpace(userTxtBox.Text))
            {
                userTxtBox.Text = "Insira seu nome de usuário";
                userTxtBox.ForeColor = Color.Gray;
            }
            else if (sender == pwdTxtBox && string.IsNullOrWhiteSpace(pwdTxtBox.Text))
            {
                pwdTxtBox.Text = "Insira sua senha";
                pwdTxtBox.ForeColor = Color.Gray;
                pwdTxtBox.UseSystemPasswordChar = false;
            }
        }
    }
}
