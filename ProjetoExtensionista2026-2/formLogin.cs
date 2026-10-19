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
using ProjetoExtensionista2026_2.SQL.SQL_functions;

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

        

        private void AlternarCadeado(object sender, EventArgs e)
        {
            using (LoginSQL loginSQL = new LoginSQL())
            {
                string username = userTxtBox.Text;
                string password = pwdTxtBox.Text;
                string hash = loginSQL.HashificarSenha(password, out _);
                int count = loginSQL.VerificarUsuario(username, hash);
                bool ver = count == 1;

                if (ver)
                {
                    lockIcon.Image = Properties.Resources.cadeado_aberto; // Altere para o ícone de cadeado aberto

                    formPrincipal principal = new formPrincipal();
                    principal.FormClosed += (s, args) => this.Close();

                    principal.Show();
                    this.Hide();
                }
                else
                {
                    lockIcon.Image = Properties.Resources.cadeado;// Altere para o ícone de cadeado fechado
                    MessageBox.Show("Nome de usuário ou senha inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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

        private void labelSignIn_Click(object sender, EventArgs e)
        {
            Form signInForm = new miniFormSignIn();
            signInForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            signInForm.MaximizeBox = false;
            signInForm.ShowDialog();
        }
    }
}
