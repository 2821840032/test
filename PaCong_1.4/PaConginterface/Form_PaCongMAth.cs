using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaConginterface
{
    /// <summary>当前接口用于实现窗口控制爬虫主线程，被爬虫主线程继承
    /// </summary>
    public interface Form_PaCongMAth
    {
        List<int>  getTimeoutUrl(int Index);
        List<int> getOKUrl(int Index);
    }
}
