using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PaConginterface;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using System.Reflection;
using System.Collections;

namespace PaCong_Math
{
    public class PaCong_Thread : NewThreadPacong_PaCongMAth, Form_PaCongMAth
    {
        /// <summary>最初始化的链接
        /// </summary>
        public string HtmlUrlGo { get; set; }

        /// <summary>已经分配完毕的数量
        /// </summary>
        public int UrlIndex = 0;

        /// <summary>线程池
        /// </summary>
        public List<Thread> ThreadList = new List<Thread>();

        /// <summary>最大开启的子线程数量，默认为5
        /// </summary>
        public int ThreadListLength { get; set; }

        /// <summary>用于保存子线程需要公开的数据
        /// </summary>
        private List<PaCong_NewThread> parsing_stringThread = new List<PaCong_NewThread>();

        PaCong_parsing parsing;
        /// <summary>数据分析的外链爬取判断
        /// </summary>
        public bool WaiLianPaQu { get; set; }

        PaCong_Form paCong_Form { get; set; }

        public void PaCongGo(PaCong_Form paCong_Form, form2_NewThreadInterface Form2_NewThreadInterface)
        {
            this.Form2_NewThreadInterface = Form2_NewThreadInterface;
            this.paCong_Form = paCong_Form;
            //解析初始化
            PaCong_parsing_string parsing_string = new PaCong_parsing_string();
            parsing = new PaCong_parsing();
            parsing.WaiLianPaQu = WaiLianPaQu;
            parsing.paCong_parsing_string = parsing_string;
            parsing.setHtmlmatchingString(HtmlmatchingString, Html_parsing_string);
            //差页面上的自定义正则表达式匹配到这里
            //----
            //URL初始化
            parsing.Url.Add(HtmlUrlGo);
            parsing.UrlMath = HtmlUrlGo.Split('/')[0] + "//" + HtmlUrlGo.Split('/')[2];
            //----
            //接口初始化
            if (paCong_Form==null)
            {
                return;
            }
            //----
            paCong_Form.NewThreadLength(ThreadListLength);
            //在进行子线程前需要对数据进行采集，获取网络流量并对子线程分配任务
            PaCong_NewThread NewThread = new PaCong_NewThread();
                NewThread.newThreadPacong_PaCongMAth = this;
                NewThread.WebTimer = WebTimer;
                NewThread.ChaoShiLength = ChaoShiLength;
                NewThread.ListIndex = 0;
                NewThread.ListLength = 1;
                NewThread.TimeoutUrl = new List<int>();
                NewThread.pacong_form = paCong_Form;
                NewThread.OkUrl = new List<int>();
                NewThread.NewThread();
                UrlIndex += 1;

            for (int i = 0; i < ThreadListLength; i++)
            {
                //分配任务和子线程初始化操作
                PaCong_NewThread NewThread_ = new PaCong_NewThread();
                NewThread_.newThreadPacong_PaCongMAth = this;
                List<int> li = getListGo();
                if (li==null)  {continue; }
                NewThread_.ThreadIndex = i;
                NewThread_.WebTimer = WebTimer;
                NewThread_.TimeoutUrl = new List<int>();
                NewThread_.OkUrl = new List<int>();
                NewThread_.ChaoShiLength = ChaoShiLength;
                NewThread_.pacong_form = paCong_Form;
                NewThread_.ListIndex = li[0];
                NewThread_.ListLength = li[1];
                Thread Th = new Thread(NewThread_.NewThread);
                ThreadList.Add(Th);
                parsing_stringThread.Add(NewThread_);
                Th.Start();
            }
            paCong_Form.NewThreadIndex(ThreadListLength);
        }

        //爬虫子线获取主线程的任务
        object locker = new object();
        //1,开始于Index，2，结束于Index
        public List<int> getListGo()
        {
            //线程锁，一次只能有一个线程操作这个函数
            lock (locker)
            {
                if (parsing.Url.Count == UrlIndex) {return null;}//如果没有剩余URL就放回null
                List<int> getlist = new List<int>();
                if (parsing.Url.Count - UrlIndex <= ThreadListLength)
                {
                    //如果剩余URL小于线程数量，就全部分配给一个线程
                    getlist.Add(UrlIndex);
                    UrlIndex += parsing.Url.Count;
                    getlist.Add(UrlIndex);
                    return getlist;
                }
                else{
                    //平均分配任务
                    int UrlIndex_ = (parsing.Url.Count - UrlIndex) / ThreadListLength;;
                    getlist.Add(UrlIndex);
                    UrlIndex+=UrlIndex_;
                    getlist.Add(UrlIndex);
                    return getlist;
                }
            }
        }
        /// <summary>获取指定索引的url
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string getListUrl(int index)
        {
            return parsing.Url[index];
        }

