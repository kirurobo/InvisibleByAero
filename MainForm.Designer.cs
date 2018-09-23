namespace InvisibleByAero
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxWindowClass = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonNoAeroBorder = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxTransparent = new System.Windows.Forms.CheckBox();
            this.checkBoxTopmost = new System.Windows.Forms.CheckBox();
            this.checkBoxClickThrough = new System.Windows.Forms.CheckBox();
            this.checkBoxColorKey = new System.Windows.Forms.CheckBox();
            this.colorDialogForTransparent = new System.Windows.Forms.ColorDialog();
            this.buttonKeyColor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxWindowClass
            // 
            this.comboBoxWindowClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxWindowClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWindowClass.FormattingEnabled = true;
            this.comboBoxWindowClass.Location = new System.Drawing.Point(48, 10);
            this.comboBoxWindowClass.Name = "comboBoxWindowClass";
            this.comboBoxWindowClass.Size = new System.Drawing.Size(205, 20);
            this.comboBoxWindowClass.TabIndex = 0;
            this.comboBoxWindowClass.SelectedIndexChanged += new System.EventHandler(this.comboBoxWindowClass_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "対象";
            // 
            // buttonNoAeroBorder
            // 
            this.buttonNoAeroBorder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNoAeroBorder.Location = new System.Drawing.Point(12, 106);
            this.buttonNoAeroBorder.Name = "buttonNoAeroBorder";
            this.buttonNoAeroBorder.Size = new System.Drawing.Size(291, 40);
            this.buttonNoAeroBorder.TabIndex = 2;
            this.buttonNoAeroBorder.Text = "元の状態に戻す";
            this.buttonNoAeroBorder.UseVisualStyleBackColor = true;
            this.buttonNoAeroBorder.Click += new System.EventHandler(this.buttonNoAeroBorder_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefresh.Location = new System.Drawing.Point(259, 7);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(44, 23);
            this.buttonRefresh.TabIndex = 3;
            this.buttonRefresh.Text = "更新";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(13, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(290, 41);
            this.label2.TabIndex = 4;
            this.label2.Text = "注意\r\n・完全には戻らない場合もあります。\r\n　その場合は対象のアプリケーションを再起動してください。";
            // 
            // checkBoxTransparent
            // 
            this.checkBoxTransparent.AutoSize = true;
            this.checkBoxTransparent.Location = new System.Drawing.Point(12, 48);
            this.checkBoxTransparent.Name = "checkBoxTransparent";
            this.checkBoxTransparent.Size = new System.Drawing.Size(101, 16);
            this.checkBoxTransparent.TabIndex = 5;
            this.checkBoxTransparent.Text = "DWMによる透過";
            this.checkBoxTransparent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxTransparent.UseVisualStyleBackColor = true;
            this.checkBoxTransparent.Click += new System.EventHandler(this.checkBoxTransparent_Click);
            // 
            // checkBoxTopmost
            // 
            this.checkBoxTopmost.AutoSize = true;
            this.checkBoxTopmost.Location = new System.Drawing.Point(243, 47);
            this.checkBoxTopmost.Name = "checkBoxTopmost";
            this.checkBoxTopmost.Size = new System.Drawing.Size(60, 16);
            this.checkBoxTopmost.TabIndex = 5;
            this.checkBoxTopmost.Text = "最前面";
            this.checkBoxTopmost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxTopmost.UseVisualStyleBackColor = true;
            this.checkBoxTopmost.Click += new System.EventHandler(this.checkBoxTopmost_Click);
            // 
            // checkBoxClickThrough
            // 
            this.checkBoxClickThrough.AutoSize = true;
            this.checkBoxClickThrough.Location = new System.Drawing.Point(12, 69);
            this.checkBoxClickThrough.Name = "checkBoxClickThrough";
            this.checkBoxClickThrough.Size = new System.Drawing.Size(72, 16);
            this.checkBoxClickThrough.TabIndex = 5;
            this.checkBoxClickThrough.Text = "操作透過";
            this.checkBoxClickThrough.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxClickThrough.UseVisualStyleBackColor = true;
            this.checkBoxClickThrough.Click += new System.EventHandler(this.checkBoxClickThrough_Click);
            // 
            // checkBoxColorKey
            // 
            this.checkBoxColorKey.AutoSize = true;
            this.checkBoxColorKey.Location = new System.Drawing.Point(123, 47);
            this.checkBoxColorKey.Name = "checkBoxColorKey";
            this.checkBoxColorKey.Size = new System.Drawing.Size(104, 16);
            this.checkBoxColorKey.TabIndex = 5;
            this.checkBoxColorKey.Text = "指定色での透過";
            this.checkBoxColorKey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxColorKey.UseVisualStyleBackColor = true;
            this.checkBoxColorKey.Click += new System.EventHandler(this.checkBoxColorKey_Click);
            // 
            // buttonKeyColor
            // 
            this.buttonKeyColor.BackColor = System.Drawing.Color.Black;
            this.buttonKeyColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKeyColor.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonKeyColor.ForeColor = System.Drawing.Color.White;
            this.buttonKeyColor.Location = new System.Drawing.Point(123, 65);
            this.buttonKeyColor.Name = "buttonKeyColor";
            this.buttonKeyColor.Size = new System.Drawing.Size(104, 20);
            this.buttonKeyColor.TabIndex = 6;
            this.buttonKeyColor.Text = "色選択...";
            this.buttonKeyColor.UseVisualStyleBackColor = false;
            this.buttonKeyColor.Click += new System.EventHandler(this.buttonKeyColor_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 199);
            this.Controls.Add(this.buttonKeyColor);
            this.Controls.Add(this.checkBoxClickThrough);
            this.Controls.Add(this.checkBoxColorKey);
            this.Controls.Add(this.checkBoxTopmost);
            this.Controls.Add(this.checkBoxTransparent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonNoAeroBorder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxWindowClass);
            this.Name = "MainForm";
            this.Text = "任意窓透明化";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxWindowClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonNoAeroBorder;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxTransparent;
        private System.Windows.Forms.CheckBox checkBoxTopmost;
        private System.Windows.Forms.CheckBox checkBoxClickThrough;
        private System.Windows.Forms.CheckBox checkBoxColorKey;
        private System.Windows.Forms.ColorDialog colorDialogForTransparent;
        private System.Windows.Forms.Button buttonKeyColor;
    }
}

