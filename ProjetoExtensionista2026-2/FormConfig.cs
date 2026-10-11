using System;
using System.Windows.Forms;

namespace ProjetoExtensionista2026_2
{
    public partial class FormConfig : Form
    {
        public FormConfig()
        {
            InitializeComponent();
            AtualizarTextoBotao();
        }

        private void formConfig_Load(object sender, EventArgs e)
        {
            GerenciadorTema.AplicarTema(this);
        }

        private void btnAlternarTema_Click(object sender, EventArgs e)
        {
            // 1. Inverte o tema atual
            GerenciadorTema.ModoEscuro = !GerenciadorTema.ModoEscuro;

            //salva as preferencias
            Properties.Settings.Default.ModoEscuro = GerenciadorTema.ModoEscuro;
            Properties.Settings.Default.Save();

            // 2. Aplica o novo tema nesta tela e em todas as outras telas abertas
            foreach (Form formAberto in Application.OpenForms)
            {
                GerenciadorTema.AplicarTema(formAberto);
            }

            // 3. Atualiza o texto do botão
            AtualizarTextoBotao();
        }

        private void AtualizarTextoBotao()
        {
            if (GerenciadorTema.ModoEscuro)
            {
                btnAlternarTema.Text = "Mudar para Modo Claro";
            }
            else
            {
                btnAlternarTema.Text = "Mudar para Modo Escuro";
            }
        }
    }
}
