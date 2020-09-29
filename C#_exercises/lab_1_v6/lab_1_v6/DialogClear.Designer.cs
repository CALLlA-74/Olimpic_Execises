namespace lab_1_v6
{
    partial class DialogClear
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogClear));
            this.lb_warning = new System.Windows.Forms.Label();
            this.bt_yes = new System.Windows.Forms.Button();
            this.bt_no = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_warning
            // 
            this.lb_warning.AutoSize = true;
            this.lb_warning.Location = new System.Drawing.Point(40, 36);
            this.lb_warning.Name = "lb_warning";
            this.lb_warning.Size = new System.Drawing.Size(0, 13);
            this.lb_warning.TabIndex = 0;
            // 
            // bt_yes
            // 
            this.bt_yes.Location = new System.Drawing.Point(89, 91);
            this.bt_yes.Name = "bt_yes";
            this.bt_yes.Size = new System.Drawing.Size(75, 23);
            this.bt_yes.TabIndex = 1;
            this.bt_yes.Text = "Да";
            this.bt_yes.UseVisualStyleBackColor = true;
            this.bt_yes.Click += new System.EventHandler(this.bt_yes_Click);
            // 
            // bt_no
            // 
            this.bt_no.Location = new System.Drawing.Point(268, 91);
            this.bt_no.Name = "bt_no";
            this.bt_no.Size = new System.Drawing.Size(75, 23);
            this.bt_no.TabIndex = 2;
            this.bt_no.Text = "Нет";
            this.bt_no.UseVisualStyleBackColor = true;
            this.bt_no.Click += new System.EventHandler(this.bt_no_Click);
            // 
            // DialogClear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 126);
            this.Controls.Add(this.bt_no);
            this.Controls.Add(this.bt_yes);
            this.Controls.Add(this.lb_warning);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DialogClear";
            this.Text = "DialogClear";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_warning;
        private System.Windows.Forms.Button bt_yes;
        private System.Windows.Forms.Button bt_no;
    }
}