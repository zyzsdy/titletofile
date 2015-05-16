using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int hwnd;

        private void fileread_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string filename = openFileDialog1.FileName;
            saveFileText.Text = filename;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 getpos = new Form2();
            getpos.ShowDialog();
            hwnd = getpos.hwnd;
            windowinfoText.Text = hwnd.ToString();
        }

        private void windowGet_Click(object sender, EventArgs e)
        {
            windowinfoText.Text = hwnd.ToString();
            if (Win32Api.isWindow(hwnd))
            {
                nowTitleText.Text = Win32Api.getTitle(hwnd);
            }
            else
            {
                MessageBox.Show("获取到的窗口无效。");
            }
        }

        private void mainproc_Tick(object sender, EventArgs e)
        {
            string nowTitle = Win32Api.getTitle(hwnd);
            nowTitleText.Text = nowTitle;
            UTF8Encoding utf8writer = new UTF8Encoding(false);
            StreamWriter swr = null;
            try
            {
                swr = new StreamWriter(saveFileText.Text, false, utf8writer);
                swr.Write(prefixStrText.Text + nowTitle + suffixStrText.Text);
            }
            catch (Exception expt)
            {

            }
            finally
            {
                swr.Close();
                swr.Dispose();
            }
        }

        private void STARTButton_Click(object sender, EventArgs e)
        {
            if (mainproc.Enabled)
            {
                mainproc.Stop();
                STARTButton.Text = "START";
            }
            else
            {
                mainproc.Start();
                STARTButton.Text = "STOP";
            }
        }
    }
}
