using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ProjetoExtensionista2026_2
{
    public class GerenciadorTema
    {
        private static readonly string CaminhoArquivoConfig = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config_tema.txt");
        private static readonly HashSet<int> ControlesMonitorados = new HashSet<int>();

        public static bool ModoEscuro { get; set; } = false;

        // =========================================================
        // PALETA SLATE & INDIGO (MODO ESCURO)
        // =========================================================
        public static readonly Color FundoEscuro = Color.FromArgb(24, 26, 32);              // #181A20 - Fundo principal
        public static readonly Color FundoCardEscuro = Color.FromArgb(34, 37, 46);          // #22252E - Cards, Painéis, GroupBoxes
        public static readonly Color FundoControleEscuro = Color.FromArgb(42, 46, 57);      // #2A2E39 - Botões
        public static readonly Color InputEscuro = Color.FromArgb(30, 33, 41);              // #1E2129 - TextBox, ComboBox, Linhas tabela
        public static readonly Color LinhaAlternadaEscura = Color.FromArgb(36, 40, 50);     // #242832 - Zebra DataGridView
        public static readonly Color BordaEscura = Color.FromArgb(56, 61, 76);              // #383D4C - Bordas sutis
        public static readonly Color TextoEscuro = Color.FromArgb(236, 239, 244);           // #ECEFF4 - Texto principal branco gelo
        public static readonly Color TextoSecundarioEscuro = Color.FromArgb(160, 174, 192); // #A0AEC0 - Subtítulos

        // =========================================================
        // PALETA SLATE & INDIGO (MODO CLARO)
        // =========================================================
        public static readonly Color FundoClaro = Color.FromArgb(243, 244, 246);            // #F3F4F6 - Fundo gelo suave
        public static readonly Color FundoCardClaro = Color.FromArgb(255, 255, 255);        // #FFFFFF - Cards brancos
        public static readonly Color FundoControleClaro = Color.FromArgb(229, 231, 235);    // #E5E7EB - Botões claros
        public static readonly Color InputClaro = Color.FromArgb(255, 255, 255);            // #FFFFFF - Inputs brancos
        public static readonly Color LinhaAlternadaClara = Color.FromArgb(249, 250, 251);   // #F9FAFB - Zebra DataGridView
        public static readonly Color BordaClara = Color.FromArgb(209, 213, 219);            // #D1D5DB - Bordas claras
        public static readonly Color TextoClaro = Color.FromArgb(31, 41, 55);               // #1F2937 - Chumbo escuro
        public static readonly Color TextoSecundarioClaro = Color.FromArgb(107, 114, 128);  // #6B7280 - Subtítulos

        // Cor de Destaque (Indigo Blue)
        public static readonly Color CorDestaque = Color.FromArgb(59, 130, 246);            // #3B82F6

        public static void CarregarTemaSalvo()
        {
            try
            {
                if (System.IO.File.Exists(CaminhoArquivoConfig))
                {
                    string conteudo = System.IO.File.ReadAllText(CaminhoArquivoConfig).Trim();
                    ModoEscuro = bool.TryParse(conteudo, out bool escuro) && escuro;
                }
            }
            catch { }
        }

        public static void SalvarTemaAtual()
        {
            try
            {
                System.IO.File.WriteAllText(CaminhoArquivoConfig, ModoEscuro.ToString());
            }
            catch { }
        }

        /// <summary>
        /// Aplica o tema na tela e em todos os seus controles filhos recursivamente,
        /// além de monitorar controles adicionados dinamicamente.
        /// </summary>
        public static void AplicarTema(Control controle)
        {
            if (controle == null) return;

            Color corFundo = ModoEscuro ? FundoEscuro : FundoClaro;
            Color corCard = ModoEscuro ? FundoCardEscuro : FundoCardClaro;
            Color corTexto = ModoEscuro ? TextoEscuro : TextoClaro;
            Color corInput = ModoEscuro ? InputEscuro : InputClaro;
            Color corBotao = ModoEscuro ? FundoControleEscuro : FundoControleClaro;
            Color corBorda = ModoEscuro ? BordaEscura : BordaClara;

            MonitorarControlesDinamicos(controle);

            // 1. Tratamento especial para SplitContainer (entra explicitamente em Panel1 e Panel2)
            if (controle is SplitContainer split)
            {
                split.BackColor = corBorda;
                split.ForeColor = corTexto;
                AplicarTema(split.Panel1);
                AplicarTema(split.Panel2);
                return;
            }

            // 2. Estiliza o próprio controle se for Container/Form
            if (controle is Form || controle is FlowLayoutPanel || controle is TableLayoutPanel || controle is SplitterPanel)
            {
                controle.BackColor = corFundo;
                controle.ForeColor = corTexto;
            }
            else if (controle is UserControl uc)
            {
                bool ehCard = uc.GetType().Name.Contains("Card");
                uc.BackColor = ehCard ? corCard : corFundo;
                uc.ForeColor = corTexto;
            }
            else if (controle is Panel pnl)
            {
                bool ehSidebar = pnl.Name != null && pnl.Name.IndexOf("Sidebar", StringComparison.OrdinalIgnoreCase) >= 0;
                pnl.BackColor = ehSidebar ? corCard : corFundo;
                pnl.ForeColor = corTexto;
            }
            else if (controle is GroupBox grp)
            {
                grp.BackColor = corCard;
                grp.ForeColor = corTexto;
            }
            else if (controle is TabPage page)
            {
                page.BackColor = corFundo;
                page.ForeColor = corTexto;
            }
            else if (controle is TabControl tab)
            {
                EstilizarTabControl(tab);
            }

            // 3. Estiliza controles individuais
            EstilizarControleIndividual(controle, corFundo, corCard, corTexto, corInput, corBotao, corBorda);

            // 4. Aplica recursivamente nos filhos
            foreach (Control filho in controle.Controls)
            {
                AplicarTema(filho);
            }
        }

        private static void EstilizarControleIndividual(Control ctrl, Color corFundo, Color corCard, Color corTexto, Color corInput, Color corBotao, Color corBorda)
        {
            if (ctrl is LinkLabel link)
            {
                link.LinkColor = ModoEscuro ? Color.FromArgb(96, 165, 250) : Color.FromArgb(37, 99, 235);
                link.ActiveLinkColor = ModoEscuro ? Color.FromArgb(147, 197, 253) : Color.FromArgb(29, 78, 216);
                link.VisitedLinkColor = ModoEscuro ? Color.FromArgb(167, 139, 250) : Color.FromArgb(109, 40, 217);
            }
            else if (ctrl is Label lbl)
            {
                // Preserva labels com fundo colorido de badge (ex: Estoque verde/vermelho no card)
                if (lbl.BackColor == Color.PaleGreen || lbl.BackColor == Color.LightCoral || lbl.BackColor == Color.LightSalmon)
                {
                    lbl.ForeColor = Color.FromArgb(20, 20, 20);
                    return;
                }

                // Se for o painel de código (#1, #2) no topo do card
                if (lbl.Name == "lblCodigo")
                {
                    lbl.BackColor = ModoEscuro ? Color.FromArgb(45, 50, 62) : Color.FromArgb(209, 213, 219);
                    lbl.ForeColor = corTexto;
                    return;
                }

                // Preserva cores semânticas de destaque (Lucro verde, Preço verde, Erro vermelho, Alerta laranja)
                if (EhCorDeDestaqueSemantica(lbl.ForeColor))
                {
                    return;
                }

                lbl.ForeColor = corTexto;
            }
            else if (ctrl is TextBox txt)
            {
                bool ehPlaceholder = txt.Text == "Insira seu nome de usuário" || txt.Text == "Insira sua senha";
                txt.BackColor = corInput;
                txt.ForeColor = ehPlaceholder ? Color.Gray : corTexto;
                txt.BorderStyle = BorderStyle.FixedSingle;
            }
            else if (ctrl is ComboBox cmb)
            {
                cmb.BackColor = corInput;
                cmb.ForeColor = corTexto;
                cmb.FlatStyle = FlatStyle.Flat;
            }
            else if (ctrl is MaskedTextBox mtxt)
            {
                mtxt.BackColor = corInput;
                mtxt.ForeColor = corTexto;
                mtxt.BorderStyle = BorderStyle.FixedSingle;
            }
            else if (ctrl is NumericUpDown nud)
            {
                nud.BackColor = corInput;
                nud.ForeColor = corTexto;
                nud.BorderStyle = BorderStyle.FixedSingle;
            }
            else if (ctrl is ListBox lb)
            {
                lb.BackColor = corCard;
                lb.ForeColor = corTexto;
                lb.BorderStyle = BorderStyle.None;
            }
            else if (ctrl is CheckBox || ctrl is RadioButton)
            {
                ctrl.ForeColor = corTexto;
            }
            else if (ctrl is Button btn)
            {
                // Se o botão estiver marcado como aba ativa (via Tag == "aba_ativa"), destaca com a cor Indigo
                if (btn.Tag != null && btn.Tag.ToString() == "aba_ativa")
                {
                    btn.BackColor = CorDestaque;
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    return;
                }

                btn.BackColor = corBotao;
                btn.ForeColor = corTexto;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = corBorda;
                btn.FlatAppearance.MouseOverBackColor = CorDestaque;
            }
            else if (ctrl is DataGridView dgv)
            {
                EstilizarDataGridView(dgv, corFundo, corCard, corTexto, corInput, corBotao, corBorda);
            }
            else if (ctrl is TabControl tab)
            {
                EstilizarTabControl(tab);
            }
        }

        private static bool EhCorDeDestaqueSemantica(Color cor)
        {
            return cor == Color.ForestGreen ||
                   cor == Color.LimeGreen ||
                   cor == Color.Green ||
                   cor == Color.Crimson ||
                   cor == Color.Red ||
                   cor == Color.DarkOrange;
        }

        private static void EstilizarDataGridView(DataGridView dgv, Color corFundo, Color corCard, Color corTexto, Color corInput, Color corBotao, Color corBorda)
        {
            Color corZebra = ModoEscuro ? LinhaAlternadaEscura : LinhaAlternadaClara;

            dgv.BackgroundColor = corCard;
            dgv.GridColor = corBorda;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.EnableHeadersVisualStyles = false;

            // Cabeçalho
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = corBotao;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = corTexto;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = corBotao;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = corTexto;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9.5F, FontStyle.Bold);

            // Linhas normais
            dgv.DefaultCellStyle.BackColor = corInput;
            dgv.DefaultCellStyle.ForeColor = corTexto;
            dgv.DefaultCellStyle.SelectionBackColor = CorDestaque;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            // Linhas alternadas (Zebra)
            dgv.AlternatingRowsDefaultCellStyle.BackColor = corZebra;
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = corTexto;
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = CorDestaque;
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White;
        }

        private static void EstilizarTabControl(TabControl tab)
        {
            tab.DrawMode = TabDrawMode.OwnerDrawFixed;
            tab.DrawItem -= TabControl_DrawItem;
            tab.DrawItem += TabControl_DrawItem;
            tab.Invalidate();
        }

        private static void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (!(sender is TabControl tab)) return;

            bool selecionada = (e.Index == tab.SelectedIndex);
            Color corFundoAba = selecionada
                ? (ModoEscuro ? CorDestaque : Color.White)
                : (ModoEscuro ? FundoCardEscuro : FundoControleClaro);

            Color corTextoAba = selecionada
                ? (ModoEscuro ? Color.White : TextoClaro)
                : (ModoEscuro ? TextoSecundarioEscuro : TextoSecundarioClaro);

            using (SolidBrush brushFundo = new SolidBrush(corFundoAba))
            {
                e.Graphics.FillRectangle(brushFundo, e.Bounds);
            }

            string titulo = tab.TabPages[e.Index].Text;
            TextRenderer.DrawText(
                e.Graphics,
                titulo,
                new Font(tab.Font.FontFamily, tab.Font.Size, selecionada ? FontStyle.Bold : FontStyle.Regular),
                e.Bounds,
                corTextoAba,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );
        }

        private static void MonitorarControlesDinamicos(Control container)
        {
            int hash = container.GetHashCode();
            if (ControlesMonitorados.Contains(hash)) return;

            ControlesMonitorados.Add(hash);
            container.ControlAdded += (s, e) =>
            {
                if (e.Control != null)
                {
                    AplicarTema(e.Control);
                }
            };
        }
    }
}
