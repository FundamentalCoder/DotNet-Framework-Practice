namespace B.Project.Konfiguration
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.TB_C = new System.Windows.Forms.TextBox();
            this.lblKatze = new System.Windows.Forms.Label();
            this.lblHund = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TB_C
            // 
            this.TB_C.Location = new System.Drawing.Point(133, 128);
            this.TB_C.Name = "TB_C";
            this.TB_C.Size = new System.Drawing.Size(493, 26);
            this.TB_C.TabIndex = 0;
            // 
            // lblKatze
            // 
            this.lblKatze.AutoSize = true;
            this.lblKatze.Location = new System.Drawing.Point(161, 73);
            this.lblKatze.Name = "lblKatze";
            this.lblKatze.Size = new System.Drawing.Size(51, 20);
            this.lblKatze.TabIndex = 1;
            this.lblKatze.Text = "label1";
            // 
            // lblHund
            // 
            this.lblHund.AutoSize = true;
            this.lblHund.Location = new System.Drawing.Point(245, 73);
            this.lblHund.Name = "lblHund";
            this.lblHund.Size = new System.Drawing.Size(51, 20);
            this.lblHund.TabIndex = 2;
            this.lblHund.Text = "label2";
            this.lblHund.Click += new System.EventHandler(this.label2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblHund);
            this.Controls.Add(this.lblKatze);
            this.Controls.Add(this.TB_C);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_C;
        private System.Windows.Forms.Label lblKatze;
        private System.Windows.Forms.Label lblHund;
    }
}

