using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace base03
{
    public partial class base03UserControl : UserControl
    {
        private object mInstance = null;

        public object SetInstance
        {
            set { mInstance = value; }
        }

        protected void InvokeMethod(string MethodName)
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

        protected void InvokeMethod(string MethodName, params object[] Params)
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

        public base03UserControl()
        {
            InitializeComponent();
        }

        private void base03UserControl_Load(object sender, EventArgs e)
        {
            //최초 한번 호출
        }

        public void InitLoadData()
        {
            textBox1.Text = "";
        }

        public void CallFunc_base03UserControl()
        {
            Console.WriteLine("CallFunc_base03UserControl");
        }
                
        private void button1_Click(object sender, EventArgs e)
        {
            InvokeMethod("CallBase03Func");
        }
               
        private void button2_Click(object sender, EventArgs e)
        {
            object[] parameters = new object[2];
            parameters[0] = 11111;
            parameters[1] = "base03UserControl";
            InvokeMethod("CallBase03FuncParam", parameters);
        }

    }
}
