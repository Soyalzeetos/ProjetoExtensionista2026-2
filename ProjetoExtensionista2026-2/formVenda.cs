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
    public partial class formVenda : Form
    {
        public formVenda()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void formVenda_Load(object sender, EventArgs e)
        {
            
        }

        private void splitContainer_menu_SplitterMoved(object sender, SplitterEventArgs e)
        {
            
            double percMin = 0.15;
            double percMax = 0.22;

            int larguraTotal = splitContainer_menu.Width;
            int limiteMinimo = (int)(larguraTotal * percMin);
            int limiteMaximo = (int)(larguraTotal * percMax);

            if (splitContainer_menu.SplitterDistance < limiteMinimo)
            {
                splitContainer_menu.SplitterDistance = limiteMinimo;
            }
            else if (splitContainer_menu.SplitterDistance > limiteMaximo)
            {
                splitContainer_menu.SplitterDistance = limiteMaximo;
            }
        }

        private void splitContainer_catalogo_SplitterMoved(object sender, SplitterEventArgs e)
        {
            double percMin = 0.60;
            double percMax = 0.70;

            int larguraTotal = splitContainer_catalogo.Width;
            int limiteMinimo = (int)(larguraTotal * percMin);
            int limiteMaximo = (int)(larguraTotal * percMax);

            if (splitContainer_catalogo.SplitterDistance < limiteMinimo)
            {
                splitContainer_catalogo.SplitterDistance = limiteMinimo;
            }
            else if (splitContainer_catalogo.SplitterDistance > limiteMaximo)
            {
                splitContainer_catalogo.SplitterDistance = limiteMaximo;
            }
        }
    }
}