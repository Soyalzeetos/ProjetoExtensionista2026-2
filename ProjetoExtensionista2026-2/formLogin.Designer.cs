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
            this.lockIcon = new System.Windows.Forms.PictureBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.lockIcon)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // userTxtBox
            // 
            this.userTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userTxtBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.userTxtBox.Location = new System.Drawing.Point(404, 282);
            this.userTxtBox.Name = "userTxtBox";
            this.userTxtBox.Size = new System.Drawing.Size(200, 20);
            this.userTxtBox.TabIndex = 1;
            this.userTxtBox.Text = "Insira seu nome de usuário";
            this.userTxtBox.Enter += new System.EventHandler(this.TextBox_Enter);
            this.userTxtBox.Leave += new System.EventHandler(this.TxtSenha_Leave);
            // 
            // pwdTxtBox
            // 
            this.pwdTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pwdTxtBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.pwdTxtBox.Location = new System.Drawing.Point(404, 311);
            this.pwdTxtBox.Name = "pwdTxtBox";
            this.pwdTxtBox.Size = new System.Drawing.Size(200, 20);
            this.pwdTxtBox.TabIndex = 1;
            this.pwdTxtBox.Text = "Insira sua senha";
            this.pwdTxtBox.Enter += new System.EventHandler(this.TextBox_Enter);
            this.pwdTxtBox.Leave += new System.EventHandler(this.TxtSenha_Leave);
            // 
            // lockIcon
            // 
            this.lockIcon.ImageLocation = "";
            this.lockIcon.InitialImage = ((System.Drawing.Image)(resources.GetObject("lockIcon.InitialImage")));
            this.lockIcon.Location = new System.Drawing.Point(439, 130);
            this.lockIcon.Name = "lockIcon";
            this.lockIcon.Size = new System.Drawing.Size(130, 130);
            this.lockIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lockIcon.TabIndex = 2;
            this.lockIcon.TabStop = false;
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.loginButton.Location = new System.Drawing.Point(404, 346);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(200, 27);
            this.loginButton.TabIndex = 0;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.AlternarCadeado);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.loginButton);
            this.panel1.Controls.Add(this.lockIcon);
            this.panel1.Controls.Add(this.pwdTxtBox);
            this.panel1.Controls.Add(this.userTxtBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 551);
            this.panel1.TabIndex = 3;
            // 
            // formLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 551);
            this.Controls.Add(this.panel1);
            this.Name = "formLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.lockIcon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox userTxtBox;
        private System.Windows.Forms.TextBox pwdTxtBox;
        private System.Windows.Forms.PictureBox lockIcon;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Panel panel1;
    }
}

