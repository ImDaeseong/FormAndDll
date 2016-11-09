using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FormAndDll
{
    static class Program
    {
        //static FormMain1 _mainForm1 = null;
        //public static FormMain1 MainForm
        //{
        //    get { return _mainForm1; }
        //}

        //static FormMain2 _mainForm2 = null;
        //public static FormMain2 MainForm
        //{
        //    get { return _mainForm2; }
        //}

        //static FormMain3 _mainForm3 = null;
        //public static FormMain3 MainForm
        //{
        //    get { return _mainForm3; }
        //}

        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormMain1());
            //Application.Run(new FormMain2());
            Application.Run(new FormMain3());
            //Application.Run(_mainForm1 = new FormMain1());
            //Application.Run(_mainForm2 = new FormMain2());
            //Application.Run(_mainForm3 = new FormMain3());
        }
    }
}
