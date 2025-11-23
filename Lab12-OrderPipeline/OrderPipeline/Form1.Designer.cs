namespace OrderPipeline
{
    partial class Form1
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
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnProcessOrder = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.chkExpress = new System.Windows.Forms.CheckBox();
            this.btnShipOrder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(46, 59);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(5);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(164, 29);
            this.txtCustomer.TabIndex = 0;
            // 
            // cmbProduct
            // 
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Location = new System.Drawing.Point(143, 120);
            this.cmbProduct.Margin = new System.Windows.Forms.Padding(5);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(199, 29);
            this.cmbProduct.TabIndex = 1;
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(46, 120);
            this.numQuantity.Margin = new System.Windows.Forms.Padding(5);
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(68, 29);
            this.numQuantity.TabIndex = 2;
            // 
            // btnProcessOrder
            // 
            this.btnProcessOrder.AllowDrop = true;
            this.btnProcessOrder.Location = new System.Drawing.Point(46, 180);
            this.btnProcessOrder.Margin = new System.Windows.Forms.Padding(5);
            this.btnProcessOrder.Name = "btnProcessOrder";
            this.btnProcessOrder.Size = new System.Drawing.Size(164, 33);
            this.btnProcessOrder.TabIndex = 3;
            this.btnProcessOrder.Text = "Process Order";
            this.btnProcessOrder.UseVisualStyleBackColor = true;
            this.btnProcessOrder.Click += new System.EventHandler(this.btnProcessOrder_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(42, 246);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(125, 21);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status: Waiting";
            // 
            // lblTitle
            // 
            this.lblTitle.AllowDrop = true;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(118, 23);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(198, 21);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Order Processing System";
            // 
            // chkExpress
            // 
            this.chkExpress.AutoSize = true;
            this.chkExpress.Location = new System.Drawing.Point(46, 285);
            this.chkExpress.Name = "chkExpress";
            this.chkExpress.Size = new System.Drawing.Size(159, 25);
            this.chkExpress.TabIndex = 6;
            this.chkExpress.Text = "Express Shipping";
            this.chkExpress.UseVisualStyleBackColor = true;
            // 
            // btnShipOrder
            // 
            this.btnShipOrder.Location = new System.Drawing.Point(46, 328);
            this.btnShipOrder.Name = "btnShipOrder";
            this.btnShipOrder.Size = new System.Drawing.Size(107, 29);
            this.btnShipOrder.TabIndex = 7;
            this.btnShipOrder.Text = "Ship Order";
            this.btnShipOrder.UseVisualStyleBackColor = true;
            this.btnShipOrder.Click += new System.EventHandler(this.btnShipOrder_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 380);
            this.Controls.Add(this.btnShipOrder);
            this.Controls.Add(this.chkExpress);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnProcessOrder);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.cmbProduct);
            this.Controls.Add(this.txtCustomer);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button btnProcessOrder;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.CheckBox chkExpress;
        private System.Windows.Forms.Button btnShipOrder;
    }
}

