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

namespace lab2_v6
{
    public partial class FormAdd : Form
    {
        private double r, alpha;
        public FormAdd()
        {
            InitializeComponent();
        }

        private void bt_ok_Click(object sender, EventArgs e)
        {
            if (txt_init.Text.Equals("") || txt_length.Text.Equals("") || txt_corner.Text.Equals(""))
            {
                lb_error.Text = "НЕЛЬЗЯ ОСТАВЛЯТЬ ПУСТЫЕ ПОЛЯ!!!";
                lb_error.Visible = true;
                TimerCallback clb = new TimerCallback(backText);
                System.Threading.Timer timer = new System.Threading.Timer(clb, null, 1000, 0);
            }
            else if (Convert.ToDouble(txt_corner.Text) == 0)
            {

            }
        }

        private void backText(object obj)
        {
            Invoke(new Action(() => lb_error.Visible = false));
            Invoke(new Action(() => lb_error.Text = ""));
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }   
}
