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
    public partial class DllUserControl : UserControl
    {
        private IDictionary<String, UserControl> itemDic;
        private String activeKey;
        private UserControl activeControl;

        public DllUserControl()
        {
            itemDic = new Dictionary<String, UserControl>();

            InitializeComponent();
        }

        public IDictionary<String, UserControl> UserCollection
        {
            get { return this.itemDic; }
        }

        public UserControl setActiveUserControl(String key)
        {
            UserControl userdll = this.itemDic[key];
            if (userdll != null)
            {
                if (this.activeControl != null)
                {                    
                    this.Controls.Remove(this.activeControl);
                }
                this.activeKey = key;
                this.activeControl = userdll;
                this.Controls.Add(userdll);
                userdll.Dock = DockStyle.Fill;
            }
            return userdll;
        }

        public String ActiveKey
        {
            get { return this.activeKey; }
        }

        public UserControl ActiveUserControl
        {
            get { return this.activeControl; }
        }

    }

}
