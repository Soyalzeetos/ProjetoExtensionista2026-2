namespace ProjetoExtensionista2026_2
{
    partial class formVenda
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer_menu = new System.Windows.Forms.SplitContainer();
            this.splitContainer_catalogo = new System.Windows.Forms.SplitContainer();
            this.panelConteudo = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelCarrinho = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_menu)).BeginInit();
            this.splitContainer_menu.Panel2.SuspendLayout();
            this.splitContainer_menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_catalogo)).BeginInit();
            this.splitContainer_catalogo.Panel1.SuspendLayout();
            this.splitContainer_catalogo.Panel2.SuspendLayout();
            this.splitContainer_catalogo.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer_menu
            // 
            this.splitContainer_menu.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.splitContainer_menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_menu.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_menu.Name = "splitContainer_menu";
            // 
            // splitContainer_menu.Panel1
            // 
            this.splitContainer_menu.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer_menu.Panel1Collapsed = true;
            // 
            // splitContainer_menu.Panel2
            // 
            this.splitContainer_menu.Panel2.Controls.Add(this.splitContainer_catalogo);
            this.splitContainer_menu.Size = new System.Drawing.Size(1904, 1041);
            this.splitContainer_menu.SplitterDistance = 247;
            this.splitContainer_menu.SplitterWidth = 1;
            this.splitContainer_menu.TabIndex = 2;
            this.splitContainer_menu.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer_menu_SplitterMoved);
            // 
            // splitContainer_catalogo
            // 
            this.splitContainer_catalogo.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.splitContainer_catalogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_catalogo.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_catalogo.Name = "splitContainer_catalogo";
            // 
            // splitContainer_catalogo.Panel1
            // 
            this.splitContainer_catalogo.Panel1.Controls.Add(this.panelConteudo);
            // 
            // splitContainer_catalogo.Panel2
            // 
            this.splitContainer_catalogo.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer_catalogo.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer_catalogo.Size = new System.Drawing.Size(1904, 1041);
            this.splitContainer_catalogo.SplitterDistance = 1015;
            this.splitContainer_catalogo.SplitterWidth = 1;
            this.splitContainer_catalogo.TabIndex = 2;
            this.splitContainer_catalogo.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer_catalogo_SplitterMoved);
            // 
            // panelConteudo
            // 
            this.panelConteudo.BackColor = System.Drawing.SystemColors.Control;
            this.panelConteudo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelConteudo.Location = new System.Drawing.Point(0, 0);
            this.panelConteudo.Name = "panelConteudo";
            this.panelConteudo.Size = new System.Drawing.Size(1015, 1041);
            this.panelConteudo.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(888, 1041);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelCarrinho);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 159);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(20);
            this.panel1.Size = new System.Drawing.Size(882, 618);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(20, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(842, 29);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Itens Adicionados:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelCarrinho
            // 
            this.panelCarrinho.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCarrinho.Location = new System.Drawing.Point(20, 89);
            this.panelCarrinho.Name = "panelCarrinho";
            this.panelCarrinho.Size = new System.Drawing.Size(842, 509);
            this.panelCarrinho.TabIndex = 2;
            // 
            // formVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.splitContainer_menu);
            this.Name = "formVenda";
            this.Text = "formVenda";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.formVenda_Load);
            this.splitContainer_menu.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_menu)).EndInit();
            this.splitContainer_menu.ResumeLayout(false);
            this.splitContainer_catalogo.Panel1.ResumeLayout(false);
            this.splitContainer_catalogo.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_catalogo)).EndInit();
            this.splitContainer_catalogo.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer_menu;
        private System.Windows.Forms.SplitContainer splitContainer_catalogo;
        private System.Windows.Forms.Panel panelConteudo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelCarrinho;
    }
}