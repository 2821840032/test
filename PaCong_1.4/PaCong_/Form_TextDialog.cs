using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaCong_
{
    /// <summary>输入框与主窗体之间的对话
    /// </summary>
   public interface Form_TextDialog
    {
       /// <summary>保存自定义匹配符正则表达式
       /// </summary>
       void Html_parsing(List<string> String_);
       /// <summary>保存自定义匹配符正则表达式NAme
       /// </summary>
       void Html_parsing_Name(List<string> String_);
    }
}
