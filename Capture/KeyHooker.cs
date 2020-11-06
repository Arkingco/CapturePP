using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Capture
{
    class KeyHooker : Form
    {
        

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

        public KeyHooker(IntPtr hWnd)
        {
                            
        }

        private void RegisterHotKey()
        {

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
            // 핫키 등록

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //핫키 해제
            UnregisterHotKey(this.Handle, HOTKEY_ID);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // KeyHooker
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "KeyHooker";
            this.Load += new System.EventHandler(this.KeyHooker_Load);
            this.ResumeLayout(false);

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            RegisterHotKey(this.Handle, HOTKEY_ID, KeyModifiers.Control | KeyModifiers.Shift, Keys.N);
             UnregisterHotKey(this.Handle, HOTKEY_ID);
        }
     
        private void KeyHooker_Load(object sender, EventArgs e)
        {

        }
    }


}

