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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer_menu = new System.Windows.Forms.SplitContainer();
            this.splitContainer_catalogo = new System.Windows.Forms.SplitContainer();
            this.panelConteudo = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgwPesquisa = new System.Windows.Forms.DataGridView();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTelefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnLimparCarrinho = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtDesconto = new System.Windows.Forms.TextBox();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescontoPorcentagem = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnCadastrarCliente = new System.Windows.Forms.Button();
            this.lblTelefoneCliente = new System.Windows.Forms.Label();
            this.lblLimiteCliente = new System.Windows.Forms.Label();
            this.lblStatusCliente = new System.Windows.Forms.Label();
            this.lblDocumentoCliente = new System.Windows.Forms.Label();
            this.lblEnderecoCliente = new System.Windows.Forms.Label();
            this.btnLimparCliente = new System.Windows.Forms.Button();
            this.txtBuscarCliente = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblQtdItens = new System.Windows.Forms.Label();
            this.panelCarrinho = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_menu)).BeginInit();
            this.splitContainer_menu.Panel2.SuspendLayout();
            this.splitContainer_menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_catalogo)).BeginInit();
            this.splitContainer_catalogo.Panel1.SuspendLayout();
            this.splitContainer_catalogo.Panel2.SuspendLayout();
            this.splitContainer_catalogo.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwPesquisa)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(888, 1041);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgwPesquisa
            // 
            this.dgwPesquisa.AllowUserToAddRows = false;
            this.dgwPesquisa.AllowUserToDeleteRows = false;
            this.dgwPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgwPesquisa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgwPesquisa.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgwPesquisa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgwPesquisa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwPesquisa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColID,
            this.ColName,
            this.ColDocumento,
            this.ColTelefone});
            this.dgwPesquisa.Location = new System.Drawing.Point(15, 76);
            this.dgwPesquisa.Name = "dgwPesquisa";
            this.dgwPesquisa.ReadOnly = true;
            this.dgwPesquisa.RowHeadersVisible = false;
            this.dgwPesquisa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwPesquisa.Size = new System.Drawing.Size(768, 171);
            this.dgwPesquisa.TabIndex = 5;
            this.dgwPesquisa.Visible = false;
            // 
            // ColID
            // 
            this.ColID.DataPropertyName = "Id";
            this.ColID.FillWeight = 18F;
            this.ColID.HeaderText = "Cód.";
            this.ColID.Name = "ColID";
            this.ColID.ReadOnly = true;
            // 
            // ColName
            // 
            this.ColName.DataPropertyName = "Nome";
            this.ColName.FillWeight = 47F;
            this.ColName.HeaderText = "Nome";
            this.ColName.Name = "ColName";
            this.ColName.ReadOnly = true;
            // 
            // ColDocumento
            // 
            this.ColDocumento.DataPropertyName = "Documento";
            this.ColDocumento.FillWeight = 35F;
            this.ColDocumento.HeaderText = "CPF/CNPJ";
            this.ColDocumento.Name = "ColDocumento";
            this.ColDocumento.ReadOnly = true;
            // 
            // ColTelefone
            // 
            this.ColTelefone.DataPropertyName = "Telefone";
            this.ColTelefone.FillWeight = 25F;
            this.ColTelefone.HeaderText = "Telefone";
            this.ColTelefone.Name = "ColTelefone";
            this.ColTelefone.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 866);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(882, 172);
            this.panel3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.btnLimparCarrinho);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.txtDesconto);
            this.panel4.Controls.Add(this.lblSubtotal);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.lblTotal);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.txtDescontoPorcentagem);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(20, 0, 20, 15);
            this.panel4.Size = new System.Drawing.Size(882, 172);
            this.panel4.TabIndex = 6;
            // 
            // btnLimparCarrinho
            // 
            this.btnLimparCarrinho.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnLimparCarrinho.BackColor = System.Drawing.Color.Red;
            this.btnLimparCarrinho.FlatAppearance.BorderSize = 0;
            this.btnLimparCarrinho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimparCarrinho.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimparCarrinho.ForeColor = System.Drawing.Color.White;
            this.btnLimparCarrinho.Location = new System.Drawing.Point(19, 119);
            this.btnLimparCarrinho.Name = "btnLimparCarrinho";
            this.btnLimparCarrinho.Size = new System.Drawing.Size(122, 45);
            this.btnLimparCarrinho.TabIndex = 12;
            this.btnLimparCarrinho.Text = "Limpar";
            this.btnLimparCarrinho.UseVisualStyleBackColor = false;
            this.btnLimparCarrinho.Click += new System.EventHandler(this.btnLimparCarrinho_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Black;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(20, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(842, 1);
            this.panel6.TabIndex = 4;
            // 
            // txtDesconto
            // 
            this.txtDesconto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesconto.BackColor = System.Drawing.SystemColors.Control;
            this.txtDesconto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDesconto.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesconto.Location = new System.Drawing.Point(734, 37);
            this.txtDesconto.Name = "txtDesconto";
            this.txtDesconto.ShortcutsEnabled = false;
            this.txtDesconto.Size = new System.Drawing.Size(125, 26);
            this.txtDesconto.TabIndex = 10;
            this.txtDesconto.Text = "- R$ 00,00";
            this.txtDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubtotal.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSubtotal.Location = new System.Drawing.Point(706, 9);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(161, 25);
            this.lblSubtotal.TabIndex = 9;
            this.lblSubtotal.Text = "R$0.000.000,00";
            this.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(15, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "Subtotal";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(15, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 26);
            this.label6.TabIndex = 5;
            this.label6.Text = "Desconto";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTotal.Location = new System.Drawing.Point(679, 86);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(188, 24);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "R$00.000.000,00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.LightGray;
            this.panel5.Location = new System.Drawing.Point(148, 103);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(520, 1);
            this.panel5.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.SeaGreen;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(151, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(708, 45);
            this.button1.TabIndex = 2;
            this.button1.Text = "Avançar para Pagamento";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(15, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "Valor Total";
            // 
            // txtDescontoPorcentagem
            // 
            this.txtDescontoPorcentagem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescontoPorcentagem.BackColor = System.Drawing.SystemColors.Control;
            this.txtDescontoPorcentagem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescontoPorcentagem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescontoPorcentagem.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtDescontoPorcentagem.Location = new System.Drawing.Point(810, 63);
            this.txtDescontoPorcentagem.Name = "txtDescontoPorcentagem";
            this.txtDescontoPorcentagem.ShortcutsEnabled = false;
            this.txtDescontoPorcentagem.Size = new System.Drawing.Size(49, 22);
            this.txtDescontoPorcentagem.TabIndex = 11;
            this.txtDescontoPorcentagem.Text = "100%";
            this.txtDescontoPorcentagem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.Controls.Add(this.dgwPesquisa);
            this.panel7.Controls.Add(this.btnCadastrarCliente);
            this.panel7.Controls.Add(this.lblTelefoneCliente);
            this.panel7.Controls.Add(this.lblLimiteCliente);
            this.panel7.Controls.Add(this.lblStatusCliente);
            this.panel7.Controls.Add(this.lblDocumentoCliente);
            this.panel7.Controls.Add(this.lblEnderecoCliente);
            this.panel7.Controls.Add(this.btnLimparCliente);
            this.panel7.Controls.Add(this.txtBuscarCliente);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Controls.Add(this.panel2);
            this.panel7.Controls.Add(this.label4);
            this.panel7.Location = new System.Drawing.Point(3, 3);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.panel7.Size = new System.Drawing.Size(882, 254);
            this.panel7.TabIndex = 2;
            // 
            // btnCadastrarCliente
            // 
            this.btnCadastrarCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCadastrarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastrarCliente.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrarCliente.Location = new System.Drawing.Point(789, 48);
            this.btnCadastrarCliente.Name = "btnCadastrarCliente";
            this.btnCadastrarCliente.Size = new System.Drawing.Size(30, 30);
            this.btnCadastrarCliente.TabIndex = 12;
            this.btnCadastrarCliente.Text = "➕";
            this.btnCadastrarCliente.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCadastrarCliente.UseVisualStyleBackColor = true;
            // 
            // lblTelefoneCliente
            // 
            this.lblTelefoneCliente.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefoneCliente.Location = new System.Drawing.Point(12, 149);
            this.lblTelefoneCliente.Name = "lblTelefoneCliente";
            this.lblTelefoneCliente.Size = new System.Drawing.Size(186, 21);
            this.lblTelefoneCliente.TabIndex = 11;
            this.lblTelefoneCliente.Text = "Telefone: (00) 00000-0000";
            this.lblTelefoneCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLimiteCliente
            // 
            this.lblLimiteCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLimiteCliente.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLimiteCliente.Location = new System.Drawing.Point(593, 122);
            this.lblLimiteCliente.Name = "lblLimiteCliente";
            this.lblLimiteCliente.Size = new System.Drawing.Size(189, 17);
            this.lblLimiteCliente.TabIndex = 10;
            this.lblLimiteCliente.Text = "Limite de Crédito: 0.000,00";
            this.lblLimiteCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStatusCliente
            // 
            this.lblStatusCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatusCliente.AutoSize = true;
            this.lblStatusCliente.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusCliente.Location = new System.Drawing.Point(681, 94);
            this.lblStatusCliente.Name = "lblStatusCliente";
            this.lblStatusCliente.Size = new System.Drawing.Size(101, 17);
            this.lblStatusCliente.TabIndex = 9;
            this.lblStatusCliente.Text = "Status: Ativo 🟢";
            this.lblStatusCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDocumentoCliente
            // 
            this.lblDocumentoCliente.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocumentoCliente.Location = new System.Drawing.Point(12, 122);
            this.lblDocumentoCliente.Name = "lblDocumentoCliente";
            this.lblDocumentoCliente.Size = new System.Drawing.Size(186, 17);
            this.lblDocumentoCliente.TabIndex = 8;
            this.lblDocumentoCliente.Text = "CPF/CNPJ: 000.000.000-00";
            this.lblDocumentoCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEnderecoCliente
            // 
            this.lblEnderecoCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEnderecoCliente.AutoEllipsis = true;
            this.lblEnderecoCliente.AutoSize = true;
            this.lblEnderecoCliente.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnderecoCliente.Location = new System.Drawing.Point(12, 94);
            this.lblEnderecoCliente.Margin = new System.Windows.Forms.Padding(0);
            this.lblEnderecoCliente.MaximumSize = new System.Drawing.Size(350, 17);
            this.lblEnderecoCliente.MinimumSize = new System.Drawing.Size(0, 17);
            this.lblEnderecoCliente.Name = "lblEnderecoCliente";
            this.lblEnderecoCliente.Size = new System.Drawing.Size(270, 17);
            this.lblEnderecoCliente.TabIndex = 7;
            this.lblEnderecoCliente.Text = "Endereco: Rua Exemplo, 123, Bairro Exemplo";
            this.lblEnderecoCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnLimparCliente
            // 
            this.btnLimparCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimparCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimparCliente.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimparCliente.Location = new System.Drawing.Point(826, 48);
            this.btnLimparCliente.Name = "btnLimparCliente";
            this.btnLimparCliente.Size = new System.Drawing.Size(30, 30);
            this.btnLimparCliente.TabIndex = 6;
            this.btnLimparCliente.Text = "🗑️";
            this.btnLimparCliente.UseVisualStyleBackColor = true;
            this.btnLimparCliente.Click += new System.EventHandler(this.btnLimparCliente_Click);
            // 
            // txtBuscarCliente
            // 
            this.txtBuscarCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscarCliente.BackColor = System.Drawing.SystemColors.Window;
            this.txtBuscarCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarCliente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarCliente.Location = new System.Drawing.Point(15, 48);
            this.txtBuscarCliente.Name = "txtBuscarCliente";
            this.txtBuscarCliente.Size = new System.Drawing.Size(768, 29);
            this.txtBuscarCliente.TabIndex = 3;
            this.txtBuscarCliente.TextChanged += new System.EventHandler(this.txtBuscarCliente_TextChanged);
            this.txtBuscarCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscarCliente_KeyDown);
            this.txtBuscarCliente.Leave += new System.EventHandler(this.ControlePesquisa_Leave);
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel8.Location = new System.Drawing.Point(15, 30);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(852, 1);
            this.panel8.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(15, 253);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(852, 1);
            this.panel2.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(852, 30);
            this.label4.TabIndex = 0;
            this.label4.Text = "Venda";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblQtdItens);
            this.panel1.Controls.Add(this.panelCarrinho);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 263);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(15, 15, 15, 0);
            this.panel1.Size = new System.Drawing.Size(882, 597);
            this.panel1.TabIndex = 0;
            // 
            // lblQtdItens
            // 
            this.lblQtdItens.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblQtdItens.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtdItens.Location = new System.Drawing.Point(15, 570);
            this.lblQtdItens.Name = "lblQtdItens";
            this.lblQtdItens.Size = new System.Drawing.Size(852, 27);
            this.lblQtdItens.TabIndex = 3;
            this.lblQtdItens.Text = "Quantidade de Itens:";
            this.lblQtdItens.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelCarrinho
            // 
            this.panelCarrinho.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelCarrinho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCarrinho.Location = new System.Drawing.Point(15, 15);
            this.panelCarrinho.Name = "panelCarrinho";
            this.panelCarrinho.Size = new System.Drawing.Size(852, 582);
            this.panelCarrinho.TabIndex = 0;
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
            ((System.ComponentModel.ISupportInitialize)(this.dgwPesquisa)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer_menu;
        private System.Windows.Forms.SplitContainer splitContainer_catalogo;
        private System.Windows.Forms.Panel panelConteudo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelCarrinho;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDesconto;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblQtdItens;
        private System.Windows.Forms.TextBox txtDescontoPorcentagem;
        private System.Windows.Forms.Button btnLimparCarrinho;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtBuscarCliente;
        private System.Windows.Forms.Label lblStatusCliente;
        private System.Windows.Forms.Label lblDocumentoCliente;
        private System.Windows.Forms.Label lblEnderecoCliente;
        private System.Windows.Forms.Button btnLimparCliente;
        private System.Windows.Forms.Label lblLimiteCliente;
        private System.Windows.Forms.Label lblTelefoneCliente;
        private System.Windows.Forms.Button btnCadastrarCliente;
        private System.Windows.Forms.DataGridView dgwPesquisa;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTelefone;
    }
}