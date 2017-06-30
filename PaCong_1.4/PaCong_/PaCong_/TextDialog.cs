using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaCong_
{
    public partial class TextDialog : Form
    {
        public TextDialog()
        {
            InitializeComponent();
        }
       public  Form_TextDialog form_textdialog { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Text == "自定义正则表达式匹配符")
            {
                form_textdialog.Html_parsing(textBox1.Lines.ToList());
                this.Text = "自定义正则表达式匹配符Name";
                textBox1.Text = "";
            }
            else {
                form_textdialog.Html_parsing_Name(textBox1.Lines.ToList());
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void setText(string Text) {
            textBox1.Text = Text;
        }
        public void addText(string Text) {
            textBox1.Text += Text;
        }
        private void TextDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
