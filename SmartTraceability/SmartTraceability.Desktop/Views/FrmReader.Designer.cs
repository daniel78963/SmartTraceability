
namespace SmartTraceability.Desktop.Views
{
    partial class FrmReader
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
            this.lblPort = new System.Windows.Forms.Label();
            this.cbPorts = new System.Windows.Forms.ComboBox();
            this.btnRead = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPort.Location = new System.Drawing.Point(12, 9);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(34, 19);
            this.lblPort.TabIndex = 0;
            this.lblPort.Text = "Port";
            // 
            // cbPorts
            // 
            this.cbPorts.FormattingEnabled = true;
            this.cbPorts.Location = new System.Drawing.Point(77, 8);
            this.cbPorts.Name = "cbPorts";
            this.cbPorts.Size = new System.Drawing.Size(184, 23);
            this.cbPorts.TabIndex = 1;
            // 
            // btnRead
            // 
            this.btnRead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRead.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRead.IconChar = FontAwesome.Sharp.IconChar.Play;
            this.btnRead.IconColor = System.Drawing.Color.Black;
            this.btnRead.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRead.IconSize = 18;
            this.btnRead.Location = new System.Drawing.Point(280, 8);
            this.btnRead.Margin = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(126, 30);
            this.btnRead.TabIndex = 2;
            this.btnRead.Text = "Start Read";
            this.btnRead.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // FrmReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 530);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.cbPorts);
            this.Controls.Add(this.lblPort);
            this.Name = "FrmReader";
            this.Text = "Home";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.ComboBox cbPorts;
        private FontAwesome.Sharp.IconButton btnRead;
    }
}