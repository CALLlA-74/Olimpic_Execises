using System;
using System.Windows.Forms;

namespace lab_1_v6
{
    public partial class wnd_main : Form
    {
        private Notebook notes = new Notebook();
        public wnd_main()
        {
            InitializeComponent();
            ShowNotes();
        }

        private void ShowNotes()
        {
            listViewMain.Items.Clear();
            for (int i = 0; i < notes.GetCount(); i++)
                listViewMain.Items.Add(new ListViewItem().Text = MakeText(i), i);
            listViewMain.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        private string MakeText(int idx)
        {
            return notes.GetSurnameByPos(idx) + " " + notes.GetNameByPos(idx) + " " + notes.GetPhoneByPos(idx) + " "
                + (notes.GetDateByPos(idx) == null || notes.GetDateByPos(idx).Equals("") ? null : notes.GetDateByPos(idx));
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            DialogAdd wndAdd = new DialogAdd(notes, true);
            wndAdd.ShowDialog();
            ShowNotes();
        }

        private void bt_clearAll_Click(object sender, EventArgs e)
        {
            DialogClear wndClear = new DialogClear(true);
            wndClear.ShowDialog();
            if (wndClear.IsClearing()) notes.clearList();
            ShowNotes();
        }

        private void bt_search_Click(object sender, EventArgs e)
        {
            Searching srch = new Searching(notes);
            srch.ShowDialog();
            notes = srch.GetNotes();
            ShowNotes();
        }
    }
}
