namespace ProjetoExtensionista2026_2
{
    partial class formLogin
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

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formLogin));
            this.userTxtBox = new System.Windows.Forms.TextBox();
            this.pwdTxtBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.lockIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.lockIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // userTxtBox
            // 
            this.userTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userTxtBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.userTxtBox.Location = new System.Drawing.Point(404, 204);
            this.userTxtBox.Name = "userTxtBox";
            this.userTxtBox.Size = new System.Drawing.Size(201, 20);
            this.userTxtBox.TabIndex = 0;
            this.userTxtBox.Text = "Email...";
            // 
            // pwdTxtBox
            // 
            this.pwdTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pwdTxtBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.pwdTxtBox.Location = new System.Drawing.Point(404, 230);
            this.pwdTxtBox.Name = "pwdTxtBox";
            this.pwdTxtBox.Size = new System.Drawing.Size(201, 20);
            this.pwdTxtBox.TabIndex = 1;
            this.pwdTxtBox.Text = "Password";
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.loginButton.Location = new System.Drawing.Point(404, 264);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(200, 27);
            this.loginButton.TabIndex = 3;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.AlternarCadeado);
            // 
            // lockIcon
            // 
            this.lockIcon.Image = global::ProjetoExtensionista2026_2.Properties.Resources.cadeado;
            this.lockIcon.ImageLocation = "";
            this.lockIcon.InitialImage = ((System.Drawing.Image)(resources.GetObject("lockIcon.InitialImage")));
            this.lockIcon.Location = new System.Drawing.Point(433, 88);
            this.lockIcon.Name = "lockIcon";
            this.lockIcon.Size = new System.Drawing.Size(130, 110);
            this.lockIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lockIcon.TabIndex = 2;
            this.lockIcon.TabStop = false;
            // 
            // formLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 551);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.lockIcon);
            this.Controls.Add(this.pwdTxtBox);
            this.Controls.Add(this.userTxtBox);
            this.Name = "formLogin";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.lockIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userTxtBox;
        private System.Windows.Forms.TextBox pwdTxtBox;
        private System.Windows.Forms.PictureBox lockIcon;
        private System.Windows.Forms.Button loginButton;
    }
}

