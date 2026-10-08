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

            // Adiciona o form ao painel e o exibe
            this.panelWorkspace.Controls.Add(fh);
            this.panelWorkspace.Tag = fh;
            fh.Show();
        }

        private void buttonCadastro(object sender, EventArgs e)
        {
            AbrirFormNoWorkspace(new formCadastro());
        }
    }
}