        public void SetHtml(int index,string Html) {
            parsing.parsing(index,Html);
            //子线程已经完成，数据分析
        }

        public int getUrlCount()
        {
           return parsing.Url.Count;
        }

        /// <summary>自定义解析方式正则表达式
        /// </summary>
        public List<string> HtmlmatchingString { get; set; }
        /// <summary>自定义解析方式英文名称
        /// </summary>
        public List<string> Html_parsing_string { get; set; }

        public int WebTimer { get; set; }
        public int ChaoShiLength { get; set; }




        /// <summary>获取子线程超时URL
        /// </summary>
        public   List<int> getTimeoutUrl(int Index)
        {
           return parsing_stringThread[Index].TimeoutUrl;
        }
        /// <summary>获取子线程完成URL
        /// </summary>
        public List<int> getOKUrl(int Index)
        {
            return parsing_stringThread[Index].OkUrl;
        }


        public form2_NewThreadInterface Form2_NewThreadInterface;
        /// <summary>取消所有子线程
        /// </summary>
        public void ThreadStop() {
            List<NewThreadModle> NewThreadModleList = new List<NewThreadModle>();
            for (int i = 0; i < parsing_stringThread.Count; i++)
            {
                paCong_Form.UpdateXinXi("以停止第" + i + "个子线程");
                parsing_stringThread[i].ThreadStopvoid(false);
                //获取子线程的数据
                NewThreadModleList.Add(parsing_stringThread[i].NewThreadModle);
                //差获取子线程的数据并保存
            }
            //获取URL与匹配对象
            List<String> listurl= parsing.Url;
            //获取URL↑
            //List<String> list1= parsing.paCong_parsing_string.getHtml_parsing();
            //List<String> list2= parsing.paCong_parsing_string.getHtml_parsing_string();
            //分析的数据与规则↑
            Form2_NewThreadInterface.ShowForm2();
            //保存列名
            //list3.Insert(0, listurl);
            Form2_NewThreadInterface.AddListString(parsing.paCong_parsing_string.getHtml_parsinglist());
        }
        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="lists"></param>
        /// <param name="head">中文列名对照</param>
        /// <param name="workbookFile">保存路径</param>
        public void getExcel(List<string> lists, string workbookFile)
        {
            try
            {
                HSSFWorkbook workbook = new HSSFWorkbook();
                MemoryStream ms = new MemoryStream();
                HSSFSheet sheet = workbook.CreateSheet() as HSSFSheet;
                HSSFRow headerRow = sheet.CreateRow(0) as HSSFRow;
                bool h = false;
                int j = 1;
                Type type = typeof(string);
                PropertyInfo[] properties = type.GetProperties();

                foreach (string item in lists)
                {
                    HSSFRow dataRow = sheet.CreateRow(j) as HSSFRow;
                    int i = 0;
                    foreach (PropertyInfo column in properties)
                    {
                        if (!h)
                        {
                            dataRow.CreateCell(i).SetCellValue(column.GetValue(item, null) == null ? "" : column.GetValue(item, null).ToString());
                        }
                        else
                        {
                            dataRow.CreateCell(i).SetCellValue(column.GetValue(item, null) == null ? "" : column.GetValue(item, null).ToString());
                        }

                        i++;
                    }
                    h = true;
                    j++;
                }
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;
                sheet = null;
                headerRow = null;
                workbook = null;
                FileStream fs = new FileStream(workbookFile, FileMode.Create, FileAccess.Write);
                byte[] data = ms.ToArray();
                fs.Write(data, 0, data.Length);
                fs.Flush();
                fs.Close();
                data = null;
                ms = null;
                fs = null;
            }
            catch (Exception ee)
            {
                string see = ee.Message;
            }
        }
    }
    }
