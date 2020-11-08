using System;
using System.Runtime.InteropServices;
using System.Text;



namespace MessageSender

{

    public class Win32API

    {
        public const int WM_COPYDATA = 0x004A;

        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public uint cbData;

            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;

        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, ref Win32API.COPYDATASTRUCT lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, StringBuilder lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, [MarshalAs(UnmanagedType.LPStr)] string lParam);

        [DllImport("user32.dll", EntryPoint = "SendMessageW")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, uint Msg, IntPtr wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern IntPtr SendMessage(HandleRef hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow(string strClassName, string strWindowName);



    }

}