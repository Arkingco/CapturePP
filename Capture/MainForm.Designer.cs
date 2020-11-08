using System.Threading;

namespace Capture
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.MainFormCaptureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MainFormCaptureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mainNotifyIcon_MouseClick);
            // 
            // MainFormCaptureBox
            // 
            this.MainFormCaptureBox.Location = new System.Drawing.Point(2, 2);
            this.MainFormCaptureBox.Name = "MainFormCaptureBox";
            this.MainFormCaptureBox.Size = new System.Drawing.Size(129, 50);
            this.MainFormCaptureBox.TabIndex = 1;
            this.MainFormCaptureBox.TabStop = false;
            this.MainFormCaptureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainFormCaptureBox_MouseDown);
            this.MainFormCaptureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainFormCaptureBox_MouseMove);
            this.MainFormCaptureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainFormCaptureBox_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(160, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 48);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(544, 195);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MainFormCaptureBox);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.NotifyTest_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.MainFormCaptureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.PictureBox MainFormCaptureBox;
        private System.Windows.Forms.Label label1;
    }
}

