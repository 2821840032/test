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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
        
        List<List<string>> liststring = new List<List<string>>();
        /// <summary>接受数据
        /// </summary>
        /// <param name="liststring"></param>
        public void AddlistString(List<List<string>> liststring) {
            this.liststring = liststring;
            //尴尬
            for (int h = 1; h < liststring.Count; h++)
            {
                if (liststring[h].Count==0)
                {
                    continue;
                }
                ListViewItem ViewItem = new ListViewItem(liststring[h][0]);
                for (int l = 1; l < liststring[h].Count; l++)
                {
                    ViewItem.SubItems.Add(liststring[h][l]);
                }
                listView1.Items.Add(ViewItem);
            }
            // liststring每一项为一个页面的数据  lists第一项为URL从第二项开始为筛选到的页面数据
            // 保存数据到数据库
            try
            {
                SaveDataToDB.addTable(liststring);
            }
            catch (Exception e)
            {
                MessageBox.Show("保存数据出错！\n" + e.Message);
            }
        }
        public void AddListItemSting(List<string> listitemstring) {
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            int ListViewSelectIndex = listView1.SelectedIndices[0];
            ListViewDialog ViewDia = new ListViewDialog();
            ViewDia.liststring = liststring[ListViewSelectIndex + 1];
            ViewDia.Show();
        }
    }
}
