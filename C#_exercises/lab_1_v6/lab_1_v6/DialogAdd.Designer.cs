namespace lab_1_v6
{
    partial class DialogAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogAdd));
            this.bt_ok = new System.Windows.Forms.Button();
            this.bt_cancel = new System.Windows.Forms.Button();
            this.txtBx_surname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBx_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBx_phone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBx_birthday = new System.Windows.Forms.TextBox();
            this.lb_warning = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bt_ok
            // 
            this.bt_ok.Location = new System.Drawing.Point(36, 171);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(75, 23);
            this.bt_ok.TabIndex = 0;
            this.bt_ok.Text = "Ок";
            this.bt_ok.UseVisualStyleBackColor = true;
            this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
            // 
            // bt_cancel
            // 
            this.bt_cancel.Location = new System.Drawing.Point(288, 171);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.Size = new System.Drawing.Size(75, 23);
            this.bt_cancel.TabIndex = 1;
            this.bt_cancel.Text = "Отмена";
            this.bt_cancel.UseVisualStyleBackColor = true;
            this.bt_cancel.Click += new System.EventHandler(this.bt_cancel_Click);
            // 
            // txtBx_surname
            // 
            this.txtBx_surname.Location = new System.Drawing.Point(162, 25);
            this.txtBx_surname.Name = "txtBx_surname";
            this.txtBx_surname.Size = new System.Drawing.Size(201, 20);
            this.txtBx_surname.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(76, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Фамилия*:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(103, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Имя*:";
            // 
            // txtBx_name
            // 
            this.txtBx_name.Location = new System.Drawing.Point(162, 54);
            this.txtBx_name.Name = "txtBx_name";
            this.txtBx_name.Size = new System.Drawing.Size(201, 20);
            this.txtBx_name.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(80, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Телефон*:";
            // 
            // txtBx_phone
            // 
            this.txtBx_phone.Location = new System.Drawing.Point(162, 80);
            this.txtBx_phone.Name = "txtBx_phone";
            this.txtBx_phone.Size = new System.Drawing.Size(201, 20);
            this.txtBx_phone.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(50, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Дата рождения:";
            // 
            // txtBx_birthday
            // 
            this.txtBx_birthday.Location = new System.Drawing.Point(162, 109);
            this.txtBx_birthday.Name = "txtBx_birthday";
            this.txtBx_birthday.Size = new System.Drawing.Size(201, 20);
            this.txtBx_birthday.TabIndex = 8;
            // 
            // lb_warning
            // 
            this.lb_warning.AutoSize = true;
            this.lb_warning.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_warning.ForeColor = System.Drawing.Color.Red;
            this.lb_warning.Location = new System.Drawing.Point(33, 142);
            this.lb_warning.Name = "lb_warning";
            this.lb_warning.Size = new System.Drawing.Size(330, 16);
            this.lb_warning.TabIndex = 10;
            this.lb_warning.Text = "* - отмечены поля, обязательные для заполнения";
            // 
            // DialogAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(386, 206);
            this.Controls.Add(this.lb_warning);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBx_birthday);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBx_phone);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBx_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBx_surname);
            this.Controls.Add(this.bt_cancel);
            this.Controls.Add(this.bt_ok);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DialogAdd";
            this.Text = "Добавление записи";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_ok;
        private System.Windows.Forms.Button bt_cancel;
        private System.Windows.Forms.TextBox txtBx_surname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBx_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBx_phone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBx_birthday;
        private System.Windows.Forms.Label lb_warning;
    }
}