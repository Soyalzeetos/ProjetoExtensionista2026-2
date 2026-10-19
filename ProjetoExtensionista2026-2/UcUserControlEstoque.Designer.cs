namespace ProjetoExtensionista2026_2
{
    partial class UcUserControlEstoque
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
            this.imgProduct = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // imgProduct
            // 
            this.imgProduct.Location = new System.Drawing.Point(3, 5);
            this.imgProduct.Name = "imgProduct";
            this.imgProduct.Size = new System.Drawing.Size(80, 80);
            this.imgProduct.TabIndex = 0;
            this.imgProduct.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(94, 5);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(400, 20);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "NomeProductPlaceholder";
            // 
            // lblDesc
            // 
            this.lblDesc.Location = new System.Drawing.Point(94, 25);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(400, 58);
            this.lblDesc.TabIndex = 2;
            this.lblDesc.Text = "DescricaoProductPlaceholder";
            // 
            // lblValor
            // 
            this.lblValor.Location = new System.Drawing.Point(500, 5);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(194, 80);
            this.lblValor.TabIndex = 3;
            this.lblValor.Text = "DescricaoProductPlaceholder";
            // 
            // UcUserControlEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.imgProduct);
            this.Name = "UcUserControlEstoque";
            this.Size = new System.Drawing.Size(987, 90);
            ((System.ComponentModel.ISupportInitialize)(this.imgProduct)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgProduct;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblValor;
    }
}
