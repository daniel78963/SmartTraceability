
namespace SmartTraceability.Desktop.Views
{
    partial class FrmMaster
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
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnHome = new FontAwesome.Sharp.IconButton();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.pnlPageTitle = new System.Windows.Forms.Panel();
            this.lblTitleFormChild = new System.Windows.Forms.Label();
            this.pnlDesktop = new System.Windows.Forms.Panel();
            this.pnlMenu.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.pnlPageTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.White;
            this.pnlMenu.Controls.Add(this.btnHome);
            this.pnlMenu.Controls.Add(this.pnlLogo);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(800, 80);
            this.pnlMenu.TabIndex = 0;
            // 
            // btnHome
            // 
            this.btnHome.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnHome.IconColor = System.Drawing.Color.Black;
            this.btnHome.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnHome.Location = new System.Drawing.Point(268, 24);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(75, 23);
            this.btnHome.TabIndex = 1;
            this.btnHome.Text = "iconButton1";
            this.btnHome.UseVisualStyleBackColor = true;
            // 
            // pnlLogo
            // 
            this.pnlLogo.Controls.Add(this.lblLogo);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(241, 80);
            this.pnlLogo.TabIndex = 0;
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLogo.Location = new System.Drawing.Point(12, 24);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(191, 32);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "Smart Traceability";
            // 
            // pnlPageTitle
            // 
            this.pnlPageTitle.Controls.Add(this.lblTitleFormChild);
            this.pnlPageTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPageTitle.Location = new System.Drawing.Point(0, 80);
            this.pnlPageTitle.Name = "pnlPageTitle";
            this.pnlPageTitle.Size = new System.Drawing.Size(800, 23);
            this.pnlPageTitle.TabIndex = 1;
            // 
            // lblTitleFormChild
            // 
            this.lblTitleFormChild.AutoSize = true;
            this.lblTitleFormChild.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTitleFormChild.Font = new System.Drawing.Font("Segoe UI Semilight", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitleFormChild.Location = new System.Drawing.Point(0, 0);
            this.lblTitleFormChild.Name = "lblTitleFormChild";
            this.lblTitleFormChild.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblTitleFormChild.Size = new System.Drawing.Size(50, 19);
            this.lblTitleFormChild.TabIndex = 0;
            this.lblTitleFormChild.Text = "Home";
            this.lblTitleFormChild.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDesktop
            // 
            this.pnlDesktop.BackColor = System.Drawing.Color.White;
            this.pnlDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDesktop.Location = new System.Drawing.Point(0, 103);
            this.pnlDesktop.Name = "pnlDesktop";
            this.pnlDesktop.Size = new System.Drawing.Size(800, 347);
            this.pnlDesktop.TabIndex = 2;
            // 
            // FrmMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlDesktop);
            this.Controls.Add(this.pnlPageTitle);
            this.Controls.Add(this.pnlMenu);
            this.Name = "FrmMaster";
            this.Text = "Smart Traceability";
            this.pnlMenu.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            this.pnlLogo.PerformLayout();
            this.pnlPageTitle.ResumeLayout(false);
            this.pnlPageTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlPageTitle;
        private System.Windows.Forms.Panel pnlDesktop;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblTitleFormChild;
        private FontAwesome.Sharp.IconButton btnHome;
    }
}