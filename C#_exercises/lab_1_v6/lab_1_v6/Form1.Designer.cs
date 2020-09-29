using System.Security.Principal;
using System.Windows.Forms;
using System.Drawing;

namespace lab_1_v6
{
    partial class wnd_main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wnd_main));
            this.listViewMain = new System.Windows.Forms.ListView();
            this.bt_add = new System.Windows.Forms.Button();
            this.bt_clearAll = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.bt_search = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // listViewMain
            // 
            this.listViewMain.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listViewMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.listViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewMain.FullRowSelect = true;
            this.listViewMain.GridLines = true;
            this.listViewMain.HideSelection = false;
            this.listViewMain.Location = new System.Drawing.Point(0, 0);
            this.listViewMain.Name = "listViewMain";
            this.listViewMain.Size = new System.Drawing.Size(667, 437);
            this.listViewMain.TabIndex = 0;
            this.listViewMain.TileSize = new System.Drawing.Size(671, 40);
            this.listViewMain.UseCompatibleStateImageBehavior = false;
            this.listViewMain.View = System.Windows.Forms.View.SmallIcon;
            //this.listViewMain.SelectedIndexChanged += new System.EventHandler(this.listViewMain_SelectedIndexChanged);
            // 
            // bt_add
            // 
            this.bt_add.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_add.Location = new System.Drawing.Point(12, 385);
            this.bt_add.Name = "bt_add";
            this.bt_add.Size = new System.Drawing.Size(184, 40);
            this.bt_add.TabIndex = 1;
            this.bt_add.Text = "Добавить запись";
            this.bt_add.UseVisualStyleBackColor = false;
            this.bt_add.Click += new System.EventHandler(this.bt_add_Click);
            // 
            // bt_clearAll
            // 
            this.bt_clearAll.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_clearAll.Location = new System.Drawing.Point(471, 385);
            this.bt_clearAll.Name = "bt_clearAll";
            this.bt_clearAll.Size = new System.Drawing.Size(184, 40);
            this.bt_clearAll.TabIndex = 2;
            this.bt_clearAll.Text = "Очистить все записи";
            this.bt_clearAll.UseVisualStyleBackColor = false;
            this.bt_clearAll.Click += new System.EventHandler(this.bt_clearAll_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // bt_search
            // 
            this.bt_search.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bt_search.Location = new System.Drawing.Point(247, 385);
            this.bt_search.Name = "bt_search";
            this.bt_search.Size = new System.Drawing.Size(184, 40);
            this.bt_search.TabIndex = 3;
            this.bt_search.Text = "Поиск";
            this.bt_search.UseVisualStyleBackColor = false;
            this.bt_search.Click += new System.EventHandler(this.bt_search_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.ImageLocation = "C:\\Users\\CALLlA-74\\source\\repos\\lab_1_v6\\lab_1_v6\\Resources\\magnifying-glass-comp" +
    "uter-icons-magnification-loupe.png";
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(293, 398);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(18, 18);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.ImageLocation = "C:\\Users\\CALLlA-74\\source\\repos\\lab_1_v6\\lab_1_v6\\Resources\\add.png";
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(32, 398);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(18, 18);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.ImageLocation = "C:\\Users\\CALLlA-74\\source\\repos\\lab_1_v6\\lab_1_v6\\Resources\\clear.png";
            this.pictureBox3.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.InitialImage")));
            this.pictureBox3.Location = new System.Drawing.Point(484, 398);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(18, 18);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // wnd_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(667, 437);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bt_search);
            this.Controls.Add(this.bt_clearAll);
            this.Controls.Add(this.bt_add);
            this.Controls.Add(this.listViewMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "wnd_main";
            this.Text = "Записная книжка";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewMain;
        private System.Windows.Forms.Button bt_add;
        private System.Windows.Forms.Button bt_clearAll;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button bt_search;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private PictureBox pictureBox3;
    }
}

