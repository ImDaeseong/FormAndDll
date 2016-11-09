using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormAndDll
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //FormMain1.Instance.CallForm2();
            //FormMain2.Instance.CallForm2();
            FormMain3.Instance.CallForm2();
            //Program.MainForm.CallForm2();
        }
    }
}
