namespace MarkdownEditor
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
            this.btnParse = new System.Windows.Forms.Button();
            this.txtMarkdown = new System.Windows.Forms.TextBox();
            this.txtHTML = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnParse
            // 
            this.btnParse.Location = new System.Drawing.Point(361, 675);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(269, 49);
            this.btnParse.TabIndex = 0;
            this.btnParse.Text = "Markdown → HTML";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // txtMarkdown
            // 
            this.txtMarkdown.Location = new System.Drawing.Point(31, 63);
            this.txtMarkdown.Multiline = true;
            this.txtMarkdown.Name = "txtMarkdown";
            this.txtMarkdown.Size = new System.Drawing.Size(599, 590);
            this.txtMarkdown.TabIndex = 1;
            this.txtMarkdown.Text = "# タイトル\r\n- a\r\n- b\r\n- c";
            // 
            // txtHTML
            // 
            this.txtHTML.Location = new System.Drawing.Point(674, 63);
            this.txtHTML.Multiline = true;
            this.txtHTML.Name = "txtHTML";
            this.txtHTML.Size = new System.Drawing.Size(599, 590);
            this.txtHTML.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Markdown";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(682, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "HTML";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 738);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHTML);
            this.Controls.Add(this.txtMarkdown);
            this.Controls.Add(this.btnParse);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.TextBox txtMarkdown;
        private System.Windows.Forms.TextBox txtHTML;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

