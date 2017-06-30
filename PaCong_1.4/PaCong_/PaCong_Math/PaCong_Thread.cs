using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PaConginterface;
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
        public int ThreadListLength = 5;

        /// <summary>用于保存子线程需要公开的数据
        /// </summary>
        private List<PaCong_NewThread> parsing_stringThread = new List<PaCong_NewThread>();

        PaCong_parsing parsing;
        PaCong_Form paCong_Form { get; set; }

        public void PaCongGo(PaCong_Form paCong_Form)
        {
            this.paCong_Form = paCong_Form;
            //解析初始化
            PaCong_parsing_string parsing_string = new PaCong_parsing_string();
            parsing = new PaCong_parsing();
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
                NewThread.WebTimer = 5000;
                NewThread.ListIndex = 0;
                NewThread.ListLength = 1;
                NewThread.pacong_form = paCong_Form;
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
                NewThread_.WebTimer = 5000;
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
            //parsing.Url
            //获取URL↑
            //parsing.paCong_parsing_string.getHtml_parsing
            //parsing.paCong_parsing_string.getHtml_parsing_string
            //parsing.paCong_parsing_string.getHtml_parsinglist
            //分析的数据与规则↑
        }
    }
}
