using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace InvisibleByAero
{
    struct WindowStyle
    {
    }

    public partial class MainForm : Form
    {
        private const string DEFAULT_WINDOWNAME = "MikuMikuDance";
        private const string DEFAULT_WINDOWTITLE = "MMD";

        private Dictionary<IntPtr, WindowItem> windowList = new Dictionary<IntPtr, WindowItem>();

        /// <summary>
        /// ウィンドウ状態を保持するクラス
        /// </summary>
        private class WindowItem
        {
            public IntPtr Handle;
            public string Text;
            public string ProcessName;

            public long OriginalStyles;     // 元のウィンドウスタイル
            public long OriginalExStyles;   // 元の拡張ウィンドウスタイル
            public bool Transparent;    // 透過中ならtrue
            public bool ColorKey;        // UpdateLayeredWindowの透過色指定ならtrue
            public Color KeyColor;      // 透過色指定
            public bool Topmost;        // 最前面中ならtrue
            public bool Clickthrough;   // キー・マウス操作透過中ならtrue

            public WindowItem(IntPtr hWnd, Process process, string title)
            {
                this.ProcessName = process.ProcessName;
                this.Handle = hWnd;
                this.Text = title;

                this.Transparent = false;
                this.ColorKey = false;
                this.Topmost = false;
                this.Clickthrough = false;
                this.KeyColor = Color.Black;

                // ウィンドウ状態を読み込み＆記憶
                long ws = WinApi.GetWindowLong(hWnd, WinApi.GWL_STYLE);
                long wsex = WinApi.GetWindowLong(hWnd, WinApi.GWL_EXSTYLE);
                this.OriginalStyles = ws;
                this.OriginalExStyles = wsex;
            }

            override public string ToString()
            {
                if (string.IsNullOrEmpty(Text)) return ProcessName;
                else return ProcessName + " - " + Text;
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GetWindowClasses();

            DwmApi.DwmEnableComposition(true);
        }

        /// <summary>
        /// ウィンドウクラス一覧を取得
        /// </summary>
        private void GetWindowClasses()
        {
            comboBoxWindowClass.Items.Clear();
            
            WinApi.EnumWindows(new WinApi.EnumWindowsDelegate(delegate(IntPtr hWnd, long lParam)
                {
                    if (windowList.ContainsKey(hWnd)) return 1;

                    StringBuilder sb = new StringBuilder(1024);
                    if (WinApi.IsWindowVisible(hWnd) != 0 && WinApi.GetWindowText(hWnd, sb, sb.Capacity) != 0)
                    {
                        WinApi.GetWindowThreadProcessId(hWnd, out long pid);
                        Process p = Process.GetProcessById((int)pid);

                        comboBoxWindowClass.Items.Add(new WindowItem(hWnd, p, sb.ToString()));
                        if (p.ProcessName == DEFAULT_WINDOWNAME && sb.ToString() == DEFAULT_WINDOWTITLE)
                        {
                            comboBoxWindowClass.SelectedIndex = comboBoxWindowClass.Items.Count - 1;
                        }
                    }

                    return 1;
                }), 0);

        }

        /// <summary>
        /// 選択されているウィンドウに合わせてボタンの状態を変更
        /// </summary>
        private void UpdateUI()
        {
            bool isTransparent = false;
            bool isColorKey = false;
            bool isTopmost = false;
            bool isClickThrough = false;
            Color keyColor = Color.Black;

            WindowItem item = (WindowItem)comboBoxWindowClass.SelectedItem;
            if (item != null)
            {
                isTransparent = item.Transparent;
                isColorKey = item.ColorKey;
                isTopmost = item.Topmost;
                isClickThrough = item.Clickthrough;
                keyColor = item.KeyColor;
            }

            checkBoxTransparent.Checked = isTransparent;
            checkBoxColorKey.Checked = isColorKey;
            checkBoxTopmost.Checked = isTopmost;
            checkBoxClickThrough.Checked = isClickThrough;
            buttonKeyColor.BackColor = keyColor;
        }

        /// <summary>
        /// 元に戻すボタンが押されたときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNoAeroBorder_Click(object sender, EventArgs e)
        {
            WindowItem item = (WindowItem)comboBoxWindowClass.SelectedItem;
            if (item == null) return;

            item.Transparent = false;
            item.ColorKey = false;
            item.Topmost = false;
            item.Clickthrough = false;

            UpdateUI();
            UpdateWindow(item);
        }

        /// <summary>
        /// ウィンドウを再描画させる
        /// </summary>
        /// <param name="item"></param>
        private void UpdateWindow(WindowItem item)
        {
            bool isTransparent = false;
            bool isColorKey = false;
            bool isTopmost = false;
            bool isClickThrough = false;

            long ws;
            long wsex;

            IntPtr hWnd = item.Handle;
            if (!WinApi.IsWindow(hWnd))
            {
                comboBoxWindowClass.Items.Remove(item);
                return; // ウィンドウが存在しない
            }

            isTransparent = item.Transparent;
            isColorKey = item.ColorKey;
            isTopmost = item.Topmost;
            isClickThrough = item.Clickthrough;

            ws = item.OriginalStyles;
            wsex = item.OriginalExStyles;

            // 透明化状態を切り替え
            if (isTransparent)
            {
                // エアロによる透明化範囲を全体に適用
                DwmApi.DwmExtendIntoClientAll(hWnd);

                // 枠無しウィンドウにする
                ws &= ~WinApi.WS_OVERLAPPEDWINDOW;
            } else if (isColorKey) {
                // DWMによる透明化範囲をなくす
                DwmApi.MARGINS margins = new DwmApi.MARGINS(0, 0, 0, 0);
                DwmApi.DwmExtendFrameIntoClientArea(hWnd, margins);

                // 枠無しウィンドウにする
                ws &= ~WinApi.WS_OVERLAPPEDWINDOW;

                // レイヤードウィンドウにする
                wsex |= WinApi.WS_EX_LAYERED;
            }
            else
            {
                // DWMによる透明化範囲をなくす
                DwmApi.MARGINS margins = new DwmApi.MARGINS(0, 0, 0, 0);
                DwmApi.DwmExtendFrameIntoClientArea(hWnd, margins);
            }

            // 操作は受け付けないようにする
            if (isClickThrough)
            {
                wsex |= WinApi.WS_EX_LAYERED;
                wsex |= WinApi.WS_EX_TRANSPARENT;
            }

            // ウィンドウスタイルを適用
            WinApi.SetWindowLong(hWnd, WinApi.GWL_EXSTYLE, wsex);
            WinApi.SetWindowLong(hWnd, WinApi.GWL_STYLE, ws);

            if (isColorKey)
            {
                WinApi.COLORREF crKey = new WinApi.COLORREF(item.KeyColor.R, item.KeyColor.G, item.KeyColor.B);
                WinApi.SetLayeredWindowAttributes(hWnd, crKey, 0xFF, WinApi.LWA_COLORKEY);
            } else
            {
                WinApi.SetLayeredWindowAttributes(hWnd, new WinApi.COLORREF(0), 0xFF, WinApi.LWA_ALPHA);
            }

            WinApi.RECT rect;
            WinApi.GetWindowRect(hWnd, out rect);

            // 再描画と同時に最前面状態を切り替え
            WinApi.SetWindowPos(
                hWnd,
                (isTopmost ? WinApi.HWND_TOPMOST : WinApi.HWND_NOTOPMOST),
                rect.left, rect.top,
                (rect.right - rect.left), (rect.bottom - rect.top),
                WinApi.SWP_ASYNCWINDOWPOS | WinApi.SWP_FRAMECHANGED | WinApi.SWP_NOCOPYBITS | WinApi.SWP_NOACTIVATE | WinApi.SWP_SHOWWINDOW
                );
        }

        private void ApplyStyle()
        {
            WindowItem item = (WindowItem)comboBoxWindowClass.SelectedItem;
            if (item == null) return;

            if (checkBoxTransparent.Checked && !item.Transparent)
            {
                checkBoxColorKey.Checked = false;
            } else if (checkBoxColorKey.Checked && !item.ColorKey)
            {
                checkBoxTransparent.Checked = false;
            }

            item.Transparent = checkBoxTransparent.Checked;
            item.ColorKey = checkBoxColorKey.Checked;
            item.Topmost = checkBoxTopmost.Checked;
            item.Clickthrough = checkBoxClickThrough.Checked;
            item.KeyColor = buttonKeyColor.BackColor;

            UpdateWindow(item);
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

        private void comboBoxWindowClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void checkBoxTransparent_Click(object sender, EventArgs e)
        {
            ApplyStyle();
        }

        private void checkBoxTopmost_Click(object sender, EventArgs e)
        {
            ApplyStyle();
        }

        private void checkBoxClickThrough_Click(object sender, EventArgs e)
        {
            ApplyStyle();
        }

        private void checkBoxColorKey_Click(object sender, EventArgs e)
        {
            ApplyStyle();
        }

        private void buttonKeyColor_Click(object sender, EventArgs e)
        {
            colorDialogForTransparent.Color = buttonKeyColor.BackColor;
            if (colorDialogForTransparent.ShowDialog(this) == DialogResult.OK)
            {
                buttonKeyColor.BackColor = colorDialogForTransparent.Color;
                ApplyStyle();
            }

        }
    }
}
