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
    public partial class ListViewDialog : Form
    {
        public ListViewDialog()
        {
            InitializeComponent();
        }
        public List<string> liststring { get; set; }
        private void ListViewDialog_Load(object sender, EventArgs e)
        {
            if (liststring!=null)
            {for (int i = 0; i < liststring.Count; i++)
                {listView1.Items.Add(liststring[i]);}}
        }
    }
}
