namespace WinUI
{
    partial class FormAdmin
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnCategoryProduct = new System.Windows.Forms.Button();
            this.btnCustomerType = new System.Windows.Forms.Button();
            this.btnEmployee = new System.Windows.Forms.Button();
            this.btnPaymentType = new System.Windows.Forms.Button();
            this.btnProvider = new System.Windows.Forms.Button();
            this.btnRols = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(132, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(912, 67);
            this.label1.TabIndex = 0;
            this.label1.Text = "BIENVENIDO ADMINISTRADOR";
            // 
            // btnCategoryProduct
            // 
            this.btnCategoryProduct.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategoryProduct.Location = new System.Drawing.Point(158, 176);
            this.btnCategoryProduct.Name = "btnCategoryProduct";
            this.btnCategoryProduct.Size = new System.Drawing.Size(285, 123);
            this.btnCategoryProduct.TabIndex = 1;
            this.btnCategoryProduct.Text = "CATEGORIA PRODUCTO";
            this.btnCategoryProduct.UseVisualStyleBackColor = true;
            this.btnCategoryProduct.Click += new System.EventHandler(this.btnCategoryProduct_Click);
            // 
            // btnCustomerType
            // 
            this.btnCustomerType.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomerType.Location = new System.Drawing.Point(440, 176);
            this.btnCustomerType.Name = "btnCustomerType";
            this.btnCustomerType.Size = new System.Drawing.Size(285, 123);
            this.btnCustomerType.TabIndex = 2;
            this.btnCustomerType.Text = "TIPO CLIENTE";
            this.btnCustomerType.UseVisualStyleBackColor = true;
            this.btnCustomerType.Click += new System.EventHandler(this.btnCustomerType_Click);
            // 
            // btnEmployee
            // 
            this.btnEmployee.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployee.Location = new System.Drawing.Point(718, 176);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(285, 123);
            this.btnEmployee.TabIndex = 3;
            this.btnEmployee.Text = "EMPLEADO";
            this.btnEmployee.UseVisualStyleBackColor = true;
            this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click);
            // 
            // btnPaymentType
            // 
            this.btnPaymentType.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaymentType.Location = new System.Drawing.Point(158, 298);
            this.btnPaymentType.Name = "btnPaymentType";
            this.btnPaymentType.Size = new System.Drawing.Size(285, 123);
            this.btnPaymentType.TabIndex = 4;
            this.btnPaymentType.Text = "TIPO PAGO";
            this.btnPaymentType.UseVisualStyleBackColor = true;
            this.btnPaymentType.Click += new System.EventHandler(this.btnPaymentType_Click);
            // 
            // btnProvider
            // 
            this.btnProvider.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProvider.Location = new System.Drawing.Point(440, 298);
            this.btnProvider.Name = "btnProvider";
            this.btnProvider.Size = new System.Drawing.Size(285, 123);
            this.btnProvider.TabIndex = 5;
            this.btnProvider.Text = "PROVEEDORES";
            this.btnProvider.UseVisualStyleBackColor = true;
            this.btnProvider.Click += new System.EventHandler(this.btnProvider_Click);
            // 
            // btnRols
            // 
            this.btnRols.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRols.Location = new System.Drawing.Point(718, 298);
            this.btnRols.Name = "btnRols";
            this.btnRols.Size = new System.Drawing.Size(285, 123);
            this.btnRols.TabIndex = 6;
            this.btnRols.Text = "ROLES";
            this.btnRols.UseVisualStyleBackColor = true;
            this.btnRols.Click += new System.EventHandler(this.btnRols_Click);
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 561);
            this.Controls.Add(this.btnRols);
            this.Controls.Add(this.btnProvider);
            this.Controls.Add(this.btnPaymentType);
            this.Controls.Add(this.btnEmployee);
            this.Controls.Add(this.btnCustomerType);
            this.Controls.Add(this.btnCategoryProduct);
            this.Controls.Add(this.label1);
            this.Name = "FormAdmin";
            this.Text = "FormAdmin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCategoryProduct;
        private System.Windows.Forms.Button btnCustomerType;
        private System.Windows.Forms.Button btnEmployee;
        private System.Windows.Forms.Button btnPaymentType;
        private System.Windows.Forms.Button btnProvider;
        private System.Windows.Forms.Button btnRols;
    }
}