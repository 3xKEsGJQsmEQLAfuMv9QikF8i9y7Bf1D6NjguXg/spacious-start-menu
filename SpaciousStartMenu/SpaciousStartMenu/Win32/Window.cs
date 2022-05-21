using System;
using System.Runtime.InteropServices;

namespace SpaciousStartMenu.Win32
{
    internal class Window
    {
        public const uint SW_SHOWMAXIMIZED = 3;

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, uint flags);

        public static void ActivateWindow(IntPtr hWnd)
        {
            ShowWindow(hWnd, SW_SHOWMAXIMIZED);
            SetForegroundWindow(hWnd);
        }

    }
}
