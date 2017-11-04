using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;
using WinForms = System.Windows.Forms;

namespace WriteToFile
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timeTimer, titleTimer; //定时器
        Config config;
        TitleSetting titleSetting;

        private WinForms.NotifyIcon notifyIcon; //通知图标
        private WinForms.ContextMenu contextMenu; //上下文菜单

        public int TargetHwnd { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            if(timeTimer == null)
            {
                timeTimer = new DispatcherTimer
                {
                    Interval = TimeSpan.FromMilliseconds(999)
                };
                timeTimer.Tick += Timer_Tick;
            }
            if(titleTimer == null)
            {
                titleTimer = new DispatcherTimer
                {
                    Interval = TimeSpan.FromMilliseconds(1200)
                };
                titleTimer.Tick += TitleTimer_Tick;
            }
            if(config == null)
            {
                config = new Config();
            }

            contextMenu = new WinForms.ContextMenu();
            WinForms.MenuItem openWindow = new WinForms.MenuItem { Text = "显示" };
            WinForms.MenuItem closeApp = new WinForms.MenuItem { Text = "退出" };
            System.ComponentModel.IContainer container = new System.ComponentModel.Container();

            WinForms.MenuItem[] menu = new WinForms.MenuItem[]
            {
                openWindow,
                closeApp
            };
            contextMenu.MenuItems.AddRange(menu);
            openWindow.Click += OpenWindow_Click;
            closeApp.Click += CloseApp_Click;

            Stream iconStream = GetType().Assembly.GetManifestResourceStream("WriteToFile.icon.ico");

            notifyIcon = new WinForms.NotifyIcon(container)
            {
                Icon = new System.Drawing.Icon(iconStream),
                Text = "WriteToFile 正在运行",
                Visible = true
            };
            notifyIcon.MouseDoubleClick += NotifyIcon_MouseDoubleClick;
            notifyIcon.ContextMenu = contextMenu;
        }

        private void TitleTimer_Tick(object sender, EventArgs e)
        {
            string nowTitle = WindowEnum.GetTitle(TargetHwnd);
            string waitToSave = config.TitlePrefix + nowTitle + config.TitleSuffix;

            TitlePerview.Text = waitToSave;
            UTF8Encoding utf8writer = new UTF8Encoding(false);
            StreamWriter swr = null;
            try
            {
                swr = new StreamWriter(config.TitleSaveLocation, false, utf8writer);
                swr.Write(waitToSave);
            }
            catch
            {
                MessageBox.Show("写入目录不正确。", "出现问题", MessageBoxButton.OK, MessageBoxImage.Error);
                timeTimer.Stop();
                SwitchTimeToFile.IsChecked = false;
            }
            finally
            {
                swr?.Close();
                swr?.Dispose();
            }
        }

        private void NotifyIcon_MouseDoubleClick(object sender, WinForms.MouseEventArgs e)
        {
            ShowWindow();
        }

        private void ShowWindow()
        {
            Show();
        }

        private void CloseApp_Click(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OpenWindow_Click(object sender, EventArgs e)
        {
            ShowWindow();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            string time = "";
            try
            {
                time = DateTime.Now.ToString(config.TimeFormatString);
                TimePerview.Text = time;
            }
            catch
            {
                MessageBox.Show("时间格式化字符串不正确。", "出现问题", MessageBoxButton.OK, MessageBoxImage.Error);
                timeTimer.Stop();
                SwitchTimeToFile.IsChecked = false;
            }
            //存入文件
            UTF8Encoding utf8Writer = new UTF8Encoding(false);
            StreamWriter swr = null;

            try
            {
                swr = new StreamWriter(config.TimeSaveLocation, false, utf8Writer);
                swr.Write(time);
            }
            catch
            {
                MessageBox.Show("写入目录不正确。", "出现问题", MessageBoxButton.OK, MessageBoxImage.Error);
                timeTimer.Stop();
                SwitchTimeToFile.IsChecked = false;
            }
            finally
            {
                swr?.Close();
                swr?.Dispose();
            }
            
        }

        private void SwitchTimeToFile_Checked(object sender, RoutedEventArgs e)
        {
            //保存当前配置
            config.IsWriteTime = true;
            config.TimeFormatString = TimeFormatBox.Text;
            config.TimeSaveLocation = SaveDirBox.Text;
            if (!timeTimer.IsEnabled)
            {
                TimeFormatBox.IsEnabled = false;
                SaveDirBox.IsEnabled = false;
                OpenSaveDirButton.IsEnabled = false;
                timeTimer.Start();
            }
        }

        private void SwitchTimeToFile_Unchecked(object sender, RoutedEventArgs e)
        {
            config.IsWriteTime = false;
            if (timeTimer.IsEnabled)
            {
                timeTimer.Stop();
            }
            TimeFormatBox.IsEnabled = true;
            SaveDirBox.IsEnabled = true;
            OpenSaveDirButton.IsEnabled = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //读取配置并更新界面
            if(config.TimeFormatString != null)
            {
                TimeFormatBox.Text = config.TimeFormatString;
            }
            if(config.TimeSaveLocation != null)
            {
                SaveDirBox.Text = config.TimeSaveLocation;
            }
            SwitchTimeToFile.IsChecked = config.IsWriteTime;
            if(config.TitleSaveLocation != null)
            {
                SaveTitlePath.Text = config.TitleSaveLocation;
            }
        }

        private void OpenSaveDirButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog { FileName = "time.txt" };
            if (sfd.ShowDialog() == true)
            {
                SaveDirBox.Text = sfd.FileName;
            }
        }

        private void SaveDirBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(config != null)
            {
                config.TimeSaveLocation = SaveDirBox.Text;
            }
        }

        private void TimeFormatBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(config != null)
            {
                config.TimeFormatString = TimeFormatBox.Text;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void OpenSaveTitleButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog { FileName = "title.txt" };
            if (sfd.ShowDialog() == true)
            {
                SaveTitlePath.Text = sfd.FileName;
            }
        }

        private void SaveTitlePath_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (config != null)
            {
                config.TitleSaveLocation = SaveTitlePath.Text;
            }
        }

        private void SwitchTitleToFile_Checked(object sender, RoutedEventArgs e)
        {
            config.TitleSaveLocation = SaveTitlePath.Text;
            if (!WindowEnum.CheckWindow(TargetHwnd))
            {
                MessageBox.Show("窗口句柄无效！", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                SwitchTitleToFile.IsChecked = false;
                return;
            }
            if (!titleTimer.IsEnabled)
            {
                StartTitleSettingButton.IsEnabled = false;
                SaveTitlePath.IsEnabled = false;
                OpenSaveTitleButton.IsEnabled = false;
                titleTimer.Start();
            }
            
        }

        private void SwitchTitleToFile_Unchecked(object sender, RoutedEventArgs e)
        {
            if (titleTimer.IsEnabled)
            {
                titleTimer.Stop();
            }
            StartTitleSettingButton.IsEnabled = true;
            SaveTitlePath.IsEnabled = true;
            OpenSaveTitleButton.IsEnabled = true;
        }

        private void StartTitleSettingButton_Click(object sender, RoutedEventArgs e)
        {
            titleSetting = new TitleSetting(config);
            if (titleSetting.ShowDialog() == true)
            {
                TargetHwnd = titleSetting.SelectHwnd;
                WindowHandle.Text = TargetHwnd.ToString();
            }
        }
    }
}
