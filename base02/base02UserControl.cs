using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace base02
{
    public partial class base02UserControl : UserControl
    {
        private object mInstance = null;

        public object SetInstance
        {
            set { mInstance = value; }
        }


        private void MethodInfoDelegateFunc(string MethodName)
        {
            try
            {
                if (mInstance != null)
                {
                    MethodInfo method = mInstance.GetType().GetMethod(MethodName);
                    method.Invoke(mInstance, null);
                }
            }
            catch { }
        }
        protected void InvokeMethod(string MethodName)
        {
            this.BeginInvoke(new MethodInvoker( delegate() { MethodInfoDelegateFunc(MethodName); } ) );
        }

        
        private void MethodInfoParamsDelegateFunc(string MethodName, params object[] Params)
        {
            try
            {
                if (mInstance != null)
                {
                    MethodInfo method = mInstance.GetType().GetMethod(MethodName);
                    method.Invoke(mInstance, Params);
                }
            }
            catch { }
        }
        protected void InvokeMethod(string MethodName, params object[] Params)
        {
            this.BeginInvoke(new MethodInvoker(delegate() { MethodInfoParamsDelegateFunc(MethodName, Params); }));
        }


        public base02UserControl()
        {
            InitializeComponent();
        }

        private void base02UserControl_Load(object sender, EventArgs e)
        {
            //최초 한번 호출
        }

        public void InitLoadData()
        {
            textBox1.Text = "";
        }

        public void CallFunc_base02UserControl()
        {
            Console.WriteLine("CallFunc_base02UserControl");
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            InvokeMethod("CallBase02Func");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            object[] parameters = new object[2];
            parameters[0] = 11111;
            parameters[1] = "base02UserControl";
            InvokeMethod("CallBase02FuncParam", parameters);
        }

    }
}
