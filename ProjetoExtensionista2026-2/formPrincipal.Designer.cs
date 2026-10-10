namespace ProjetoExtensionista2026_2
{
    partial class formPrincipal
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
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.panelWorkspace = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBoxSidebar = new System.Windows.Forms.ListBox();
            this.panelSidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.Controls.Add(this.listBoxSidebar);
            this.panelSidebar.Controls.Add(this.panel1);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(261, 681);
            this.panelSidebar.TabIndex = 0;
            // 
            // panelWorkspace
            // 
            this.panelWorkspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWorkspace.Location = new System.Drawing.Point(261, 0);
            this.panelWorkspace.Name = "panelWorkspace";
            this.panelWorkspace.Size = new System.Drawing.Size(803, 681);
            this.panelWorkspace.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 622);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(261, 59);
            this.panel1.TabIndex = 1;
            // 
            // listBoxSidebar
            // 
            this.listBoxSidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxSidebar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxSidebar.FormattingEnabled = true;
            this.listBoxSidebar.ItemHeight = 25;
            this.listBoxSidebar.Location = new System.Drawing.Point(0, 0);
            this.listBoxSidebar.Name = "listBoxSidebar";
            this.listBoxSidebar.Size = new System.Drawing.Size(261, 622);
            this.listBoxSidebar.TabIndex = 3;
            this.listBoxSidebar.Click += new System.EventHandler(this.IdentificarSidebarListBox);
            // 
            // formPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 681);
            this.Controls.Add(this.panelWorkspace);
            this.Controls.Add(this.panelSidebar);
            this.Name = "formPrincipal";
            this.Text = "formPrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelSidebar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelWorkspace;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBoxSidebar;
    }
}