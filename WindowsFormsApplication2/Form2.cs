using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public int hwnd;

        private void button1_Click(object sender, EventArgs e)
        {
            Object obj = windowList.SelectedItem;
            if (obj == null)
            {
                MessageBox.Show("未选中任何项目！");
                return;
            }
            KeyValuePair<int, string> selected = (KeyValuePair<int, string>)obj;
            hwnd = selected.Key;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Win32Api.enumWindows();
            MessageBox.Show("获取成功，请点击“刷新”按钮。");
        }

        private Dictionary<int, string> windows;
        private void button3_Click(object sender, EventArgs e)
        {
            windowList.Items.Clear();
            windows = Win32Api.windows;
            if(windows != null)
            foreach (KeyValuePair<int, string> w in windows)
            {
                windowList.Items.Add(w);
            }
        }
    }
}
