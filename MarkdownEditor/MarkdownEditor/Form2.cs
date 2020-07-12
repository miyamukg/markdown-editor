using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarkdownEditor
{
    public partial class Form2 : Form
    {
        public string returnValue { get; set; }

        public Form2(string outStyle)
        {
            InitializeComponent();
            returnValue = outStyle;
            switch (returnValue)
            {
                case "normal":
                    radioButton1.Checked = true;
                    break;

                case "dark":
                    radioButton2.Checked = true;
                    break;

                case "paradise":
                    radioButton3.Checked = true;
                    break;

                default:
                    radioButton1.Checked = true;
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                this.returnValue = "normal";
            }
            else if (radioButton2.Checked)
            {
                this.returnValue = "dark";
            }
            else if (radioButton3.Checked)
            {
                this.returnValue = "paradise";
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
