using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WriteToFile
{
    /// <summary>
    /// TitleSetting.xaml 的交互逻辑
    /// </summary>
    public partial class TitleSetting : Window
    {
        public int SelectHwnd;
        Config config;

        public TitleSetting(Config cfg)
        {
            InitializeComponent();
            config = cfg;
        }

        private void RefreshEnumWindowButton_Click(object sender, RoutedEventArgs e)
        {
            windowList.Items.Clear();
            Dictionary<int, string> windows = WindowEnum.StartEnumWindows();
            if(windows != null)
            {
                foreach(KeyValuePair<int, string> w in windows)
                {
                    windowList.Items.Add(w);
                }
            }
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            var obj = windowList.SelectedItem;
            if(obj == null)
            {
                MessageBox.Show("请选择需要捕获的窗口。", "没有选择", MessageBoxButton.OK, MessageBoxImage.Question);
                return;
            }
            SelectHwnd = ((KeyValuePair<int, string>)obj).Key;
            DialogResult = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(config.TitlePrefix != null)
            {
                PrefixTextBox.Text = config.TitlePrefix;
            }
            if(config.TitleSuffix != null)
            {
                SuffixTextBox.Text = config.TitleSuffix;
            }
        }

        private void PrefixTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(config != null)
            {
                config.TitlePrefix = PrefixTextBox.Text;
            }
        }

        private void SuffixTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(config != null)
            {
                config.TitleSuffix = SuffixTextBox.Text;
            }
        }
    }
}
