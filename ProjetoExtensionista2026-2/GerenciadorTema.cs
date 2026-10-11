using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ProjetoExtensionista2026_2
{
    public class GerenciadorTema
    {
        public static bool ModoEscuro { get; set;} = false;

        //paleta escura
        public static readonly Color FundoEscuro = Color.FromArgb(32,32,32);//fundo
        public static readonly Color FundoControleEscuro = Color.FromArgb(45,45,48);//botões e card
        public static readonly Color TextoEscuro = Color.FromArgb(240,240,240);//texto
        public static readonly Color InputEscuro = Color.FromArgb(50,50,50);//inputs


        //paleta clara(padrão)
        public static readonly Color FundoClaro = SystemColors.Control;
        public static readonly Color FundoControleClaro = SystemColors.ControlLight;
        public static readonly Color TextoClaro = SystemColors.ControlText;
        public static readonly Color InputClaro = Color.White;

        /// <summary>
        /// Aplica o tema na tela e em todos os seus controles filhos recursivamente
        /// </summary>
        
        public static void AplicarTema(Control controle)
        {
            Color corFundo = ModoEscuro ? FundoEscuro : FundoClaro;
            Color corTexto = ModoEscuro ? TextoEscuro : TextoClaro;
            Color corInput = ModoEscuro ? InputEscuro : InputClaro;
            Color corBotao = ModoEscuro ? FundoControleEscuro : FundoControleClaro;

            // aplica no controle ou form
            if (controle is Form || controle is Panel || controle is UserControl)
            {
                controle.BackColor = corFundo;
                controle.ForeColor = corTexto;
            }
            

            foreach (Control filho in controle.Controls)
            {
                if (filho is Label)
                {
                    filho.ForeColor = corTexto;
                }
                else if (filho is TextBox || filho is ComboBox || filho is ListBox)
                {
                    filho.BackColor = corInput;
                    filho.ForeColor = corTexto;
                }
                else if (filho is Button btn)
                {
                    btn.BackColor = corBotao;
                    btn.ForeColor = corTexto;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 1;
                    btn.FlatAppearance.BorderColor = ModoEscuro ? Color.Gray : Color.DarkGray;
                }
                else if (filho is DataGridView dgv)
                {
                    dgv.BackgroundColor = corFundo;
                    dgv.DefaultCellStyle.BackColor = corInput;
                    dgv.DefaultCellStyle.ForeColor = corTexto;
                }
                
                //se o controle tiver childrens aplica o tema neles
                if (filho.HasChildren)
                {
                    AplicarTema(filho);
                }
            }
        }

    }
}
