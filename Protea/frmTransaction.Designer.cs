namespace Protea
{
    partial class frmTransaction
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
            this.txtTransTypeDescription = new System.Windows.Forms.TextBox();
            this.btnSaveTransaction = new System.Windows.Forms.Button();
            this.btnExitTransaction = new System.Windows.Forms.Button();
            this.rbNone = new System.Windows.Forms.RadioButton();
            this.rbDropSafe = new System.Windows.Forms.RadioButton();
            this.rbRecon = new System.Windows.Forms.RadioButton();
            this.gbCounterEntry = new System.Windows.Forms.GroupBox();
            this.gbCounterEntry.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Description";
            // 
            // txtTransTypeDescription
            // 
            this.txtTransTypeDescription.Location = new System.Drawing.Point(79, 43);
            this.txtTransTypeDescription.Name = "txtTransTypeDescription";
            this.txtTransTypeDescription.Size = new System.Drawing.Size(359, 20);
            this.txtTransTypeDescription.TabIndex = 1;
            this.txtTransTypeDescription.TextChanged += new System.EventHandler(this.txtTransTypeDescription_TextChanged);
            // 
            // btnSaveTransaction
            // 
            this.btnSaveTransaction.Location = new System.Drawing.Point(152, 126);
            this.btnSaveTransaction.Name = "btnSaveTransaction";
            this.btnSaveTransaction.Size = new System.Drawing.Size(75, 23);
            this.btnSaveTransaction.TabIndex = 2;
            this.btnSaveTransaction.Text = "Save";
            this.btnSaveTransaction.UseVisualStyleBackColor = true;
            this.btnSaveTransaction.Click += new System.EventHandler(this.btnSaveTransaction_Click);
            // 
            // btnExitTransaction
            // 
            this.btnExitTransaction.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExitTransaction.Location = new System.Drawing.Point(233, 126);
            this.btnExitTransaction.Name = "btnExitTransaction";
            this.btnExitTransaction.Size = new System.Drawing.Size(75, 23);
            this.btnExitTransaction.TabIndex = 3;
            this.btnExitTransaction.Text = "Exit";
            this.btnExitTransaction.UseVisualStyleBackColor = true;
            // 
            // rbNone
            // 
            this.rbNone.AutoSize = true;
            this.rbNone.Checked = true;
            this.rbNone.Location = new System.Drawing.Point(6, 19);
            this.rbNone.Name = "rbNone";
            this.rbNone.Size = new System.Drawing.Size(49, 17);
            this.rbNone.TabIndex = 4;
            this.rbNone.TabStop = true;
            this.rbNone.Text = "none";
            this.rbNone.UseVisualStyleBackColor = true;
            this.rbNone.CheckedChanged += new System.EventHandler(this.rbNone_CheckedChanged);
            // 
            // rbDropSafe
            // 
            this.rbDropSafe.AutoSize = true;
            this.rbDropSafe.Location = new System.Drawing.Point(166, 19);
            this.rbDropSafe.Name = "rbDropSafe";
            this.rbDropSafe.Size = new System.Drawing.Size(73, 17);
            this.rbDropSafe.TabIndex = 5;
            this.rbDropSafe.Text = "Drop Safe";
            this.rbDropSafe.UseVisualStyleBackColor = true;
            this.rbDropSafe.CheckedChanged += new System.EventHandler(this.rbDropSafe_CheckedChanged);
            // 
            // rbRecon
            // 
            this.rbRecon.AutoSize = true;
            this.rbRecon.Location = new System.Drawing.Point(320, 19);
            this.rbRecon.Name = "rbRecon";
            this.rbRecon.Size = new System.Drawing.Size(57, 17);
            this.rbRecon.TabIndex = 6;
            this.rbRecon.Text = "Recon";
            this.rbRecon.UseVisualStyleBackColor = true;
            this.rbRecon.CheckedChanged += new System.EventHandler(this.rbRecon_CheckedChanged);
            // 
            // gbCounterEntry
            // 
            this.gbCounterEntry.Controls.Add(this.rbNone);
            this.gbCounterEntry.Controls.Add(this.rbRecon);
            this.gbCounterEntry.Controls.Add(this.rbDropSafe);
            this.gbCounterEntry.Location = new System.Drawing.Point(12, 69);
            this.gbCounterEntry.Name = "gbCounterEntry";
            this.gbCounterEntry.Size = new System.Drawing.Size(426, 51);
            this.gbCounterEntry.TabIndex = 7;
            this.gbCounterEntry.TabStop = false;
            this.gbCounterEntry.Text = "Counter Entry";
            // 
            // frmTransaction
            // 
            this.AcceptButton = this.btnSaveTransaction;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExitTransaction;
            this.ClientSize = new System.Drawing.Size(450, 158);
            this.Controls.Add(this.gbCounterEntry);
            this.Controls.Add(this.btnExitTransaction);
            this.Controls.Add(this.btnSaveTransaction);
            this.Controls.Add(this.txtTransTypeDescription);
            this.Controls.Add(this.label1);
            this.Name = "frmTransaction";
            this.Text = "Transaction";
            this.gbCounterEntry.ResumeLayout(false);
            this.gbCounterEntry.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTransTypeDescription;
        private System.Windows.Forms.Button btnSaveTransaction;
        private System.Windows.Forms.Button btnExitTransaction;
        private System.Windows.Forms.RadioButton rbNone;
        private System.Windows.Forms.RadioButton rbDropSafe;
        private System.Windows.Forms.RadioButton rbRecon;
        private System.Windows.Forms.GroupBox gbCounterEntry;
    }
}