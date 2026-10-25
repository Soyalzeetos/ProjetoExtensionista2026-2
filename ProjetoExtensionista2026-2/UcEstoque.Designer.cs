namespace ProjetoExtensionista2026_2
{
    partial class UcEstoque
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
            this.flowLayoutPanelProdutos = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutPanelProdutos
            // 
            this.flowLayoutPanelProdutos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelProdutos.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelProdutos.Name = "flowLayoutPanelProdutos";
            this.flowLayoutPanelProdutos.Size = new System.Drawing.Size(440, 474);
            this.flowLayoutPanelProdutos.TabIndex = 0;
            // 
            // UcEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanelProdutos);
            this.Name = "UcEstoque";
            this.Size = new System.Drawing.Size(440, 474);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelProdutos;
    }
}
