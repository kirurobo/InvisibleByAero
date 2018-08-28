using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Ruen;

namespace InvisibleByAero
{
    public partial class MainForm : Form
    {
        private const string DEFAULT_WINDOWNAME = "MikuMikuDance";
        private const string DEFAULT_WINDOWTITLE = "MMD";
        private const int GWL_STYLE = -16;
        private const int GWL_EXSTYLE = -20;
        private const uint SWP_REFRESH = 0x237;
        private const uint SWP_NOSIZE = 0x1;
        private const uint SWP_NOMOVE = 0x2;
        private const uint SWP_NOZORDER = 0x4;
        private const uint SWP_NOACTIVATE = 0x10;
        private const uint SWP_FRAMECHANGED = 0x20;
        private const uint SWP_ASYNCWINDOWPOS = 0x4000;
        private const uint SWP_SHOWWINDOW = 0x40;
        private const uint SWP_NOOWNERZORDER = 0x200;
        private const uint SWP_NOREPOSITION = 0x200;
        private const uint SWP_NOSENDCHANGING = 0x400;
        private const int WS_OVERLAPPEDWINDOW = 0x00CF0000;
        private const int WS_EX_TRANSPARENT = 0x00000020;
        private const int WS_EX_LAYERED = 0x00080000;
        private const int WS_EX_TOPMOST = 0x00000008;
        private const int WS_EX_OVERLAPPEDWINDOW = 0x00000300;

        private delegate int EnumWindowsDelegate(IntPtr hWnd, int lParam);

        [DllImport("user32.dll")]
        private static extern int EnumWindows(EnumWindowsDelegate lpEnumFunc, int lParam);
        [DllImport("user32.dll")]
        private static extern int IsWindowVisible(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpszClass, string lpszTitle);
        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int value);
        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

        private Dictionary<IntPtr, int> originalStyles = new Dictionary<IntPtr, int>();
        private Dictionary<IntPtr, int> originalExStyles = new Dictionary<IntPtr, int>();


        private class ProcessItem
        {
            public Process Process;
            public IntPtr Handle;
            public string Text;

            public ProcessItem(IntPtr handle, Process process, string title)
            {
                this.Process = process;
                this.Handle = handle;
                this.Text = title;
            }

            override public string ToString()
            {
                if (string.IsNullOrEmpty(Text)) return Process.ProcessName;
                else return Process.ProcessName + " - " + Text;
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ウィンドウクラス一覧を取得
        /// </summary>
        /// 参考： http://muumoo.jp/news/2008/03/26/0enumwindows.html
        private void GetWindowClasses()
        {
            comboBoxWindowClass.Items.Clear();
            
            EnumWindows(new EnumWindowsDelegate(delegate(IntPtr hWnd, int lParam)
                {
                    StringBuilder sb = new StringBuilder(0x1024);
                    if (IsWindowVisible(hWnd) != 0 && GetWindowText(hWnd, sb, sb.Capacity) != 0)
                    {
                        int pid;
                        GetWindowThreadProcessId(hWnd, out pid);
                        Process p = Process.GetProcessById(pid);

                        comboBoxWindowClass.Items.Add(new ProcessItem(hWnd, p, sb.ToString()));
                        if (p.ProcessName == DEFAULT_WINDOWNAME && sb.ToString() == DEFAULT_WINDOWTITLE)
                        {
                            comboBoxWindowClass.SelectedIndex = comboBoxWindowClass.Items.Count - 1;
                        }
                    }
                    return 1;
                }), 0);

            originalExStyles.Clear();
            originalStyles.Clear();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GetWindowClasses();

            DwmApi.DwmEnableComposition(true);
        }

        /// <summary>
        /// 透明化ボタンが押されたときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAeroNoBorder_Click(object sender, EventArgs e)
        {
            //IntPtr hWnd = FindWindow(comboBoxWindowClass.Text, null);

            ProcessItem item = (ProcessItem)comboBoxWindowClass.SelectedItem;
            if (item == null) return;

            IntPtr hWnd = item.Handle;

            if (hWnd == null || hWnd == IntPtr.Zero) return;

            // ウィンドウ状態を読み込み＆記憶
            int ws = GetWindowLong(hWnd, GWL_STYLE);
            int wsex = GetWindowLong(hWnd, GWL_EXSTYLE);
            if (!originalStyles.ContainsKey(hWnd)) originalStyles[hWnd] = ws;
            if (!originalExStyles.ContainsKey(hWnd)) originalExStyles[hWnd] = wsex;

            // エアロによる透明化範囲を全体に適用
            DwmApi.DwmExtendIntoClientAll(hWnd);

            // 枠無しウィンドウにする
            ws &= ~WS_OVERLAPPEDWINDOW;
            SetWindowLong(hWnd, GWL_STYLE, ws);

            // 常に最前面にし、操作は受け付けないようにする
            //wsex &= ~WS_EX_OVERLAPPEDWINDOW;
            wsex = WS_EX_TRANSPARENT;
            wsex |= WS_EX_LAYERED;
            wsex |= WS_EX_TOPMOST;
            SetWindowLong(hWnd, GWL_EXSTYLE, wsex);

            SetWindowPos(hWnd, new IntPtr(-1), 0, 0, 0, 0, SWP_REFRESH);
        }

        /// <summary>
        /// 不透明化ボタンが押されたときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNoAeroBorder_Click(object sender, EventArgs e)
        {
            //IntPtr hWnd = FindWindow(comboBoxWindowClass.Text, null);

            ProcessItem item = (ProcessItem)comboBoxWindowClass.SelectedItem;
            if (item == null) return;

            IntPtr hWnd = item.Handle;

            if (hWnd == null || hWnd == IntPtr.Zero) return;

            // DWMによる透明化範囲をなくす
            DwmApi.MARGINS margins = new DwmApi.MARGINS(0, 0, 0, 0);
            DwmApi.DwmExtendFrameIntoClientArea(hWnd, margins);

            int ws;
            int wsex;

            // 通常ウィンドウにする
            if (originalStyles.ContainsKey(hWnd))
            {
                ws = originalStyles[hWnd];
            } else
            {
                ws = GetWindowLong(hWnd, GWL_STYLE) | WS_OVERLAPPEDWINDOW;
            }
            SetWindowLong(hWnd, GWL_STYLE, ws);

            // 操作の透過と常に最前面を解除
            if (originalExStyles.ContainsKey(hWnd))
            {
                wsex = originalExStyles[hWnd];
            }
            else
            {
                wsex = GetWindowLong(hWnd, GWL_EXSTYLE);
                wsex &= ~WS_EX_TRANSPARENT;
                wsex &= ~WS_EX_LAYERED;
                wsex &= ~WS_EX_TOPMOST;
            }
            SetWindowLong(hWnd, GWL_EXSTYLE, wsex);

            SetWindowPos(hWnd, IntPtr.Zero, 0, 0, 0, 0, SWP_REFRESH);
        }

        /// <summary>
        /// 対象ウィンドウ更新ボタンが押されたときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            GetWindowClasses();
        }
    }
}
