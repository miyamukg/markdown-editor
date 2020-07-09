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
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            string html = Markdown.ToHtml(txtMarkdown.Text);
            txtHTML.Text = html;
        }
    }
}
