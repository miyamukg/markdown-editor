using Markdig;
using System;
using System.Windows.Forms;

namespace MarkdownEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string html = Markdown.ToHtml(txtMarkdown.Text);
            webBrowser1.DocumentText = html;
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            string html = Markdown.ToHtml(txtMarkdown.Text);
            webBrowser1.DocumentText = html;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void txtMarkdown_TextChanged(object sender, EventArgs e)
        {
            string html = Markdown.ToHtml(txtMarkdown.Text);
            webBrowser1.DocumentText = html;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
