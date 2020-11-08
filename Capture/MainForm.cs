using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Capture
{
    public partial class MainForm : Form
    {   

        public MainForm()
        {
            InitializeComponent();
            MainFormInit();
        }
        private void MainFormInit()
        {

            //RegisterHotKey to Window
            RegisterHotKey();

            // main form invisible
            thisForminvisible();

            
        }
        private void RegisterHotKey()
        {
            RegisterHotKey(this.Handle, HOTKEY_ID, KeyModifiers.Control | KeyModifiers.Windows, Keys.A);
        }

        private void UnRegisterHotKey()
        {
            UnregisterHotKey(this.Handle, HOTKEY_ID);
        }
        private void thisForminvisible()
        {
            Color visibleColor = Color.FromArgb(1, 255, 255);
            this.BackColor = visibleColor;
            this.TransparencyKey = visibleColor;
        }               
     


        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, KeyModifiers fsModifiers, Keys vk);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            Windows = 8
        }

        const int HOTKEY_ID = 31197; //Any number to use to identify the hotkey instance
        const int WM_HOTKEY = 0x0312;


        // catch message And run code
        protected override void WndProc(ref Message message)
        {
            switch (message.Msg)
            {
                case WM_HOTKEY:
                    captureAllDisplay();
                    break;
            }
            base.WndProc(ref message);
        }

        private void captureAllDisplay()
        {
            Bitmap btMain;
            //Total Screen Capture
            btMain = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height); using (Graphics g = Graphics.FromImage(btMain))
            {
                g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, btMain.Size, CopyPixelOperation.SourceCopy);
                //Picture Box Display 
                MainFormCaptureBox.Size = btMain.Size;
                MainFormCaptureBox.Image = btMain;
            }
            
        }
        private void mainNotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            // Notify Icon을 클릭했을 시 일어나는 이벤트.
            this.Visible = true;
            this.ShowIcon = true;
            notifyIcon1.Visible = false;
        }
        
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

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        bool isMouseDonw = false;
        private void MainFormCaptureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if(isMouseDonw)
            {
                label1.Text = e.X + "," + e.Y;
            }
        }

        private void MainFormCaptureBox_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDonw = true;
        }

        private void MainFormCaptureBox_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDonw = false;
        }
    }

      
}










