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
            this.checkBoxTopmost = new System.Windows.Forms.CheckBox();
            this.checkBoxClickThrough = new System.Windows.Forms.CheckBox();
            this.checkBoxOpacity = new System.Windows.Forms.CheckBox();
            this.colorDialogForTransparent = new System.Windows.Forms.ColorDialog();
            this.buttonKeyColor = new System.Windows.Forms.Button();
            this.buttonRefreshWithChildren = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownOpacity = new System.Windows.Forms.NumericUpDown();
            this.radioButtonDwm = new System.Windows.Forms.RadioButton();
            this.radioButtonChromakey = new System.Windows.Forms.RadioButton();
            this.radioButtonDefault = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxBorder = new System.Windows.Forms.CheckBox();
            this.textBoxDebug = new System.Windows.Forms.TextBox();
            this.buttonDesktop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxWindowClass
            // 
            this.comboBoxWindowClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxWindowClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWindowClass.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBoxWindowClass.FormattingEnabled = true;
            this.comboBoxWindowClass.Location = new System.Drawing.Point(48, 10);
            this.comboBoxWindowClass.Name = "comboBoxWindowClass";
            this.comboBoxWindowClass.Size = new System.Drawing.Size(340, 20);
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
            this.buttonNoAeroBorder.Location = new System.Drawing.Point(11, 214);
            this.buttonNoAeroBorder.Name = "buttonNoAeroBorder";
            this.buttonNoAeroBorder.Size = new System.Drawing.Size(374, 40);
            this.buttonNoAeroBorder.TabIndex = 2;
            this.buttonNoAeroBorder.Text = "元の状態に戻す";
            this.buttonNoAeroBorder.UseVisualStyleBackColor = true;
            this.buttonNoAeroBorder.Click += new System.EventHandler(this.buttonNoAeroBorder_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(48, 36);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(100, 25);
            this.buttonRefresh.TabIndex = 3;
            this.buttonRefresh.Text = "更新";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(11, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(373, 41);
            this.label2.TabIndex = 4;
            this.label2.Text = "注意\r\n・完全には戻らない場合もあります。\r\n　その場合は対象のアプリケーションを再起動してください。";
            // 
            // checkBoxTopmost
            // 
            this.checkBoxTopmost.AutoSize = true;
            this.checkBoxTopmost.Location = new System.Drawing.Point(195, 156);
            this.checkBoxTopmost.Name = "checkBoxTopmost";
            this.checkBoxTopmost.Size = new System.Drawing.Size(60, 16);
            this.checkBoxTopmost.TabIndex = 5;
            this.checkBoxTopmost.Text = "最前面";
            this.checkBoxTopmost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxTopmost.UseVisualStyleBackColor = true;
            this.checkBoxTopmost.CheckedChanged += new System.EventHandler(this.control_Click);
            // 
            // checkBoxClickThrough
            // 
            this.checkBoxClickThrough.AutoSize = true;
            this.checkBoxClickThrough.Location = new System.Drawing.Point(270, 156);
            this.checkBoxClickThrough.Name = "checkBoxClickThrough";
            this.checkBoxClickThrough.Size = new System.Drawing.Size(72, 16);
            this.checkBoxClickThrough.TabIndex = 5;
            this.checkBoxClickThrough.Text = "操作透過";
            this.checkBoxClickThrough.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxClickThrough.UseVisualStyleBackColor = true;
            this.checkBoxClickThrough.CheckedChanged += new System.EventHandler(this.control_Click);
            // 
            // checkBoxOpacity
            // 
            this.checkBoxOpacity.AutoSize = true;
            this.checkBoxOpacity.Location = new System.Drawing.Point(77, 183);
            this.checkBoxOpacity.Name = "checkBoxOpacity";
            this.checkBoxOpacity.Size = new System.Drawing.Size(106, 16);
            this.checkBoxOpacity.TabIndex = 5;
            this.checkBoxOpacity.Text = "全体の不透明度";
            this.checkBoxOpacity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxOpacity.UseVisualStyleBackColor = true;
            this.checkBoxOpacity.CheckedChanged += new System.EventHandler(this.control_Click);
            // 
            // buttonKeyColor
            // 
            this.buttonKeyColor.BackColor = System.Drawing.Color.Black;
            this.buttonKeyColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKeyColor.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonKeyColor.ForeColor = System.Drawing.Color.White;
            this.buttonKeyColor.Location = new System.Drawing.Point(186, 119);
            this.buttonKeyColor.Name = "buttonKeyColor";
            this.buttonKeyColor.Size = new System.Drawing.Size(86, 20);
            this.buttonKeyColor.TabIndex = 6;
            this.buttonKeyColor.Text = "色選択...";
            this.buttonKeyColor.UseVisualStyleBackColor = false;
            this.buttonKeyColor.Click += new System.EventHandler(this.buttonKeyColor_Click);
            // 
            // buttonRefreshWithChildren
            // 
            this.buttonRefreshWithChildren.Location = new System.Drawing.Point(154, 36);
            this.buttonRefreshWithChildren.Name = "buttonRefreshWithChildren";
            this.buttonRefreshWithChildren.Size = new System.Drawing.Size(100, 25);
            this.buttonRefreshWithChildren.TabIndex = 3;
            this.buttonRefreshWithChildren.Text = "子を含め更新";
            this.buttonRefreshWithChildren.UseVisualStyleBackColor = true;
            this.buttonRefreshWithChildren.Click += new System.EventHandler(this.buttonRefreshWithChildren_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "透過方法";
            // 
            // numericUpDownOpacity
            // 
            this.numericUpDownOpacity.Increment = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownOpacity.Location = new System.Drawing.Point(195, 182);
            this.numericUpDownOpacity.Name = "numericUpDownOpacity";
            this.numericUpDownOpacity.Size = new System.Drawing.Size(49, 19);
            this.numericUpDownOpacity.TabIndex = 7;
            this.numericUpDownOpacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownOpacity.ValueChanged += new System.EventHandler(this.control_Click);
            // 
            // radioButtonDwm
            // 
            this.radioButtonDwm.AutoSize = true;
            this.radioButtonDwm.Location = new System.Drawing.Point(77, 99);
            this.radioButtonDwm.Name = "radioButtonDwm";
            this.radioButtonDwm.Size = new System.Drawing.Size(100, 16);
            this.radioButtonDwm.TabIndex = 8;
            this.radioButtonDwm.Text = "DWMによる透過";
            this.radioButtonDwm.UseVisualStyleBackColor = true;
            this.radioButtonDwm.CheckedChanged += new System.EventHandler(this.control_Click);
            // 
            // radioButtonChromakey
            // 
            this.radioButtonChromakey.AutoSize = true;
            this.radioButtonChromakey.Location = new System.Drawing.Point(77, 121);
            this.radioButtonChromakey.Name = "radioButtonChromakey";
            this.radioButtonChromakey.Size = new System.Drawing.Size(103, 16);
            this.radioButtonChromakey.TabIndex = 8;
            this.radioButtonChromakey.Text = "指定色での透過";
            this.radioButtonChromakey.UseVisualStyleBackColor = true;
            this.radioButtonChromakey.CheckedChanged += new System.EventHandler(this.control_Click);
            // 
            // radioButtonDefault
            // 
            this.radioButtonDefault.AutoSize = true;
            this.radioButtonDefault.Checked = true;
            this.radioButtonDefault.Location = new System.Drawing.Point(77, 77);
            this.radioButtonDefault.Name = "radioButtonDefault";
            this.radioButtonDefault.Size = new System.Drawing.Size(66, 16);
            this.radioButtonDefault.TabIndex = 8;
            this.radioButtonDefault.TabStop = true;
            this.radioButtonDefault.Text = "透過なし";
            this.radioButtonDefault.UseVisualStyleBackColor = true;
            this.radioButtonDefault.CheckedChanged += new System.EventHandler(this.control_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "オプション";
            // 
            // checkBoxBorder
            // 
            this.checkBoxBorder.AutoSize = true;
            this.checkBoxBorder.Location = new System.Drawing.Point(77, 156);
            this.checkBoxBorder.Name = "checkBoxBorder";
            this.checkBoxBorder.Size = new System.Drawing.Size(103, 16);
            this.checkBoxBorder.TabIndex = 5;
            this.checkBoxBorder.Text = "ウィンドウ枠除去";
            this.checkBoxBorder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxBorder.UseVisualStyleBackColor = true;
            this.checkBoxBorder.CheckedChanged += new System.EventHandler(this.control_Click);
            // 
            // textBoxDebug
            // 
            this.textBoxDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDebug.Location = new System.Drawing.Point(11, 319);
            this.textBoxDebug.Multiline = true;
            this.textBoxDebug.Name = "textBoxDebug";
            this.textBoxDebug.Size = new System.Drawing.Size(373, 236);
            this.textBoxDebug.TabIndex = 9;
            // 
            // buttonDesktop
            // 
            this.buttonDesktop.Location = new System.Drawing.Point(270, 178);
            this.buttonDesktop.Name = "buttonDesktop";
            this.buttonDesktop.Size = new System.Drawing.Size(100, 25);
            this.buttonDesktop.TabIndex = 3;
            this.buttonDesktop.Text = "デスクトップ";
            this.buttonDesktop.UseVisualStyleBackColor = true;
            this.buttonDesktop.Click += new System.EventHandler(this.buttonDesktop_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 567);
            this.Controls.Add(this.textBoxDebug);
            this.Controls.Add(this.radioButtonDefault);
            this.Controls.Add(this.radioButtonChromakey);
            this.Controls.Add(this.radioButtonDwm);
            this.Controls.Add(this.numericUpDownOpacity);
            this.Controls.Add(this.buttonKeyColor);
            this.Controls.Add(this.checkBoxBorder);
            this.Controls.Add(this.checkBoxClickThrough);
            this.Controls.Add(this.checkBoxOpacity);
            this.Controls.Add(this.checkBoxTopmost);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonRefreshWithChildren);
            this.Controls.Add(this.buttonDesktop);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonNoAeroBorder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxWindowClass);
            this.Name = "MainForm";
            this.Text = "任意窓透明化";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOpacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxWindowClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonNoAeroBorder;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxTopmost;
        private System.Windows.Forms.CheckBox checkBoxClickThrough;
        private System.Windows.Forms.CheckBox checkBoxOpacity;
        private System.Windows.Forms.ColorDialog colorDialogForTransparent;
        private System.Windows.Forms.Button buttonKeyColor;
        private System.Windows.Forms.Button buttonRefreshWithChildren;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownOpacity;
        private System.Windows.Forms.RadioButton radioButtonDwm;
        private System.Windows.Forms.RadioButton radioButtonChromakey;
        private System.Windows.Forms.RadioButton radioButtonDefault;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxBorder;
        private System.Windows.Forms.TextBox textBoxDebug;
        private System.Windows.Forms.Button buttonDesktop;
    }
}

