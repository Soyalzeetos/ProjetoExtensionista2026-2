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
    public partial class formPrincipal : Form
    {
        public formPrincipal()
        {
            InitializeComponent();
            

            GerenciadorTema.AplicarTema(this);
        }
        private void formPrincipal_Load(object sender, EventArgs e)
        {
            using (var sql = new SQL.SQL_functions.LoginSQL())
            {
                string role = sql.RolePicker(SQL.SQL_functions.LoginSQL.SessaoUsuario.Nome);
                if (!string.IsNullOrEmpty(role))
                {
                    SQL.SQL_functions.LoginSQL.SessaoUsuario.Role = role;
                    var rolesManager = new rolesClass();
                    rolesManager.RoleSidebar(this, role, SQL.SQL_functions.LoginSQL.SessaoUsuario.Nome, SQL.SQL_functions.LoginSQL.SessaoUsuario.Hash);
                }
                else
                {
                    MessageBox.Show("Não foi possível determinar o papel do usuário. O aplicativo será encerrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
        }
        private void AbrirFormNoWorkspace(object formFilho)
        {
            // Fecha qualquer formulário que já esteja aberto no workspace
            if (this.panelWorkspace.Controls.Count > 0)
                this.panelWorkspace.Controls.RemoveAt(0);

            // Configura o novo formulário para rodar dentro do painel
            Form fh = formFilho as Form;
            fh.TopLevel = false;            // IMPORTANTE: Diz que ele não é uma janela independente
            fh.FormBorderStyle = FormBorderStyle.None; // Remove a barra de fechar/minimizar do form filho
            fh.Dock = DockStyle.Fill;       // Faz o form filho ocupar todo o espaço do painel workspace

            GerenciadorTema.AplicarTema(fh); // aplicar tema ativo

            // Adiciona o form ao painel e o exibe
            this.panelWorkspace.Controls.Add(fh);
            this.panelWorkspace.Tag = fh;
            fh.Show();
        }

        private void IdentificarSidebarListBox(object sender, EventArgs e)
        {
            if (listBoxSidebar.SelectedItem == null)
                return;
            string opcaoSelecionada = listBoxSidebar.SelectedItem.ToString();
            switch (opcaoSelecionada)
            {
                case "Cadastro":
                    AbrirFormNoWorkspace(new formCadastro());
                    break;

                case "Vendas":
                    // Exemplo de outro form
                    AbrirFormNoWorkspace(new formVenda());
                    break;

                case "Configurações":
                    AbrirFormNoWorkspace(new FormConfig());
                    break;

                case "Sair":
                    Application.Exit();
                    break;
            }
        }

        
    }
}
