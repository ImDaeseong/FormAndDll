using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace base01
{
    public partial class base01UserControl : UserControl
    {
        private object mInstance = null;

        public object SetInstance
        {
            set { mInstance = value; }
        }


        private delegate void MethodInfoDelegate(string MethodName);
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
            MethodInfoDelegate mDelegate = new MethodInfoDelegate(MethodInfoDelegateFunc);
            mDelegate.BeginInvoke(MethodName, null, null);
        }
        
        private delegate void MethodInfoParamsDelegate(string MethodName, params object[] Params);
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
            MethodInfoParamsDelegate mDelegate = new MethodInfoParamsDelegate(MethodInfoParamsDelegateFunc);
            mDelegate.BeginInvoke(MethodName, Params, null, null);
        }

      
        public base01UserControl()
        {
            InitializeComponent();
        }

        private void base01UserControl_Load(object sender, EventArgs e)
        {
            //최초 한번 호출
        }

        public void InitLoadData()
        {
            textBox1.Text = "";
        }

        public void CallFunc_base01UserControl()
        {
            Console.WriteLine("CallFunc_base01UserControl");
        }
             
        private void button1_Click(object sender, EventArgs e)
        {
            InvokeMethod("CallBase01Func");
        }
              
        private void button2_Click(object sender, EventArgs e)
        {
            object[] parameters = new object[2];
            parameters[0] = 11111;
            parameters[1] = "base01UserControl";       
            InvokeMethod("CallBase01FuncParam", parameters);            
        }
    }
}
