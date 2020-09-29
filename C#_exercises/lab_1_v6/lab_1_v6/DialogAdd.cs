using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace lab_1_v6
{
    public partial class DialogAdd : Form
    {
        private Notebook notes;
        private bool isAdd;
        public DialogAdd(Notebook notes, bool isAdd, int pos = 0)
        {
            this.notes = notes;
            this.isAdd = isAdd;
            InitializeComponent();
            if (isAdd) Text = "Добавление записи";
            else
            {
                Text = "Редактировние записи";
                txtBx_surname.Text = notes.GetSurnameByPos(pos);
                txtBx_name.Text = notes.GetNameByPos(pos);
                txtBx_phone.Text = notes.GetPhoneByPos(pos);
                txtBx_birthday.Text = notes.GetDateByPos(pos);
            }
            txtBx_surname.Select();
            SetIcon();
        }

        private void SetIcon()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogAdd));
            if (isAdd) Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            else
            {
                Icon icon = new Icon("editor.ico"); // Никольская, Иванов
                Icon = icon;
            }
        }

        private void bt_ok_Click(object sender, EventArgs e)
        {
            if (txtBx_surname.Text.Equals("") || txtBx_name.Text.Equals("") || txtBx_phone.Text.Equals(""))
            {
                Text = "Заполните все поля с * !!!";
                BackColor = Color.Red;
                TimerCallback clb = new TimerCallback(backText);
                System.Threading.Timer tmp = new System.Threading.Timer(clb, null, 500, 0);
                return;
            }
            //nwprsn = new NewPerson(txtBx_surname.Text, txtBx_name.Text, txtBx_phone.Text, txtBx_birthday.Text);
            if (notes.SearchBySurnameAndName(txtBx_surname.Text, txtBx_name.Text) < 0)
            {
                notes.Add(txtBx_surname.Text, txtBx_name.Text, txtBx_phone.Text, txtBx_birthday.Text);
                Close();
            }
            else
            {
                lb_warning.Text = "ТАКАЯ ЗАПИСЬ УЖЕ ЕСТЬ!!!";
                TimerCallback clb = new TimerCallback(backLabel);
                System.Threading.Timer tmp = new System.Threading.Timer(clb, null, 500, 0);
            }
        }

        private void backText(object obj)
        {
            Invoke(new Action(() => Text = "Добавление записи"));
            Invoke(new Action(() => BackColor = SystemColors.Control));
        }

        private void backLabel(object obj)
        {
            Invoke(new Action(() => lb_warning.Text = "* - отмечены поля, обязательные для заполнения"));
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public Notebook GetNotes()
        {
            return notes;
        }
    }
}
