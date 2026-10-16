namespace ProjetoExtensionista2026_2
{
    partial class UcCardProduto
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.UpDownProduto = new System.Windows.Forms.NumericUpDown();
            this.lblPrecoVenda = new System.Windows.Forms.Label();
            this.lblPrecoCompra = new System.Windows.Forms.Label();
            this.picFoto = new System.Windows.Forms.PictureBox();
            this.lblEstoque = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownProduto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoEllipsis = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(-1, 140);
            this.lblTitulo.MaximumSize = new System.Drawing.Size(220, 50);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Padding = new System.Windows.Forms.Padding(2);
            this.lblTitulo.Size = new System.Drawing.Size(220, 40);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "[00] Produto ...";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoEllipsis = true;
            this.lblDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescricao.Location = new System.Drawing.Point(-1, 189);
            this.lblDescricao.MaximumSize = new System.Drawing.Size(220, 60);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Padding = new System.Windows.Forms.Padding(2);
            this.lblDescricao.Size = new System.Drawing.Size(220, 38);
            this.lblDescricao.TabIndex = 2;
            this.lblDescricao.Text = "Descricao ...";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(189, 251);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(25, 25);
            this.btnAdicionar.TabIndex = 3;
            this.btnAdicionar.Text = "➕";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // UpDownProduto
            // 
            this.UpDownProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpDownProduto.Location = new System.Drawing.Point(150, 252);
            this.UpDownProduto.Name = "UpDownProduto";
            this.UpDownProduto.Size = new System.Drawing.Size(33, 22);
            this.UpDownProduto.TabIndex = 4;
            // 
            // lblPrecoVenda
            // 
            this.lblPrecoVenda.AutoSize = true;
            this.lblPrecoVenda.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecoVenda.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblPrecoVenda.Location = new System.Drawing.Point(7, 242);
            this.lblPrecoVenda.Name = "lblPrecoVenda";
            this.lblPrecoVenda.Size = new System.Drawing.Size(67, 18);
            this.lblPrecoVenda.TabIndex = 5;
            this.lblPrecoVenda.Text = "R$ 00,00";
            // 
            // lblPrecoCompra
            // 
            this.lblPrecoCompra.AutoSize = true;
            this.lblPrecoCompra.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecoCompra.ForeColor = System.Drawing.Color.Red;
            this.lblPrecoCompra.Location = new System.Drawing.Point(7, 260);
            this.lblPrecoCompra.Name = "lblPrecoCompra";
            this.lblPrecoCompra.Size = new System.Drawing.Size(84, 14);
            this.lblPrecoCompra.TabIndex = 6;
            this.lblPrecoCompra.Text = "Custo: R$ 00,00";
            // 
            // picFoto
            // 
            this.picFoto.Dock = System.Windows.Forms.DockStyle.Top;
            this.picFoto.ErrorImage = null;
            this.picFoto.Location = new System.Drawing.Point(0, 0);
            this.picFoto.Name = "picFoto";
            this.picFoto.Size = new System.Drawing.Size(220, 140);
            this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picFoto.TabIndex = 0;
            this.picFoto.TabStop = false;
            // 
            // lblEstoque
            // 
            this.lblEstoque.AutoSize = true;
            this.lblEstoque.Location = new System.Drawing.Point(116, 239);
            this.lblEstoque.Name = "lblEstoque";
            this.lblEstoque.Size = new System.Drawing.Size(52, 13);
            this.lblEstoque.TabIndex = 7;
            this.lblEstoque.Text = "Estoque: ";
            // 
            // UcCardProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblEstoque);
            this.Controls.Add(this.lblPrecoCompra);
            this.Controls.Add(this.lblPrecoVenda);
            this.Controls.Add(this.UpDownProduto);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.picFoto);
            this.Name = "UcCardProduto";
            this.Size = new System.Drawing.Size(220, 280);
            ((System.ComponentModel.ISupportInitialize)(this.UpDownProduto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.NumericUpDown UpDownProduto;
        private System.Windows.Forms.Label lblPrecoVenda;
        private System.Windows.Forms.Label lblPrecoCompra;
        private System.Windows.Forms.PictureBox picFoto;
        private System.Windows.Forms.Label lblEstoque;
    }
}
