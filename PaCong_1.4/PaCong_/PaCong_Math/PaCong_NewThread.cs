﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaConginterface;
using System.Net;
namespace PaCong_Math
{
    /// <summary>执行URL访问任务的线程
    /// </summary>
    public class PaCong_NewThread:NewThreadModle
    {
        //两种方案，一种URL放在主线程中，子线程调用，另一种分配给子线程，主线程删除 
        //使用保存在主线程的方案，子线程只保存主线程分配的任务索引，

        /// <summary>线程索引
        /// </summary>
        public int ThreadIndex { get; set; }

        /// <summary>获取或设置连接超时时间,默认为5秒，单位：毫秒
        /// </summary>
        public int WebTimer = 5000;

        /// <summary>设置任务的终点索引
        /// </summary>
        public int ListLength { get; set; }

        /// <summary>[废弃的]设置任务开始的索引
        /// </summary>
        public int ListGO { get; set; }

        /// <summary>当前任务执行的索引
        /// </summary>
        public int ListIndex = 0;

        /// <summary>子线程超时url索引
        /// </summary>
        public List<int> TimeoutUrl = new List<int>();

        /// <summary>完成的URL索引
        /// </summary>
        public List<int> OkUrl = new List<int>();

        public NewThreadPacong_PaCongMAth newThreadPacong_PaCongMAth { get; set; }

        public PaCong_Form pacong_form { get; set; }

        //------------------超时变量------------
        /// <summary>超时次数
        /// </summary>
        int ChaoShiIndex = 0;

        /// <summary>超时最大次数
        /// </summary>
        public int ChaoShiLength = 5;



        //-------------------其余变量------------------

        /// <summary>子线程完成数量
        /// </summary>
        public int NewThreadUrlIndex = 0;


        /// <summary>回传到页面的数据
        /// </summary>
        List<int> list= new List<int>();

        public NewThreadModle NewThreadModle { get { return this; } }

        WebClientto wc;
        

        /// <summary>执行函数
        /// </summary>
        public void NewThread() {
            wc = new WebClientto(WebTimer);//重写的webclient,重写了超时功能，超时时间可以自己定也可以根据网络状况实时更改
            wc.Encoding = Encoding.UTF8;
            //编码为UTF-8



            //如果执行的索引小于分配的任务索引，就进行URL的解析
            //大问题，如果用递归会有溢出，可以用for么？,还是用while吧
            while (ListIndex < ListLength)
            {
                if (!ThreadStop)
                {
                    return;
                    //取消操作，完成
                }
                //超时报错，用try块就行了
                try
                {
                    newThreadPacong_PaCongMAth.SetHtml(ListIndex, wc.DownloadString(newThreadPacong_PaCongMAth.getListUrl(ListIndex)));
                    OkUrl.Add(ListIndex);
                }
                catch (Exception)
                {
                    //超时代码
                    ChaoShiIndex++;
                    if (ChaoShiIndex < ChaoShiLength){
                        continue;
                    }
                    else{
                        TimeoutUrl.Add(ListIndex);
                    }
                 }
                //执行完毕

                //返回数据到页面
                list.Clear();
                list.Add(ThreadIndex);
                list.Add(newThreadPacong_PaCongMAth.getUrlCount());
                list.Add(ListIndex);
                list.Add(ListLength);
                list.Add(TimeoutUrl.Count);
                list.Add(NewThreadUrlIndex);
                pacong_form.NewThreadIndexint(list);
                //----

                ChaoShiIndex = 0;
                ListIndex++;
                NewThreadUrlIndex++;
                if (ListIndex == 1)
                {
                    return;
                }
            }
            if (ThreadStop)
            {
                //索引执行完毕，重新获取分配任务
                List<int> A = newThreadPacong_PaCongMAth.getListGo();
                if (A != null)
                {
                    ListIndex = A[0];
                    ListLength = A[1];
                    NewThread();
                }
            } 
        }
        
        /// <summary>true为执行，false为停止
        /// </summary>
        bool ThreadStop=true;
        public void ThreadStopvoid(bool Judge) {
            ThreadStop = Judge;
        }
        }
    }