using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Capture
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

        }

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, KeyModifiers fsModifiers, Keys vk);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        const int HOTKEY_ID = 31197; //Any number to use to identify the hotkey instance

        private void NotifyTest_Resize(object sender, EventArgs e)
        {
            // 윈도우 상태가 Minimized일 경우
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
                this.ShowIcon = false;

                notifyIcon1.Visible = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RegisterHotKey(this.Handle, HOTKEY_ID, KeyModifiers.Control | KeyModifiers.Shift, Keys.N);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //핫키 해제
            UnregisterHotKey(this.Handle, HOTKEY_ID);
        }
        private void getKetEvent(object sender, KeyEventArgs e)
        {

            if (e.Control) // Ctrl-S Save
            {
                label1.Text = e.KeyCode.ToString();
            }

        }

        private void mainNotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            // Notify Icon을 클릭했을 시 일어나는 이벤트.
            this.Visible = true;
            this.ShowIcon = true;
            notifyIcon1.Visible = false;
        }                   


        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            Windows = 8
        }

        const int WM_HOTKEY = 0x0312;
        protected override void WndProc(ref Message message)
        {
            switch (message.Msg)
            {
                case WM_HOTKEY:
                    Keys key = (Keys)(((int)message.LParam >> 16) & 0xFFFF);
                    KeyModifiers modifier = (KeyModifiers)((int)message.LParam & 0xFFFF);
                    //MessageBox.Show("HotKey Pressed :" + modifier.ToString() + " " + key.ToString());

                    if ((KeyModifiers.Control | KeyModifiers.Shift) == modifier && Keys.N == key)
                    {
                        Process.Start("notepad.exe");
                    }

                    break;
            }
            base.WndProc(ref message);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 핫키 등록dwadwad
            UnregisterHotKey(this.Handle, HOTKEY_ID);
        }

      
    }









}
