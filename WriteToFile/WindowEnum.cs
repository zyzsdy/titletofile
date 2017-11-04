using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WriteToFile
{
    public delegate bool EnumWindowsProc(int hWnd, int lParam);

    class WindowEnum
    {
        public static Dictionary<int, string> windows;

        [DllImport("user32.dll", EntryPoint = "IsWindow")]
        private static extern int IsWindow(int Hwnd);

        public static bool CheckWindow(int Hwnd)
        {
            if (IsWindow(Hwnd) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [DllImport("user32.dll")]
        private static extern int GetWindowTextLength(int hWnd);

        [DllImport("user32.dll")]
        private static extern int GetWindowTextLengthW(int hWnd);

        [DllImport("user32.dll")]
        public static extern int GetWindowText(int hwnd, StringBuilder Title, int lp);

        [DllImport("user32.dll")]
        public static extern int GetWindowTextW(int hwnd, StringBuilder Title, int lp);

        public static string GetTitle(int Hwnd)
        {
            int cTxtLen = GetWindowTextLength(Hwnd) + 1;
            StringBuilder sb = new StringBuilder(cTxtLen);
            GetWindowText(Hwnd, sb, cTxtLen);
            return sb.ToString();
        }
        public static string GetTitleW(int Hwnd)
        {
            int cTxtLen = GetWindowTextLengthW(Hwnd) + 1;
            StringBuilder sb = new StringBuilder(cTxtLen);
            GetWindowTextW(Hwnd, sb, cTxtLen);
            return sb.ToString();
        }

        [DllImport("user32.dll")]
        private static extern bool IsWindowVisible(int hWnd);

        [DllImport("user32.dll")]
        private static extern int EnumWindows(EnumWindowsProc ewp, int lParam);

        public static Dictionary<int, string> StartEnumWindows()
        {
            windows = new Dictionary<int, string>();
            EnumWindowsProc ewp = new EnumWindowsProc(ADA_enumWindowsProc);
            EnumWindows(ewp, 0);
            return windows;
        }
        public static bool ADA_enumWindowsProc(int hwnd, int lparam)
        {
            if (IsWindowVisible(hwnd))
            {
                string title = GetTitle(hwnd);
                if (title != null && title != "")
                    windows.Add(hwnd, title);
            }
            return true;
        }
    }
}
