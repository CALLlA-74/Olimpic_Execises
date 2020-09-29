using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_1_v6
{
    public partial class DialogClear : Form
    {
        private bool isAll, isClearing = false;
        public DialogClear(bool isAll)
        {
            this.isAll = isAll;
            InitializeComponent();
            if (isAll) lb_warning.Text = "Вы действительно хотите очистить записную книжку?";
            else lb_warning.Text = "Вы действительно хотите удалить эту запись?";
        }

        private void bt_yes_Click(object sender, EventArgs e)
        {
            isClearing = true;
            Close();
        }

        private void bt_no_Click(object sender, EventArgs e)
        {
            Close();
        }

        public bool IsClearing()
        {
            return isClearing;
        }
    }
}
