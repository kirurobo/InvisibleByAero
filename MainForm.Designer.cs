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
            this.buttonAeroNoBorder = new System.Windows.Forms.Button();
            this.buttonNoAeroBorder = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxWindowClass
            // 
            this.comboBoxWindowClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxWindowClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWindowClass.FormattingEnabled = true;
            this.comboBoxWindowClass.Location = new System.Drawing.Point(91, 10);
            this.comboBoxWindowClass.Name = "comboBoxWindowClass";
            this.comboBoxWindowClass.Size = new System.Drawing.Size(297, 20);
            this.comboBoxWindowClass.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "対象ウィンドウ";
            // 
            // buttonAeroNoBorder
            // 
            this.buttonAeroNoBorder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAeroNoBorder.Location = new System.Drawing.Point(12, 48);
            this.buttonAeroNoBorder.Name = "buttonAeroNoBorder";
            this.buttonAeroNoBorder.Size = new System.Drawing.Size(457, 40);
            this.buttonAeroNoBorder.TabIndex = 1;
            this.buttonAeroNoBorder.Text = "透明化";
            this.buttonAeroNoBorder.UseVisualStyleBackColor = true;
            this.buttonAeroNoBorder.Click += new System.EventHandler(this.buttonAeroNoBorder_Click);
            // 
            // buttonNoAeroBorder
            // 
            this.buttonNoAeroBorder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNoAeroBorder.Location = new System.Drawing.Point(12, 94);
            this.buttonNoAeroBorder.Name = "buttonNoAeroBorder";
            this.buttonNoAeroBorder.Size = new System.Drawing.Size(457, 40);
            this.buttonNoAeroBorder.TabIndex = 2;
            this.buttonNoAeroBorder.Text = "不透明化";
            this.buttonNoAeroBorder.UseVisualStyleBackColor = true;
            this.buttonNoAeroBorder.Click += new System.EventHandler(this.buttonNoAeroBorder_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefresh.Location = new System.Drawing.Point(394, 7);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 3;
            this.buttonRefresh.Text = "一覧更新";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(456, 61);
            this.label2.TabIndex = 4;
            this.label2.Text = "注意\r\n・透明化しても見えないだけでウィンドウは存在します。\r\n・不透明化を押しても完全には戻らない場合もあります。\r\n　その場合は対象のアプリケーションを再起動" +
    "してください。";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 219);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonNoAeroBorder);
            this.Controls.Add(this.buttonAeroNoBorder);
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
        private System.Windows.Forms.Button buttonAeroNoBorder;
        private System.Windows.Forms.Button buttonNoAeroBorder;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Label label2;
    }
}

