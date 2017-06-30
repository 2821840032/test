using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PaCong_Math;
using PaConginterface;
namespace PaCong_
{
    public partial class Form1 : Form,PaCong_Form,Form_TextDialog, form2_NewThreadInterface
    {
        public Form1()
        {
            InitializeComponent();
        }
        PaCong_Thread Pa;
        private void Form1_Load(object sender, EventArgs e)
        {
            button5.Enabled = false;
            comboBox1.Items.Add("选择");
          DialogResult dis =  MessageBox.Show("1、优化了部分代码" +
            "2、子线程超时次数为1BUG修复" +
            "3、子线程超时与完成总量相当BUG修复" +
            "4、新增了耗时记录，剩余时间预测" +
            "5、修复了线程超5崩溃的bug" +
            "6、加快了数据回调到窗体的速度"+
            "7、此程序的数据分析是正则表达式"+
            "8、如果数据出现乱码一定是编码格式不对，默认url-8，"+
            "只能通过更改代码来更改,地址为PaCong_NewThread下的NewThread（）函数"+
            "9、每次操作完成后请打开任务管理器关闭进程，有可能它未关闭"+
            "10、如果乱用本程序导致ip被网站屏蔽，作者不承担任何责任"+
            "11、不可将此程序使用在非法途径，不可恶意攻击他方网站，"+
            "12、如若出现错误，请联系QQ2821840032", "注意", MessageBoxButtons.YesNo);
          if (dis == DialogResult.No)
          {
              System.Diagnostics.Process.GetCurrentProcess().Kill();
          }
            //初始化操作
            ///5为子线程数量
        }


        //↓↓↓↓↓↓↓↓↓接口↓↓↓↓↓↓↓↓↓↓↓↓↓
        public void NewThreadLength(int index)
        {
            label_NewThreadLength.Text = index.ToString();
        }

        public void NewThreadIndex(int index)
        {
            label_NewThreadIndex.Text = index.ToString();
        }

        List<List<int>> NewThreadint;


        public void NewThreadIndexint(List<int> index)
        {

            NewThreadint[index[0]] = index;
            setUrlCount(index[1].ToString());
            setinformation("子线程" + index[0] + "以完成第" + index[2] + "个链接的处理,剩余" + (index[3] - index[2]) + "个URL,超时数量" + index[4]);
            if (ComboboxIndex == index[0] + 1)
            {
                setNewThreadInt_1(index[0].ToString());
                setNewThreadInt_2(index[2].ToString());
                setNewThreadInt_3(index[3].ToString());
                setNewThreadInt_4(index[5].ToString());
                setNewThreadInt_5(index[4].ToString());
                setForemMainUrl(Pa.getListUrl(index[2]));
            }
        }

        public void UpdateXinXi(string stringval)
        {
            setinformation(stringval);
        }

        public void NewThreadIndexstring(List<List<string>> index)
        {
            throw new NotImplementedException();
        }
        
        //↑↑↑↑↑↑↑↑↑接口↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑


