namespace ProjetoExtensionista2026_2
{
    partial class FormConfig
    {
        /// <summary>Required designer variable.</summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>Clean up any resources being used.</summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>Required method for Designer support.</summary>
        private void InitializeComponent()
        {
            this.lblTituloTema = new System.Windows.Forms.Label();
            this.btnAlternarTema = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTituloTema
            // 
            this.lblTituloTema.AutoSize = true;
            this.lblTituloTema.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloTema.Location = new System.Drawing.Point(30, 30);
            this.lblTituloTema.Name = "lblTituloTema";
            this.lblTituloTema.Size = new System.Drawing.Size(149, 19);
            this.lblTituloTema.TabIndex = 0;
            this.lblTituloTema.Text = "Aparência e Tema";
            // 
            // btnAlternarTema
            // 
            this.btnAlternarTema.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlternarTema.Location = new System.Drawing.Point(34, 65);
            this.btnAlternarTema.Name = "btnAlternarTema";
            this.btnAlternarTema.Size = new System.Drawing.Size(240, 45);
            this.btnAlternarTema.TabIndex = 1;
            this.btnAlternarTema.Text = "🌙 Mudar para Modo Escuro";
            this.btnAlternarTema.UseVisualStyleBackColor = true;
            this.btnAlternarTema.Click += new System.EventHandler(this.btnAlternarTema_Click);
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTituloTema);
            this.Controls.Add(this.btnAlternarTema);
            this.Name = "FormConfig";
            this.Text = "Configurações";
            this.Load += new System.EventHandler(this.formConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTituloTema;
        private System.Windows.Forms.Button btnAlternarTema;
    }
}
