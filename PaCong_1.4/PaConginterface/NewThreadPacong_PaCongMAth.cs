using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaConginterface
{

    /// <summary>当前于接口用与爬虫子线程获取爬虫主线程参数，被爬虫主线程继承
    /// </summary>
   public interface NewThreadPacong_PaCongMAth
    {

       /// <summary>任务从指定索引开始,爬虫主线程分配的任务
       /// </summary>
       /// <returns></returns>
       List<int> getListGo();

       /// <summary>指定索引对应的URL路径
       /// </summary>
       /// <returns></returns>
       string getListUrl(int index);

       /// <summary>子线程获取的html代码回传到主线程中，进行解析
       /// </summary>
       /// <param name="index">URL索引</param>
       /// <param name="Html">html代码</param>
       void SetHtml(int index,string Html);

       /// <summary>获取URL总量
       /// </summary>
       /// <returns></returns>
       int getUrlCount();
    }
}