        //↓↓↓↓↓↓↓↓↓更新UI↓↓↓↓↓↓↓↓↓↓↓↓↓
        delegate void setNewThreadInt(string TestString);
        setNewThreadInt setnewthreadint;
        /// <summary>子线程更新UI的string委托
        /// </summary>
        /// <param name="TestString"></param>
        void setNewThreadInt_1(string TestString)
        {
            if (this.NewThreadInt_1.InvokeRequired)
            {
                while (!this.NewThreadInt_1.IsHandleCreated)
                {
                    //解决窗体关闭时出现“访问已释放句柄“的异常
                    if (this.NewThreadInt_1.Disposing || this.NewThreadInt_1.IsDisposed)
                        return;
                }
                setnewthreadint = new setNewThreadInt(setNewThreadInt_1);
                this.NewThreadInt_1.Invoke(setnewthreadint, new object[] { TestString });
            }
            else
            {
                this.NewThreadInt_1.Text = TestString;
            }

        }
        void setNewThreadInt_2(string TestString) {
            if (this.NewThreadInt_2.InvokeRequired)
            {
                while (!this.NewThreadInt_2.IsHandleCreated)
                {
                    //解决窗体关闭时出现“访问已释放句柄“的异常
                    if (this.NewThreadInt_2.Disposing || this.NewThreadInt_2.IsDisposed)
                        return;
                }
                setnewthreadint = new setNewThreadInt(setNewThreadInt_2);
                this.NewThreadInt_2.Invoke(setnewthreadint, new object[] { TestString });
            }
            else
            {
                this.NewThreadInt_2.Text = TestString;
            }
        
        }
        void setNewThreadInt_3(string TestString)
        {
            if (this.NewThreadInt_3.InvokeRequired)
            {
                while (!this.NewThreadInt_3.IsHandleCreated)
                {
                    //解决窗体关闭时出现“访问已释放句柄“的异常
                    if (this.NewThreadInt_3.Disposing || this.NewThreadInt_3.IsDisposed)
                        return;
                }
                setnewthreadint = new setNewThreadInt(setNewThreadInt_3);
                this.NewThreadInt_3.Invoke(setnewthreadint, new object[] { TestString });
            }
            else
            {
                this.NewThreadInt_3.Text = TestString;
            }

        }
        void setNewThreadInt_4(string TestString)
        {
            if (this.NewThreadInt_4.InvokeRequired)
            {
                while (!this.NewThreadInt_2.IsHandleCreated)
                {
                    //解决窗体关闭时出现“访问已释放句柄“的异常
                    if (this.NewThreadInt_4.Disposing || this.NewThreadInt_4.IsDisposed)
                        return;
                }
                setnewthreadint = new setNewThreadInt(setNewThreadInt_4);
                this.NewThreadInt_4.Invoke(setnewthreadint, new object[] { TestString });
            }
            else
            {
                this.NewThreadInt_4.Text = TestString;
            }

        }
        void setNewThreadInt_5(string TestString)
        {
            if (this.NewThreadInt_5.InvokeRequired)
            {
                while (!this.NewThreadInt_5.IsHandleCreated)
                {
                    //解决窗体关闭时出现“访问已释放句柄“的异常
                    if (this.NewThreadInt_5.Disposing || this.NewThreadInt_5.IsDisposed)
                        return;
                }
                setnewthreadint = new setNewThreadInt(setNewThreadInt_5);
                this.NewThreadInt_5.Invoke(setnewthreadint, new object[] { TestString });
            }
            else
            {
                this.NewThreadInt_5.Text = TestString;
            }

        }

        void setForemMainUrl(string TestString)
        {
            if (this.ForemMainUrl.InvokeRequired)
            {
                while (!this.ForemMainUrl.IsHandleCreated)
                {
                    //解决窗体关闭时出现“访问已释放句柄“的异常
                    if (this.ForemMainUrl.Disposing || this.ForemMainUrl.IsDisposed)
                        return;
                }
                setnewthreadint = new setNewThreadInt(setForemMainUrl);
                this.ForemMainUrl.Invoke(setnewthreadint, new object[] { TestString });
            }
            else
            {
                this.ForemMainUrl.Text = TestString;
            }

        }


        //更新信息框
        void setinformation(string TextString) {
            if (!informationBool)
            {
                return;
            }
            if (this.information.InvokeRequired)
            {
                while (!this.information.IsHandleCreated)
                {
                    //解决窗体关闭时出现“访问已释放句柄“的异常
                    if (this.information.Disposing || this.information.IsDisposed)
                        return;
                }
                setnewthreadint = new setNewThreadInt(setinformation);
                this.information.Invoke(setnewthreadint, new object[] { TextString });
            }
            else
            {
                //这里就回到了主线程？！！厉害了，这个机制
                 information.AppendText("\r\n" +TextString);     // 追加文本，并且使得光标定位到插入地方。
　               information.ScrollToCaret();
            }
        }


