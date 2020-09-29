namespace lab_1_v6
{
    partial class Searching
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
            this.txtBx_name = new System.Windows.Forms.TextBox();
            this.txtBx_surname = new System.Windows.Forms.TextBox();
            this.bt_search = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_warning = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBx_name
            // 
            this.txtBx_name.Location = new System.Drawing.Point(77, 63);
            this.txtBx_name.Name = "txtBx_name";
            this.txtBx_name.Size = new System.Drawing.Size(201, 20);
            this.txtBx_name.TabIndex = 1;
            // 
            // txtBx_surname
            // 
            this.txtBx_surname.Location = new System.Drawing.Point(77, 28);
            this.txtBx_surname.Name = "txtBx_surname";
            this.txtBx_surname.Size = new System.Drawing.Size(201, 20);
            this.txtBx_surname.TabIndex = 0;
            // 
            // bt_search
            // 
            this.bt_search.Location = new System.Drawing.Point(112, 119);
            this.bt_search.Name = "bt_search";
            this.bt_search.Size = new System.Drawing.Size(66, 23);
            this.bt_search.TabIndex = 2;
            this.bt_search.Text = "Поиск";
            this.bt_search.UseVisualStyleBackColor = true;
            this.bt_search.Click += new System.EventHandler(this.bt_search_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Фамилия:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Имя";
            // 
            // lb_warning
            // 
            this.lb_warning.AutoSize = true;
            this.lb_warning.Location = new System.Drawing.Point(18, 86);
            this.lb_warning.Name = "lb_warning";
            this.lb_warning.Size = new System.Drawing.Size(0, 13);
            this.lb_warning.TabIndex = 8;
            this.lb_warning.Visible = false;
            // 
            // Searching
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 154);
            this.Controls.Add(this.lb_warning);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_search);
            this.Controls.Add(this.txtBx_surname);
            this.Controls.Add(this.txtBx_name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Searching";
            this.Text = "Searching";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBx_name;
        private System.Windows.Forms.TextBox txtBx_surname;
        private System.Windows.Forms.Button bt_search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_warning;
    }
}