using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Kirurobo;

namespace InvisibleByAero
{
    struct WindowStyle
    {
    }

    public partial class MainForm : Form
    {
        private const string DEFAULT_WINDOWNAME = "MikuMikuDance";
        private const string DEFAULT_WINDOWTITLE = "MMD";

        private bool IncludeChildren = false;

        private Dictionary<IntPtr, WindowItem> windowList = new Dictionary<IntPtr, WindowItem>();

        /// <summary>
        /// ウィンドウ状態を保持するクラス
        /// </summary>
        private class WindowItem
        {
            public IntPtr Handle;
            public string Text;
            public string ProcessName;
            public bool IsChild;

            public long OriginalStyles;     // 元のウィンドウスタイル
            public long OriginalExStyles;   // 元の拡張ウィンドウスタイル
            public bool Transparent;    // 透過中ならtrue
            public bool ColorKey;        // UpdateLayeredWindowの透過色指定ならtrue
            public bool HasAlpha;       // 全体の不透明度を指定するならtrue
            public Color KeyColor;      // 透過色指定
            public bool Topmost;        // 最前面中ならtrue
            public bool Clickthrough;   // キー・マウス操作透過中ならtrue
            public bool NoBorder;       // ウィンドウ枠を非表示にするならtrue
            public int Opacity;         // 不透明度[%]

            public WindowItem(IntPtr hWnd, Process process, string title, bool isChild = false)
            {
                this.ProcessName = process.ProcessName;
                this.Handle = hWnd;
                this.Text = title;
                this.IsChild = isChild;

                Reset();
                this.KeyColor = Color.Black;

                // ウィンドウ状態を読み込み＆記憶
                long ws = WinApi.GetWindowLong(hWnd, WinApi.GWL_STYLE);
                long wsex = WinApi.GetWindowLong(hWnd, WinApi.GWL_EXSTYLE);
                this.OriginalStyles = ws;
                this.OriginalExStyles = wsex;
            }

            /// <summary>
            /// 設定を標準に戻す
            /// </summary>
            public void Reset()
            {
                this.Transparent = false;
                this.ColorKey = false;
                this.HasAlpha = false;
                this.Topmost = false;
                this.Clickthrough = false;
                this.NoBorder = false;
                this.Opacity = 100;
            }

