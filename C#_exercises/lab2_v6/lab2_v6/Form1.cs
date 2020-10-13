using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2_v6
{
    public partial class form_main : Form
    {
        public form_main()
        {
            InitializeComponent();
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            FormAdd addVector = new FormAdd();
            addVector.ShowDialog();
        }
    }
}