        //更新主任务窗体
        int UrlCountLegth = 0;
        int UrlTimeoutcount = 0;
        int UrlCompletecount = 0;
        void setUrlCount(string TextString)
        {
            UrlTimeoutcount = 0;
            UrlCompletecount = 0;
            UrlCountLegth = 0;
            if (this.UrlCount.InvokeRequired)
            {
                while (!this.UrlCount.IsHandleCreated)
                {
                    //解决窗体关闭时出现“访问已释放句柄“的异常
                    if (this.UrlCount.Disposing || this.UrlCount.IsDisposed)
                        return;
                }
                setnewthreadint = new setNewThreadInt(setUrlCount);
                this.UrlCount.Invoke(setnewthreadint, new object[] { TextString.ToString() });
            }
            else
            {
                //回到了主线程
             
                //问题所在，因为已经new过，但是没有值，会报一个索引超出的问题，暂时用try做处理
                
                try
                {
                    for (int i = 0; i < NewThreadint.Count; i++)
                    {
                        UrlCountLegth += NewThreadint[i][1];
                        UrlTimeoutcount += NewThreadint[i][4];
                        UrlCompletecount += NewThreadint[i][5];
                    }
                    UrlCount.Text = UrlCountLegth.ToString();
                    UrlTimeoutCount.Text = UrlTimeoutcount.ToString();
                    UrlCompleteCount.Text = UrlCompletecount.ToString();
                    complete.Text = (UrlCountLegth - UrlTimeoutcount - UrlCompletecount).ToString();
                    TimeLagth.Text = TimerInt_DateTimer(((UrlCountLegth - UrlTimeoutcount - UrlCompletecount) * 5));
                }
                catch (Exception)
                {
                   
                }
            }
        }

        //↑↑↑↑↑↑↑↑↑更新UI↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

        /// <summary>当前下拉列表的索引
        /// </summary>
        int ComboboxIndex =0;
        //窗体事件
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboboxIndex = comboBox1.SelectedIndex;
        }

        bool informationBool = true;
        private void informationBut_Click(object sender, EventArgs e)
        {
            if (informationBool)
            {
                informationBool = false;
                informationBut.Text = "开启";
                information.Clear();
            }
            else {
                informationBool = true;
                informationBut.Text = "关闭并清理";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text==""||textBox1.Text==null||comboBox2.Items.Count<2)
            {
                MessageBox.Show("网页url或者是正则表达式未输入");
                return;
            }
            button5.Enabled = true;
            timer1.Start();
            NewThreadint = new List<List<int>>();
            for (int i = 0; i < int.Parse(numericUpDown3.Value.ToString()); i++)
            {
                //申请子线程数量的内存空间
                NewThreadint.Add(new List<int>());
                //初始化下拉列表
                setinformation("以完成第" + i + "个子线程的内存申请");
                comboBox1.Items.Add("第" + i + "个子线程");
            }
            //---
            Pa = new PaCong_Thread();


            Pa.HtmlUrlGo = "http://" + textBox1.Text;
            Pa.ThreadListLength =int.Parse(numericUpDown3.Value.ToString());
            Pa.WaiLianPaQu = checkBox1.Checked;
            Pa.WebTimer = int.Parse((numericUpDown1.Value * 1000).ToString());
            Pa.ChaoShiLength = int.Parse(numericUpDown2.Value.ToString());
            Pa.HtmlmatchingString = Html_parsinglist;
            Pa.Html_parsing_string = Html_parsing_Namelist;
            Pa.PaCongGo(this,this);
           
        }


        //---------------自定义正则表达式--------------

