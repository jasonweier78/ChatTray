using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatTray
{
    public class SystemTrayContext : ApplicationContext
    {
        private static readonly string IconFileName = "ChatTray.ico";
        private static readonly string DefaultToolTip = "Chat Tray!";
        private static readonly string DefaultUrl = "https://hangouts.google.com/";
        private Form1 ChatWindow;
        public SystemTrayContext()
        {
            Initialize(); 
        }

        private System.ComponentModel.IContainer components;	// a list of components to dispose when the context is disposed
        private NotifyIcon notifyIcon;				            // the icon that sits in the system tray
        private void Initialize()
        {
            components = new System.ComponentModel.Container();
            notifyIcon = new NotifyIcon(components)
            {
                ContextMenuStrip = new ContextMenuStrip(),
                Icon = new System.Drawing.Icon(IconFileName),
                Text = DefaultToolTip,
                Visible = true
            };
            notifyIcon.ContextMenuStrip.Opening += ContextMenuStrip_Opening;
            //notifyIcon.DoubleClick += notifyIcon_DoubleClick;
            notifyIcon.MouseUp += notifyIcon_MouseUp;
        }

        private void notifyIcon_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
                mi.Invoke(notifyIcon, null);
            }
            else if (e.Button == MouseButtons.Left)
            {
                ShowChatWindow();
            }
        }

        private void ShowChatWindow()
        {
            if (ChatWindow == null)
            {
                ChatWindow = new Form1();
                ChatWindow.Show();
            }
            else
            {
                if (ChatWindow.Visible)
                {
                    ChatWindow.WindowState = FormWindowState.Minimized;
                }
                else
                {
                    ChatWindow.WindowState = FormWindowState.Normal;
                }
            }
        }

        private void ContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = false;
            notifyIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());
            notifyIcon.ContextMenuStrip.Items.Add("&Settings");
            notifyIcon.ContextMenuStrip.Items.Add("&Help");
            notifyIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());
            notifyIcon.ContextMenuStrip.Items.Add("&Exit");
        }
    }
}
