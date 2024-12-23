namespace Formatter
{
    partial class ControlForCopy
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTextForCopy = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTextForCopy
            // 
            this.lblTextForCopy.AutoSize = true;
            this.lblTextForCopy.Location = new System.Drawing.Point(29, 14);
            this.lblTextForCopy.Name = "lblTextForCopy";
            this.lblTextForCopy.Size = new System.Drawing.Size(35, 13);
            this.lblTextForCopy.TabIndex = 0;
            this.lblTextForCopy.Text = "label1";
            // 
            // btnCopy
            // 
            this.btnCopy.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCopy.Image = global::Formatter.Properties.Resources.copy_two_paper_sheets_interface_symbol;
            this.btnCopy.Location = new System.Drawing.Point(450, 0);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(35, 40);
            this.btnCopy.TabIndex = 1;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // ControlForCopy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.lblTextForCopy);
            this.Name = "ControlForCopy";
            this.Size = new System.Drawing.Size(485, 40);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTextForCopy;
        private System.Windows.Forms.Button btnCopy;
    }
}