        //输入窗体的对话
        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex+1 == comboBox2.Items.Count)
            {
                TextDialog textdialog = new TextDialog();
                textdialog.form_textdialog = this;
                textdialog.Text = "自定义正则表达式匹配符";
                if (Html_parsinglist != null)
                {
                    for (int i = 0; i < Html_parsinglist.Count; i++)
                    {
                        if (i == 0)
                        {
                            textdialog.addText(Html_parsinglist[i]);
                            continue;
                        }
                        textdialog.addText("\r\n" + Html_parsinglist[i]);
                    }
                }
                textdialog.Show();
            }
        }

        private List<string> Html_parsinglist = null;
        private List<string> Html_parsing_Namelist = null;


        /// <summary>保存输入框窗体的正则表达式匹配符
        /// </summary>
        public void Html_parsing(List<string> String_)
        {
            Html_parsinglist = String_;
            comboBox2.Items.Clear();
            comboBox2.Items.Add("新增");
            for (int i = 0; i < String_.Count; i++)
            {
                comboBox2.Items.Insert(i, String_[i]);
            }
        }

        /// <summary>保存输入框窗体的正则表达式匹配符NAme
        /// </summary>
        public void Html_parsing_Name(List<string> String_)
        {
            Html_parsing_Namelist=String_;
            comboBox3.Items.Clear();
            comboBox3.Items.Add("新增");
            for (int i = 0; i < String_.Count; i++)
            {
                comboBox3.Items.Insert(i, String_[i]);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex+1 == comboBox3.Items.Count)
            {
                TextDialog textdialog = new TextDialog();
                textdialog.form_textdialog = this;
                textdialog.Text = "自定义正则表达式匹配符Name";
                if (Html_parsing_Namelist != null)
                {
                    for (int i = 0; i < Html_parsing_Namelist.Count; i++)
                    {
                        if (i == 0)
                        {
                            textdialog.addText(Html_parsing_Namelist[i]);
                            continue;
                        }
                        textdialog.addText("\r\n" + Html_parsing_Namelist[i]);
                    }
                }
                textdialog.Show();
            }
        }

        //---------------自定义正则表达式--------------

        private void button2_Click(object sender, EventArgs e)
        {
            TextDialog textdialog = new TextDialog();
            textdialog.form_textdialog = this;
            textdialog.Text = "查看子线程" + (ComboboxIndex - 1) + "的超时链接";
            List<int> list = Pa.getTimeoutUrl(ComboboxIndex-1);
            for (int i = 0; i < list.Count; i++)
            {
                textdialog.addText("\r\n" +Pa.getListUrl(list[i]));
            }
            textdialog.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextDialog textdialog = new TextDialog();
            textdialog.form_textdialog = this;
            textdialog.Text = "查看子线程" + (ComboboxIndex-1) + "已完成的链接";
            List<int> list = Pa.getOKUrl(ComboboxIndex-1);
            for (int i = 0; i < list.Count; i++)
            {
                textdialog.addText("\r\n" + Pa.getListUrl(list[i]));
            }
            textdialog.Show();
        }
        /// <summary>取消or暂停
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            Pa.ThreadStop();
            //Form2 form = new Form2();
            //List<List<string>> LIst=new List<List<string>>();
            //for (int i = 0; i < 20; i++)
            //{
            //    List<string> Lis = new List<string>();
            //    Lis.Add("A1");
            //    Lis.Add("B1");
            //    LIst.Add(Lis);
            //}
            //form.AddlistString(LIst);
            //form.Show();

        }
        Form2 form2;
        public void ShowForm2()
        {
            form2 = new Form2();
            form2.Show();
        }

        public void AddListString(List<List<string>> list)
        {
            form2.AddlistString(list);
        }

        public void AddListitemString(List<string> list)
        {
            form2.AddListItemSting(list);
        }

        int TimeIndex = 0;
        /// <summary>耗时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeIndex += 1;
            TimeOut.Text = TimerInt_DateTimer(TimeIndex);
        }

        private string TimerInt_DateTimer(int dataTimeIndex) {

            if (dataTimeIndex > 3600)
            {
                return (dataTimeIndex / 3600).ToString() + ":" + ((dataTimeIndex % 3600) / 60).ToString() + ":" + (dataTimeIndex % 3600 % 60);
            }
            else if (dataTimeIndex > 60)
            {
                return "00:" + (dataTimeIndex / 60).ToString() + ":" + (dataTimeIndex % 60);
            }
            else
            {
                return "00:00:" + dataTimeIndex;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
        //-----------------------------------
    }
}
