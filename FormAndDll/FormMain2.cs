using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using base01;
using base02;
using base03;

namespace FormAndDll
{  
    public partial class FormMain2 : Form
    {
        static FormMain2 sInstance = null;
        public static FormMain2 Instance { get { return sInstance; } }
        
        public void InitBaseDllList()
        {
            base01UserControl base01 = new base01UserControl();
            base01.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            base01.Location = new System.Drawing.Point(0, 0);
            base01.Size = new System.Drawing.Size(500, 400);
            base01.Dock = DockStyle.Fill;
            base01.Name = "base01UserControl";
            base01.TabIndex = 0;            
            base01.SetInstance = this;

            base02UserControl base02 = new base02UserControl();
            base02.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            base02.Location = new System.Drawing.Point(0, 0);
            base02.Size = new System.Drawing.Size(500, 400);
            base02.Dock = DockStyle.Fill;
            base02.Name = "base02UserControl";
            base02.TabIndex = 0;
            base02.SetInstance = this;

            base03UserControl base03 = new base03UserControl();
            base03.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            base03.Location = new System.Drawing.Point(0, 0);
            base03.Size = new System.Drawing.Size(500, 400);
            base03.Dock = DockStyle.Fill;
            base03.Name = "base03UserControl";
            base03.TabIndex = 0;
            base03.SetInstance = this;

            dllUserControl1.UserCollection.Add("base01UserControl", base01);
            dllUserControl1.UserCollection.Add("base02UserControl", base02);
            dllUserControl1.UserCollection.Add("base03UserControl", base03);
        }       

        public FormMain2()
        {
            InitializeComponent();

            sInstance = this;
        }

        private void FormMain2_Load(object sender, EventArgs e)
        {
            InitBaseDllList();

            dllUserControl1.setActiveUserControl("base01UserControl");
        }

        public void CallForm2()
        {
            Console.WriteLine("CallForm2");
        }

        public void CallUserControl1()
        {
            Console.WriteLine("CallUserControl1");
        }

        public void CallClass1()
        {
            Console.WriteLine("CallClass1");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show(this);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Class1 c = new Class1();
            c.CallMainFunc();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((base01UserControl)dllUserControl1.setActiveUserControl("base01UserControl")).InitLoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ((base02UserControl)dllUserControl1.setActiveUserControl("base02UserControl")).InitLoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ((base03UserControl)dllUserControl1.setActiveUserControl("base03UserControl")).InitLoadData();
        }


        public void CallBase01Func()
        {
            Console.WriteLine("CallBase01Func");
        }

        public void CallBase01FuncParam(int nParam, string sParam)
        {
            Console.WriteLine("CallBase01FuncParam:" + nParam.ToString() + "  " + sParam);
        }

        public void CallBase02Func()
        {
            Console.WriteLine("CallBase02Func");
        }

        public void CallBase02FuncParam(int nParam, string sParam)
        {
            Console.WriteLine("CallBase02FuncParam:" + nParam.ToString() + "  " + sParam);
        }

        public void CallBase03Func()
        {
            Console.WriteLine("CallBase03Func");
        }

        public void CallBase03FuncParam(int nParam, string sParam)
        {
            Console.WriteLine("CallBase03FuncParam:" + nParam.ToString() + "  " + sParam);
        }

    }

}
