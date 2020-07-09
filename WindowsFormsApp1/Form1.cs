using Microsoft.Toolkit.Parsers.Markdown;
using Microsoft.Toolkit.Parsers.Markdown.Blocks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            String beforeText = ((TextBox)sender).Text;
            UpdateMDResult();
        }
        private void UpdateMDResult()
        {
            var document = new MarkdownDocument();
            document.Parse("This is **Markdown**");

            var json = JsonConvert.SerializeObject(document, Formatting.Indented, new StringEnumConverter());
            textBox2.Text = json;
        }
    }
}
