using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using Markdig;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MarkdownEditor
{
    public partial class Form1 : Form
    {
        public string returnValue { get; set; } = "normal";

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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "MDファイル|*.md";
            DialogResult dr = op.ShowDialog();
            if(dr == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(op.FileName, Encoding.GetEncoding("UTF-8"));
                string mdString = "";
                while (reader.EndOfStream == false)
                {
                    string line = reader.ReadLine();
                    mdString += line + "\r\n";
                }
                txtMarkdown.Text = mdString;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "MDファイル|*.md";
            sf.Filter += "|HTMLファイル|*.html";
            sf.Filter += "|PDFファイル|*.pdf";

            //ダイアログを表示する

            if (sf.ShowDialog() == DialogResult.OK)
            {

                switch (sf.FilterIndex)
                {
                    case 1:
                        System.IO.Stream stream;
                        stream = sf.OpenFile();
                        if (stream != null)
                        {
                            //ファイルに書き込む
                            StreamWriter sw = new StreamWriter(stream);
                            sw.Write(txtMarkdown.Text);
                            //閉じる
                            sw.Close();
                            stream.Close();
                        }
                        break;
                    case 2:
                        System.IO.Stream _stream;
                        _stream = sf.OpenFile();
                        if (_stream != null)
                        {
                            //ファイルに書き込む
                            StreamWriter sw = new StreamWriter(_stream);
                            sw.Write(webBrowser1.DocumentText);
                            //閉じる
                            sw.Close();
                            _stream.Close();
                        }
                        break;

                    case 3:
                        //Byte[] result = null;
                        //using (MemoryStream ms = new MemoryStream())
                        //{
                        //    PdfDocument pdfDocument = new PdfDocument();
                        //    PdfDocument pdf = PdfGenerator.GeneratePdf(webBrowser1.DocumentText, PdfSharp.PageSize.A4, 60);
                        //    pdf.Save(ms);
                        //    result = ms.ToArray();
                        //    //var pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(webBrowser1.DocumentText, PdfSharp.PageSize.A4);
                        //    //pdf.Save(ms);
                        //    //result = ms.ToArray();
                        //}
                        //using (BinaryWriter w = new BinaryWriter(File.OpenWrite(sf.FileName)))
                        //{
                        //    w.Write(result);
                        //}
                        Font fnt = new Font(BaseFont.CreateFont(@"c:\windows\fonts\meiryo.ttc,0", BaseFont.IDENTITY_H, true), 40);

                        Dictionary<string, object> dicProvider = new Dictionary<string, object>();
                        dicProvider.Add(HTMLWorker.FONT_PROVIDER, new NewFontProvider(returnValue));

                        string html = webBrowser1.DocumentText;

                        string outfilepath = sf.FileName;
                        FileStream fsoutput = new FileStream(outfilepath, FileMode.Create);
                        TextReader reader = new StringReader(html);

                        // step 1: creation of a document-object
                        Rectangle pageSize = new Rectangle(PageSize.A4);
                        switch (returnValue)
                        {
                            case "normal":
                                pageSize.BackgroundColor = new BaseColor(255, 255, 255);
                                break;

                            case "dark":
                                pageSize.BackgroundColor = new BaseColor(0, 0, 0);
                                break;

                            case "paradise":
                                pageSize.BackgroundColor = new BaseColor(84, 141, 212);
                                break;

                            default:
                                pageSize.BackgroundColor = new BaseColor(255, 255, 255);
                                break;
                        }
                        
                        Document document = new Document(pageSize, 30, 30, 30, 30);
                        

                        // step 2:
                        // we create a writer that listens to the document
                        // and directs a XML-stream to a file
                        PdfWriter writer = PdfWriter.GetInstance(document, fsoutput);

                        // step 3: we create a worker parse the document
                        HTMLWorker worker = new HTMLWorker(document);
                        worker.SetProviders(dicProvider);

                        // step 4: we open document and start the worker on the document
                        document.Open();
                        worker.StartDocument();

                        // step 5: parse the html into the document
                        worker.Parse(reader);

                        // step 6: close the document and the worker
                        worker.EndDocument();
                        worker.Close();
                        document.Close();

                        Console.ReadLine();
                
                break;
                }

                

            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            using (Form2 form2 = new Form2(returnValue))
            {
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    returnValue = form2.returnValue;
                    //Do something here with these values

                    //for example
                    //this.txtSomething.Text = val;
                }
            }

            //// Determine if the form is modal.
            //if (myForm.Modal == false)
            //{
            //    // Change borderstyle and make it not a top level window.
            //    myForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            //    myForm.TopLevel = false;
            //}
        }
    }
    public class NewFontProvider : FontFactoryImp
    {
        public string returnValue { get; set; } = "normal";

        public NewFontProvider(string outStyle)
        {
            returnValue = outStyle;
        }

        public override Font GetFont(string fontname, string encoding, bool embedded, float size, int style, BaseColor color, bool cached)
        {
            if (string.IsNullOrEmpty(fontname))
            {
                fontname = "c:\\windows\\fonts\\meiryo.ttc,0";
                encoding = BaseFont.IDENTITY_H;
                embedded = BaseFont.EMBEDDED;
                switch (returnValue)
                {
                    case "normal":
                        color = new BaseColor(0, 0, 0);
                        break;

                    case "dark":
                        color = new BaseColor(255, 255, 255);
                        break;

                    case "paradise":
                        color = new BaseColor(255, 255, 0);
                        break;

                    default:
                        color = new BaseColor(0, 0, 0);
                        break;
                }
            }

            return base.GetFont(fontname, encoding, embedded, size, style, color, cached);
        }
    }
}
