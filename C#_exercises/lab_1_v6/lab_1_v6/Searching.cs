using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_1_v6
{
    public partial class Searching : Form
    {
        private Notebook notes;
        public Searching(Notebook notes)
        {
            InitializeComponent();
            txtBx_surname.Select();
            this.notes = notes;
        }

        private void bt_search_Click(object sender, EventArgs e)
        {
            if (txtBx_surname.Text.Length == 0 || txtBx_name.Text.Length == 0)
            {
                lb_warning.ForeColor = Color.Red;
                lb_warning.Text = "ВСЕ ПОЛЯ ДОЛЖНЫ БЫТЬ ЗАПОЛНЕНЫ!";
                lb_warning.Visible = true;
                TimerCallback tmclb = new TimerCallback(BackVisible);
                System.Threading.Timer tmp = new System.Threading.Timer(tmclb, null, 1000, 0);
                return;
            }
            int idx = notes.SearchBySurnameAndName(txtBx_surname.Text, txtBx_name.Text);
            if (idx < 0)
            {
                lb_warning.ForeColor = Color.Red;
                lb_warning.Text = "ЗАПИСЬ НЕ НАЙДЕНА :(";
                lb_warning.Visible = true;
                TimerCallback tmclb = new TimerCallback(BackVisible);
                System.Threading.Timer tmp = new System.Threading.Timer(tmclb, null, 1000, 0);
                return;
            }
            DialogAdd dlg = new DialogAdd(notes, false, idx);
            notes.removeNote(idx);
            dlg.ShowDialog();
            notes = dlg.GetNotes();
            Close();
        }

        private void BackVisible(object obj)
        {
            Invoke(new Action(() => lb_warning.Visible = false));
        }

        public Notebook GetNotes()
        {
            return notes;
        }
    }
}
