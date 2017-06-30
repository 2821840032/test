using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PaCong_Math
{
    public class PaCong_parsing_string
    {
        /// <summary>默认的URL解析方式
        /// </summary>
        public string Url_parsing = "<a.*href=\"(.+?)\".*>";
        //<img.*src=\"(.+?)\".*>
        //<script type="text/javascript" src="js/jquery.js"></script>
        //<script.*src=\"(.+?)\".*>
        //<link href="css/default.css" type="text/css" rel="stylesheet">
        //<link.*href=\"(.+?)\".*>
        /// <summary>自设的解析方式
        /// </summary>
        List<string> Html_parsing = new List<string>();
        /// <summary>自设解析方式正则表达式
        /// </summary>
        /// <param name="htmlparsing"></param>
        public void setHtmlParsing(List<string> htmlparsing) {
            if (htmlparsing==null)
            {
                return;
            }
            Html_parsing = htmlparsing;
            Html_parsinglist = new List<List<string>>();
            for (int i = 0; i < Html_parsing.Count; i++)
            {
                Html_parsinglist.Add(new List<string>());
            }
        }
        /// <summary>获取自定义正则表达式
        /// </summary>
        /// <returns></returns>
        public List<string> getHtml_parsing() {return Html_parsing;}

        /// <summary>自设解析方式对应的列名
        /// </summary>
        List<string> Html_parsing_string = new List<string>();
        /// <summary>设置自设解析方式的列名
        /// </summary>
        /// <param name="html_parsing_string"></param>
        public void setHtml_parsing_string(List<string> html_parsing_string)
        {
            List<string> htmlstring = new List<string>();
            for (int i = 0; i < Html_parsing.Count; i++)
			{
                if (html_parsing_string.Count<i+1)
                {
                    htmlstring.Add("item" + i);
                    continue;
                }
                if (HasChinese(html_parsing_string[i])) { htmlstring.Add("item" + i); } else { htmlstring.Add(html_parsing_string[i]); } 
			}
            Html_parsing_string = htmlstring;
        }
        /// <summary>获取自定义正则表达式列名
        /// </summary>
        /// <returns></returns>
        public List<string> getHtml_parsing_string() {
            return Html_parsing_string;
        }

        /// <summary>用于保存获取到的数据
        /// </summary>
        List<List<string>> Html_parsinglist = new List<List<string>>();
        /// <summary>保存获取到的数据
        /// </summary>
        /// <param name="Index">对应list下标</param>
        /// <param name="parsing">数据</param>
        public void setHtml_parsinglist(int Index, string parsing)
        {
            Html_parsinglist[Index].Add(parsing);
        }
        /// <summary>获取保存的自定义数据
        /// </summary>
        /// <returns></returns>
        public List<List<string>> getHtml_parsinglist() {return Html_parsinglist;}


        /// <summary>判断字符串中是否包含中文
        /// </summary>
        /// <param name="str">需要判断的字符串</param>
        /// <returns>判断结果</returns>
        public static bool HasChinese(string str)
        {
            return Regex.IsMatch(str, @"[\u4e00-\u9fa5]");
        }

    }
}
