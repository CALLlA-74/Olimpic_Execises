namespace lab2_v6
{
    partial class form_main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.bt_add = new System.Windows.Forms.Button();
            this.lw_vectors = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // bt_add
            // 
            this.bt_add.Location = new System.Drawing.Point(63, 408);
            this.bt_add.Name = "bt_add";
            this.bt_add.Size = new System.Drawing.Size(140, 30);
            this.bt_add.TabIndex = 0;
            this.bt_add.Text = "Добавить вектор";
            this.bt_add.UseVisualStyleBackColor = true;
            this.bt_add.Click += new System.EventHandler(this.bt_add_Click);
            // 
            // lw_vectors
            // 
            this.lw_vectors.HideSelection = false;
            this.lw_vectors.Location = new System.Drawing.Point(0, 0);
            this.lw_vectors.Name = "lw_vectors";
            this.lw_vectors.Size = new System.Drawing.Size(800, 402);
            this.lw_vectors.TabIndex = 1;
            this.lw_vectors.UseCompatibleStateImageBehavior = false;
            // 
            // form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lw_vectors);
            this.Controls.Add(this.bt_add);
            this.Name = "form_main";
            this.Text = "Vector";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_add;
        private System.Windows.Forms.ListView lw_vectors;
    }
}

