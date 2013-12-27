namespace Protea
{
    partial class frmDelivery
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
            this.btnSaveDelivery = new System.Windows.Forms.Button();
            this.btnCancelDelivery = new System.Windows.Forms.Button();
            this.dtpDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.cboxDeliveryBranch = new System.Windows.Forms.ComboBox();
            this.txtDeliveryDescription = new System.Windows.Forms.TextBox();
            this.cboxDelivered = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSaveDelivery
            // 
            this.btnSaveDelivery.Location = new System.Drawing.Point(63, 367);
            this.btnSaveDelivery.Name = "btnSaveDelivery";
            this.btnSaveDelivery.Size = new System.Drawing.Size(75, 23);
            this.btnSaveDelivery.TabIndex = 0;
            this.btnSaveDelivery.Text = "Save";
            this.btnSaveDelivery.UseVisualStyleBackColor = true;
            // 
            // btnCancelDelivery
            // 
            this.btnCancelDelivery.Location = new System.Drawing.Point(159, 367);
            this.btnCancelDelivery.Name = "btnCancelDelivery";
            this.btnCancelDelivery.Size = new System.Drawing.Size(75, 23);
            this.btnCancelDelivery.TabIndex = 1;
            this.btnCancelDelivery.Text = "Cancel";
            this.btnCancelDelivery.UseVisualStyleBackColor = true;
            // 
            // dtpDeliveryDate
            // 
            this.dtpDeliveryDate.Location = new System.Drawing.Point(80, 22);
            this.dtpDeliveryDate.Name = "dtpDeliveryDate";
            this.dtpDeliveryDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDeliveryDate.TabIndex = 2;
            // 
            // cboxDeliveryBranch
            // 
            this.cboxDeliveryBranch.FormattingEnabled = true;
            this.cboxDeliveryBranch.Location = new System.Drawing.Point(80, 48);
            this.cboxDeliveryBranch.Name = "cboxDeliveryBranch";
            this.cboxDeliveryBranch.Size = new System.Drawing.Size(200, 21);
            this.cboxDeliveryBranch.TabIndex = 3;
            // 
            // txtDeliveryDescription
            // 
            this.txtDeliveryDescription.Location = new System.Drawing.Point(80, 76);
            this.txtDeliveryDescription.Multiline = true;
            this.txtDeliveryDescription.Name = "txtDeliveryDescription";
            this.txtDeliveryDescription.Size = new System.Drawing.Size(450, 232);
            this.txtDeliveryDescription.TabIndex = 4;
            // 
            // cboxDelivered
            // 
            this.cboxDelivered.FormattingEnabled = true;
            this.cboxDelivered.Location = new System.Drawing.Point(80, 314);
            this.cboxDelivered.Name = "cboxDelivered";
            this.cboxDelivered.Size = new System.Drawing.Size(200, 21);
            this.cboxDelivered.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Delivery Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Branch";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 317);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Delivered";
            // 
            // frmDelivery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 402);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboxDelivered);
            this.Controls.Add(this.txtDeliveryDescription);
            this.Controls.Add(this.cboxDeliveryBranch);
            this.Controls.Add(this.dtpDeliveryDate);
            this.Controls.Add(this.btnCancelDelivery);
            this.Controls.Add(this.btnSaveDelivery);
            this.Name = "frmDelivery";
            this.Text = "Delivery";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveDelivery;
        private System.Windows.Forms.Button btnCancelDelivery;
        private System.Windows.Forms.DateTimePicker dtpDeliveryDate;
        private System.Windows.Forms.ComboBox cboxDeliveryBranch;
        private System.Windows.Forms.TextBox txtDeliveryDescription;
        private System.Windows.Forms.ComboBox cboxDelivered;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}