namespace WinUI
{
    partial class FormCancelInvoice
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
            this.cmbSelect = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAnularFac = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbSelect
            // 
            this.cmbSelect.FormattingEnabled = true;
            this.cmbSelect.Location = new System.Drawing.Point(184, 74);
            this.cmbSelect.Name = "cmbSelect";
            this.cmbSelect.Size = new System.Drawing.Size(288, 21);
            this.cmbSelect.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "SELECCIONE LA FACTURA";
            // 
            // btnAnularFac
            // 
            this.btnAnularFac.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnAnularFac.Location = new System.Drawing.Point(514, 68);
            this.btnAnularFac.Margin = new System.Windows.Forms.Padding(2);
            this.btnAnularFac.Name = "btnAnularFac";
            this.btnAnularFac.Size = new System.Drawing.Size(134, 31);
            this.btnAnularFac.TabIndex = 17;
            this.btnAnularFac.Text = "Anulacion de facturas";
            this.btnAnularFac.UseVisualStyleBackColor = false;
            this.btnAnularFac.Click += new System.EventHandler(this.btnAnularFac_Click);
            // 
            // FormCancelInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(933, 202);
            this.Controls.Add(this.btnAnularFac);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbSelect);
            this.Name = "FormCancelInvoice";
            this.Text = "FormCancelInvoice";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAnularFac;
    }
}