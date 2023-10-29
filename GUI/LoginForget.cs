using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class LoginForget : Form
    {
        public LoginForget()
        {
            InitializeComponent();
            txtLFSDT.Text = Login.SDT;
        }

        private void btCloseLoginForget_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}