            override public string ToString()
            {
                if (string.IsNullOrEmpty(Text)) return $"{Handle.ToString("X8")} {ProcessName}";
                else return $"{Handle.ToString("X8")} {ProcessName}-{Text}";
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
                    if (windowList.ContainsKey(hWnd)) return true;

                    StringBuilder sb = new StringBuilder(1024);
                    
                    //// ウィンドウタイトルがないものは除外するなら下記2行の代わりにこの行を使う
                    //if (WinApi.IsWindowVisible(hWnd) != 0 && WinApi.GetWindowText(hWnd, sb, sb.Capacity) != 0)

                    WinApi.GetWindowText(hWnd, sb, sb.Capacity);
                    if (WinApi.IsWindowVisible(hWnd) != 0)
                    {
                        WinApi.GetWindowThreadProcessId(hWnd, out int pid);
                        Process p = Process.GetProcessById((int)pid);

                        comboBoxWindowClass.Items.Add(new WindowItem(hWnd, p, sb.ToString()));
                        if (p.ProcessName == DEFAULT_WINDOWNAME && sb.ToString() == DEFAULT_WINDOWTITLE)
                        {
                            comboBoxWindowClass.SelectedIndex = comboBoxWindowClass.Items.Count - 1;
                        }
                    }

                    if (IncludeChildren)
                    {
                        // 子ウィンドウも一覧に含める
                        WinApi.EnumChildWindows(hWnd, new WinApi.EnumWindowsDelegate(delegate (IntPtr hWndChild, long lParamChild)
                        {
                            if (windowList.ContainsKey(hWndChild)) return true;

                            StringBuilder sbChild = new StringBuilder(1024);
                            if (WinApi.IsWindowVisible(hWndChild) != 0 && WinApi.GetWindowText(hWndChild, sbChild, sbChild.Capacity) != 0)
                            {
                                WinApi.GetWindowThreadProcessId(hWndChild, out int pid);
                                Process p = Process.GetProcessById((int)pid);

                                comboBoxWindowClass.Items.Add(new WindowItem(hWndChild, p, sbChild.ToString(), true));
                                if (p.ProcessName == DEFAULT_WINDOWNAME && sbChild.ToString() == DEFAULT_WINDOWTITLE)
                                {
                                    comboBoxWindowClass.SelectedIndex = comboBoxWindowClass.Items.Count - 1;
                                }
                            }

                            return true;
                        }), 0);
                    }

                    return true;
                }), 0);

        }

        /// <summary>
        /// 選択されているウィンドウに合わせてボタンの状態を変更
        /// </summary>
        private void UpdateUI()
        {
            bool isTransparent = false;
            bool isColorKey = false;
            bool hasAlpha = false;
            bool isTopmost = false;
            bool isClickThrough = false;
            Color keyColor = Color.Black;
            int opacity = 100;
            bool noBorder = false;

            WindowItem item = (WindowItem)comboBoxWindowClass.SelectedItem;
            if (item != null)
            {
                isTransparent = item.Transparent;
                isColorKey = item.ColorKey;
                hasAlpha = item.HasAlpha;
                isTopmost = item.Topmost;
                isClickThrough = item.Clickthrough;
                keyColor = item.KeyColor;
                opacity = item.Opacity;
                noBorder = item.NoBorder;
            }

            if (!isTransparent && !isColorKey) radioButtonDefault.Checked = true;
            radioButtonDwm.Checked = isTransparent;
            radioButtonChromakey.Checked = isColorKey;
            checkBoxOpacity.Checked = hasAlpha;
            numericUpDownOpacity.Value = opacity;

            checkBoxTopmost.Checked = isTopmost;
            checkBoxClickThrough.Checked = isClickThrough;
            buttonKeyColor.BackColor = keyColor;
            checkBoxBorder.Checked = noBorder;
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

            item.Reset();

            UpdateUI();
            UpdateWindow(item);
        }

        /// <summary>
        /// ウィンドウを再描画させる
        /// </summary>
        /// <param name="item"></param>
        private void UpdateWindow(WindowItem item)
        {
            long ws;
            long wsex;

            IntPtr hWnd = item.Handle;
            if (!WinApi.IsWindow(hWnd))
            {
                comboBoxWindowClass.Items.Remove(item);
                return; // ウィンドウが存在しない
            }

            ws = item.OriginalStyles;
            wsex = item.OriginalExStyles;

            // ウィンドウスタイルを初期状態に一度戻す
            WinApi.SetWindowLong(hWnd, WinApi.GWL_EXSTYLE, wsex);
            WinApi.SetWindowLong(hWnd, WinApi.GWL_STYLE, ws);

            // 操作を透過させる（受け付けなくする）
            if (item.Clickthrough)
            {
                wsex |= WinApi.WS_EX_LAYERED;
                wsex |= WinApi.WS_EX_TRANSPARENT;
            }

            if (item.ColorKey || item.HasAlpha)
            {
                wsex |= WinApi.WS_EX_LAYERED;
            }

            if (item.NoBorder)
            {
                // 枠無しウィンドウにする
                ws &= ~WinApi.WS_OVERLAPPEDWINDOW;
            }

            // ウィンドウスタイルを適用
            WinApi.SetWindowLong(hWnd, WinApi.GWL_EXSTYLE, wsex);
            WinApi.SetWindowLong(hWnd, WinApi.GWL_STYLE, ws);

            byte alpha = 0xFF;
            if (item.HasAlpha) alpha = (byte)(0xFF * item.Opacity / 100);

            if (item.ColorKey || item.HasAlpha)
            {
                uint flags = (item.ColorKey ? WinApi.LWA_COLORKEY : 0) | (item.HasAlpha? WinApi.LWA_ALPHA : 0);
                WinApi.COLORREF crKey = new WinApi.COLORREF(item.KeyColor.R, item.KeyColor.G, item.KeyColor.B);
                WinApi.SetLayeredWindowAttributes(hWnd, crKey, alpha, flags);
            } else
            {
                //WinApi.SetLayeredWindowAttributes(hWnd, new WinApi.COLORREF(0), 0xFF, 0);
            }

            WinApi.RECT rect;
            WinApi.GetWindowRect(hWnd, out rect);

            // 再描画と同時に最前面状態を切り替え
            WinApi.SetWindowPos(
                hWnd,
                (item.Topmost? WinApi.HWND_TOPMOST : WinApi.HWND_NOTOPMOST),
                rect.left, rect.top,
                (rect.right - rect.left), (rect.bottom - rect.top),
                WinApi.SWP_ASYNCWINDOWPOS | WinApi.SWP_FRAMECHANGED | WinApi.SWP_NOCOPYBITS | WinApi.SWP_NOACTIVATE | WinApi.SWP_SHOWWINDOW
                );

            // 透明化状態を切り替え
            if (item.Transparent)
            {
                if (!item.IsChild)
                {
                    // エアロによる透明化範囲を全体に適用
                    DwmApi.DwmExtendIntoClientAll(hWnd);
                }
            }
            else
            {
                if (!item.IsChild)
                {
                    // DWMによる透明化範囲をなくす
                    DwmApi.MARGINS margins = new DwmApi.MARGINS(0, 0, 0, 0);
                    DwmApi.DwmExtendFrameIntoClientArea(hWnd, margins);
                }
            }
        }

        private void ApplyStyle()
        {
            WindowItem item = (WindowItem)comboBoxWindowClass.SelectedItem;
            if (item == null) return;

            if (radioButtonDwm.Checked)
            {
                item.Transparent= true;
                item.ColorKey = false;
            } else if (radioButtonChromakey.Checked)
            {
                item.Transparent = false;
                item.ColorKey = true;
            } else
            {
                item.Transparent = false;
                item.ColorKey = false;
            }

            item.HasAlpha = checkBoxOpacity.Checked;
            item.Opacity = (int)numericUpDownOpacity.Value;
            item.NoBorder = checkBoxBorder.Checked;

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
            IncludeChildren = false;
            GetWindowClasses();
        }

        /// <summary>
        /// 子を含めて対象ウィンドウ更新ボタンが押されたときの処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRefreshWithChildren_Click(object sender, EventArgs e)
        {
            IncludeChildren = true;
            GetWindowClasses();
        }

        private void comboBoxWindowClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void control_Click(object sender, EventArgs e)
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
