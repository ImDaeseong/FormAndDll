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
    public partial class FormMain1 : Form
    {
        static FormMain1 sInstance = null;
        public static FormMain1 Instance { get { return sInstance; } }


        Dictionary<string, UserControl> mUserControlList = new Dictionary<string, UserControl>();
        UserControl mActiveUserControl = null;
        
        UserControl InitUserControl(UserControl Controldll, string name)
        {
            UserControl userControl = Controldll;
            userControl.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            userControl.Location = new System.Drawing.Point(0, 0);
            userControl.Size = new System.Drawing.Size(500, 400);
            userControl.Dock = DockStyle.Fill;
            userControl.Name = name;
            userControl.TabIndex = 0;
            userControl.Hide();            
            panel4.Controls.Add(userControl);
            return Controldll;
        }

        public void InitBaseDllList()
        {
            base01UserControl base01 = new base01UserControl();
            base01.SetInstance = this;

            base02UserControl base02 = new base02UserControl();
            base02.SetInstance = this;

            base03UserControl base03 = new base03UserControl();
            base03.SetInstance = this;

            mUserControlList.Add("base01UserControl", InitUserControl(base01, "base01UserControl"));
            mUserControlList.Add("base02UserControl", InitUserControl(base02, "base02UserControl"));
            mUserControlList.Add("base03UserControl", InitUserControl(base03, "base03UserControl"));
        }

        public UserControl SwitchUserControl(string name)
        {
            if (mActiveUserControl != null)
            {
                mActiveUserControl.Hide();
            }

            if (mUserControlList.ContainsKey(name))
                mActiveUserControl = mUserControlList[name];
            else
                mActiveUserControl = null;

            if (mActiveUserControl != null)
            {
                mActiveUserControl.Show();
            }
            return mActiveUserControl;
        }
                
        public UserControl GetUserControl(string name)
        {
            if (mUserControlList.ContainsKey(name))
                return mUserControlList[name];
            else
                return null;
        }
               

        public FormMain1()
        {
            InitializeComponent();

            sInstance = this;
        }

        private void FormMain1_Load(object sender, EventArgs e)
        {
            InitBaseDllList();

            GetUserControl("base01UserControl");
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
            ((base01UserControl)SwitchUserControl("base01UserControl")).InitLoadData();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            ((base02UserControl)SwitchUserControl("base02UserControl")).InitLoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ((base03UserControl)SwitchUserControl("base03UserControl")).InitLoadData();
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
