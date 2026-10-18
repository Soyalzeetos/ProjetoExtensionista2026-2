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
            this.button2 = new System.Windows.Forms.Button();
            this.cmbPesquisa = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.flowLayoutPanelProdutos = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAtualizarProdutos = new System.Windows.Forms.Button();
            this.btnCadastrarProduto = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_menu)).BeginInit();
            this.splitContainer_menu.Panel2.SuspendLayout();
            this.splitContainer_menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_catalogo)).BeginInit();
            this.splitContainer_catalogo.Panel1.SuspendLayout();
            this.splitContainer_catalogo.Panel2.SuspendLayout();
            this.splitContainer_catalogo.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1904, 50);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer_menu
            // 
            this.splitContainer_menu.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.splitContainer_menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_menu.Location = new System.Drawing.Point(0, 50);
            this.splitContainer_menu.Name = "splitContainer_menu";
            // 
            // splitContainer_menu.Panel1
            // 
            this.splitContainer_menu.Panel1.BackColor = System.Drawing.SystemColors.Control;
            // 
            // splitContainer_menu.Panel2
            // 
            this.splitContainer_menu.Panel2.Controls.Add(this.splitContainer_catalogo);
            this.splitContainer_menu.Size = new System.Drawing.Size(1904, 991);
            this.splitContainer_menu.SplitterDistance = 294;
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
            this.splitContainer_catalogo.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer_catalogo.Panel2
            // 
            this.splitContainer_catalogo.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer_catalogo.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer_catalogo.Size = new System.Drawing.Size(1609, 991);
            this.splitContainer_catalogo.SplitterDistance = 860;
            this.splitContainer_catalogo.SplitterWidth = 1;
            this.splitContainer_catalogo.TabIndex = 2;
            this.splitContainer_catalogo.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer_catalogo_SplitterMoved);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanelProdutos, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(860, 991);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.cmbPesquisa);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnPesquisar);
            this.panel2.Controls.Add(this.txtPesquisa);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(854, 93);
            this.panel2.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(525, 45);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(155, 35);
            this.button2.TabIndex = 7;
            this.button2.Text = "❌ Limpar [Esc]";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // cmbPesquisa
            // 
            this.cmbPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPesquisa.FormattingEnabled = true;
            this.cmbPesquisa.Items.AddRange(new object[] {
            "Todos",
            "Código",
            "Nome"});
            this.cmbPesquisa.Location = new System.Drawing.Point(120, 11);
            this.cmbPesquisa.Name = "cmbPesquisa";
            this.cmbPesquisa.Size = new System.Drawing.Size(101, 28);
            this.cmbPesquisa.TabIndex = 6;
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
            // btnPesquisar
            // 
            this.btnPesquisar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnPesquisar.Location = new System.Drawing.Point(689, 45);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(155, 35);
            this.btnPesquisar.TabIndex = 3;
            this.btnPesquisar.Text = "🔍 Pesquisar [Enter]";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPesquisa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPesquisa.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisa.Location = new System.Drawing.Point(233, 11);
            this.txtPesquisa.Margin = new System.Windows.Forms.Padding(0);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(611, 29);
            this.txtPesquisa.TabIndex = 0;
            this.txtPesquisa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPesquisa_KeyDown);
            // 
            // flowLayoutPanelProdutos
            // 
            this.flowLayoutPanelProdutos.AutoScroll = true;
            this.flowLayoutPanelProdutos.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanelProdutos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelProdutos.Location = new System.Drawing.Point(3, 102);
            this.flowLayoutPanelProdutos.Name = "flowLayoutPanelProdutos";
            this.flowLayoutPanelProdutos.Size = new System.Drawing.Size(854, 786);
            this.flowLayoutPanelProdutos.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnAtualizarProdutos);
            this.panel3.Controls.Add(this.btnCadastrarProduto);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 894);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(854, 94);
            this.panel3.TabIndex = 2;
            // 
            // btnAtualizarProdutos
            // 
            this.btnAtualizarProdutos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAtualizarProdutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizarProdutos.Location = new System.Drawing.Point(534, 16);
            this.btnAtualizarProdutos.Name = "btnAtualizarProdutos";
            this.btnAtualizarProdutos.Size = new System.Drawing.Size(144, 61);
            this.btnAtualizarProdutos.TabIndex = 1;
            this.btnAtualizarProdutos.Text = "Atualizar";
            this.btnAtualizarProdutos.UseVisualStyleBackColor = true;
            // 
            // btnCadastrarProduto
            // 
            this.btnCadastrarProduto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCadastrarProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrarProduto.Location = new System.Drawing.Point(698, 16);
            this.btnCadastrarProduto.Name = "btnCadastrarProduto";
            this.btnCadastrarProduto.Size = new System.Drawing.Size(144, 61);
            this.btnCadastrarProduto.TabIndex = 0;
            this.btnCadastrarProduto.Text = "Cadastrar Produto";
            this.btnCadastrarProduto.UseVisualStyleBackColor = true;
            this.btnCadastrarProduto.Click += new System.EventHandler(this.btnCadastrarProduto_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(748, 991);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // formVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.splitContainer_menu);
            this.Controls.Add(this.panel1);
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
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer_menu;
        private System.Windows.Forms.SplitContainer splitContainer_catalogo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPesquisa;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelProdutos;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAtualizarProdutos;
        private System.Windows.Forms.Button btnCadastrarProduto;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}