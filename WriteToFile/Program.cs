using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WriteToFile
{
    class Program
    {
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        [STAThread]
        static void Main()
        {
            string appName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

            using (Mutex mutex = new Mutex(true, appName, out bool isNewInstance))
            {
                if (!isNewInstance)
                {
                    IntPtr handle = FindWindow(null, "Write to FILE");
                    if (handle != IntPtr.Zero)
                    {
                        const int SW_SHOW = 5;
                        const int SW_RESTORE = 9;
                        const uint WM_SHOWWINDOW = 0x0018;
                        const int SW_PARENTOPENING = 3;

                        ShowWindow(handle, SW_RESTORE);
                        ShowWindow(handle, SW_SHOW);
                        // send WM_SHOWWINDOW message to toggle the visibility flag
                        SendMessage(handle, WM_SHOWWINDOW, IntPtr.Zero, new IntPtr(SW_PARENTOPENING));
                        SetForegroundWindow(handle);
                    }
                    return;
                }

                App app = new App
                {
                    MainWindow = new MainWindow()
                };
                app.MainWindow.Show();
                app.Run();
            }
        }
    }
}
