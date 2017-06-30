using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaCong_Math
{
   public interface NewThreadModle
    {
        /// <summary>线程索引
        /// </summary>
        int ThreadIndex { get; set; }

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

        //------------------超时变量------------

        /// <summary>超时最大次数
        /// </summary>
        public int ChaoShiLength = 5;

        /// <summary>子线程完成数量
        /// </summary>
        public int NewThreadUrlIndex = 0;
    }
}
