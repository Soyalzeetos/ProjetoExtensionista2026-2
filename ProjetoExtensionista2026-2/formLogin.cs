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
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        private void AlternarCadeado(object sender, EventArgs e)
        {
            if (pwdTxtBox.Text != "")
            {
                lockIcon.Image = Properties.Resources.cadeado_aberto; // Altere para o ícone de cadeado aberto
            }
            else
            {
                lockIcon.Image = Properties.Resources.cadeado; // Altere para o ícone de cadeado fechado
            }
        }
    }
}
