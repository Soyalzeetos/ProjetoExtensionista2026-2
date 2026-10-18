using ProjetoExtensionista2026_2.SQL.SQL_functions;
using ProjetoExtensionista2026_2.SQL;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoExtensionista2026_2
{
    public partial class miniFormSignIn : Form
    {
        public miniFormSignIn()
        {
            InitializeComponent();
        }

        // Versão simplificada: valida campos, calcula hash e registra em background.
        private async void RegisterBtn_Click(object sender, EventArgs e)
        {
            string username = nameTextBox.Text?.Trim();
            string password = pwdTextBox.Text ?? string.Empty;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Preencha usuário e senha.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Enabled = false;
            try
            {
                int result = await Task.Run(() =>
                {
                    if (!Connection.TestConnection())
                        return -2; // código para erro de conexão

                    using (var sha = SHA256.Create())
                    {
                        var hash = BitConverter.ToString(sha.ComputeHash(Encoding.UTF8.GetBytes(password))).Replace("-", "").ToLowerInvariant();
                        var sql = new LoginSQL();
                        return sql.RegisterUser(username, hash);
                    }
                });

                if (result == -2)
                {
                    MessageBox.Show("Erro de conexão com o banco.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (result > 0)
                {
                    MessageBox.Show("Registrado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Falha ao registrar usuário.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                this.Enabled = true;
            }
        }
    }
}
