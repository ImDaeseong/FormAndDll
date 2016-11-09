using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormAndDll
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            //error
            //Form1.Instance.CallUserControl1();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //FormMain1.Instance.CallUserControl1();
            //FormMain2.Instance.CallUserControl1();
            FormMain3.Instance.CallUserControl1();
            //Program.MainForm.CallUserControl1();
        }
    }
}
