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
            this.picFoto = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.lblPrecoVenda = new System.Windows.Forms.Label();
            this.lblPrecoCompra = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // picFoto
            // 
            this.picFoto.Dock = System.Windows.Forms.DockStyle.Top;
            this.picFoto.Location = new System.Drawing.Point(0, 0);
            this.picFoto.Name = "picFoto";
            this.picFoto.Size = new System.Drawing.Size(198, 110);
            this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFoto.TabIndex = 0;
            this.picFoto.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(0, 110);
            this.lblTitulo.MaximumSize = new System.Drawing.Size(200, 40);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(200, 40);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "[00] Produto ...";
            // 
            // lblDescricao
            // 
            this.lblDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescricao.Location = new System.Drawing.Point(0, 150);
            this.lblDescricao.MaximumSize = new System.Drawing.Size(200, 30);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(200, 30);
            this.lblDescricao.TabIndex = 2;
            this.lblDescricao.Text = "Descricao ...";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(133, 192);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 25);
            this.button1.TabIndex = 3;
            this.button1.Text = "➕";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(164, 195);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(33, 22);
            this.numericUpDown1.TabIndex = 4;
            // 
            // lblPrecoVenda
            // 
            this.lblPrecoVenda.AutoSize = true;
            this.lblPrecoVenda.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecoVenda.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblPrecoVenda.Location = new System.Drawing.Point(3, 183);
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
            this.lblPrecoCompra.Location = new System.Drawing.Point(3, 202);
            this.lblPrecoCompra.Name = "lblPrecoCompra";
            this.lblPrecoCompra.Size = new System.Drawing.Size(50, 14);
            this.lblPrecoCompra.TabIndex = 6;
            this.lblPrecoCompra.Text = "R$ 00,00";
            // 
            // UcCardProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblPrecoCompra);
            this.Controls.Add(this.lblPrecoVenda);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.picFoto);
            this.Name = "UcCardProduto";
            this.Size = new System.Drawing.Size(198, 218);
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picFoto;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label lblPrecoVenda;
        private System.Windows.Forms.Label lblPrecoCompra;
    }
}
