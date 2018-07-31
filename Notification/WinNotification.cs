using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinNotification
{
    public class WinNotification : IDisposable
    {
        private NotifyIcon notify;
        public const int DEFAULT_TIMEOUT = 5000;


        public WinNotification():this(Application.ProductName) { }

        public WinNotification(String name)
        {
                this.notify = new NotifyIcon();
                this.notify.Text = name;
                this.notify.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }


        public void Show(String content) {
            Show(content, notify.Text);
        }


        public void Show(String content, Action<object,EventArgs> action) {
            Show(content, notify.Text);
            notify.Click += (s, e) => action(s, e);
        }


        public void Show(String content, String title)
        {
            Show(title, content, DEFAULT_TIMEOUT);
        }


        public void Show(String content, String title, Action<object,EventArgs> action)
        {
            Show(title, content, DEFAULT_TIMEOUT);
            notify.Click += (s, e) => action(s, e);
        }


        public void Show(String title, String content, int timeout)
        {            
                notify.BalloonTipTitle = title;
                notify.BalloonTipText = content;
                notify.Visible = true;
                notify.ShowBalloonTip(timeout);
        }


        public void Show(String title, String content, int timeout, Action<object,EventArgs> action)
        {
            Show(title, content, timeout);
            notify.Click += (s, e) => action(s, e);
        }


        public void Dispose()
        {
            notify.Dispose();
            notify = null;
        }
    }
}
