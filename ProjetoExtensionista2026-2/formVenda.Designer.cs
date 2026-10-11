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
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer_menu = new System.Windows.Forms.SplitContainer();
            this.splitContainer_catalogo = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.flowLayoutPanelProdutos = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_menu)).BeginInit();
            this.splitContainer_menu.Panel2.SuspendLayout();
            this.splitContainer_menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_catalogo)).BeginInit();
            this.splitContainer_catalogo.Panel1.SuspendLayout();
            this.splitContainer_catalogo.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1904, 50);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer_menu
            // 
            this.splitContainer_menu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer_menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_menu.Location = new System.Drawing.Point(0, 50);
            this.splitContainer_menu.Name = "splitContainer_menu";
            // 
            // splitContainer_menu.Panel2
            // 
            this.splitContainer_menu.Panel2.Controls.Add(this.splitContainer_catalogo);
            this.splitContainer_menu.Size = new System.Drawing.Size(1904, 991);
            this.splitContainer_menu.SplitterDistance = 294;
            this.splitContainer_menu.SplitterWidth = 3;
            this.splitContainer_menu.TabIndex = 2;
            this.splitContainer_menu.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer_menu_SplitterMoved);
            // 
            // splitContainer_catalogo
            // 
            this.splitContainer_catalogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer_catalogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_catalogo.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_catalogo.Name = "splitContainer_catalogo";
            // 
            // splitContainer_catalogo.Panel1
            // 
            this.splitContainer_catalogo.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer_catalogo.Size = new System.Drawing.Size(1607, 991);
            this.splitContainer_catalogo.SplitterDistance = 861;
            this.splitContainer_catalogo.SplitterWidth = 3;
            this.splitContainer_catalogo.TabIndex = 0;
            this.splitContainer_catalogo.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer_catalogo_SplitterMoved);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanelProdutos, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.52632F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.42105F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.05263F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(859, 989);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnPesquisar);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.numericUpDown1);
            this.panel2.Controls.Add(this.txtPesquisa);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(853, 98);
            this.panel2.TabIndex = 0;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnPesquisar.Location = new System.Drawing.Point(585, 48);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(155, 35);
            this.btnPesquisar.TabIndex = 3;
            this.btnPesquisar.Text = "🔍 Pesquisar [Enter]";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(751, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Qtd:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(794, 13);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(46, 26);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPesquisa.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisa.Location = new System.Drawing.Point(233, 11);
            this.txtPesquisa.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(507, 29);
            this.txtPesquisa.TabIndex = 0;
            this.txtPesquisa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPesquisa_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Pesquisar por:";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Todos",
            "Código",
            "Nome"});
            this.comboBox1.Location = new System.Drawing.Point(120, 11);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(101, 28);
            this.comboBox1.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(424, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(155, 35);
            this.button2.TabIndex = 7;
            this.button2.Text = "❌ Limpar [Esc]";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelProdutos
            // 
            this.flowLayoutPanelProdutos.AutoScroll = true;
            this.flowLayoutPanelProdutos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelProdutos.Location = new System.Drawing.Point(3, 107);
            this.flowLayoutPanelProdutos.Name = "flowLayoutPanelProdutos";
            this.flowLayoutPanelProdutos.Size = new System.Drawing.Size(853, 670);
            this.flowLayoutPanelProdutos.TabIndex = 1;
            // 
            // formVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.splitContainer_menu);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "formVenda";
            this.Text = "formVenda";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.formVenda_Load);
            this.splitContainer_menu.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_menu)).EndInit();
            this.splitContainer_menu.ResumeLayout(false);
            this.splitContainer_catalogo.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_catalogo)).EndInit();
            this.splitContainer_catalogo.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer_menu;
        private System.Windows.Forms.SplitContainer splitContainer_catalogo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelProdutos;
    }
}