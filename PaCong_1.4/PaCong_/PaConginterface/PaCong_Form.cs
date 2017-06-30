using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaConginterface
{
    /// <summary>当前接口用于实现更新窗口数据，被窗口继承
    /// </summary>
   public interface PaCong_Form
    {
       /// <summary>能开启的子线程的最大值
       /// </summary>
       /// <returns></returns>
        void NewThreadLength(int index);

       /// <summary>当前开启的子线程
       /// </summary>
       /// <param name="index"></param>
       /// <returns></returns>
        void NewThreadIndex(int index);

       /// <summary>当前子线程执行int类型数据
       /// </summary>
       /// <param name="index"></param>
       /// <returns>
       /// 1.子线程对应的下标
       /// 2.子线程当前执行任务的下标
       /// 3.子线程当前任务的最大值
       /// 4.子线程执行过程的超时数量
       /// 没有为0
       /// </returns>
        void NewThreadIndexint(List<int> index);

       /// <summary>当前子线程执行string类型数据
       /// </summary>
       /// <param name="index"></param>
       /// <returns>
       /// 1.子线程下标
       /// 2.URl总量
       /// 3.子线程当前执行的任务url
       /// 4.子线程任务终点
       /// 5.子线程当前超时链接
       /// 6.已完成总量
       /// </returns>
        void NewThreadIndexstring(List<List<string>> index);

       /// <summary>直接更新窗体中的信息框
       /// </summary>
       /// <param name="stringval"></param>
        void UpdateXinXi(string stringval);
    }
}
