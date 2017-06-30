using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PaCong_Math
{
    /// <summary>用于解析HTML代码
    /// 
    /// </summary>
   public class PaCong_parsing
    {
       /// <summary>保存获取到的URL链接
       /// </summary>
      public  List<string> Url = new List<string>();


      /// <summary>初始化链接的主要链接，用于判断是否是外链
      /// </summary>
      public string UrlMath = "";

       /// <summary>自设的解析方式保存集合
       /// </summary>
       List<List<string>> Url_parsing = new List<List<string>>();

       /// <summary>资源文件是否保存
       /// </summary>
       public bool ZiYuanBaoChun = true;


       /// <summary>保存非外链的html页
       /// </summary>
       public bool HtmlBaoChun = false;

       public PaCong_parsing_string paCong_parsing_string { get; set; }

       ResourcesDownload dl = new ResourcesDownload();

       /// <summary>检查HTML代码，匹配到的内容保存至集合中
       /// </summary>
       /// <param name="Html">HTMl代码</param>
       /// <returns>0为没有匹配，大于为匹配数量</returns>
       public void parsing(int index,string Html) {
           //变量,储存正则表达式检索到的集合
           MatchCollection Html_url;

           MatchCollection Html_parsing;

           string[] UrlMathlinshi;
           string UrlLinshi;

           UrlMath = Url[index];
           UrlMathlinshi=UrlMath.Split('/');
           string[] UrlMath__ = UrlMath.Split(new string[] { Url[0] }, StringSplitOptions.None);
           if (HtmlBaoChun ||  UrlMath__.Length>0)
           {
               dl.ResourcesDownload_(UrlMath, @"C:\Users\Administrator.WIN-20160427JSS\Desktop\PaCong_\text\" + Regex.Replace(UrlMath, @"\W", "") + ".html");
           }
           Html_url = Regex.Matches(Html, paCong_parsing_string.Url_parsing);
           foreach (Match item in Html_url)
	        {
                string ItemString = item.Groups[1].Value;
                if (Regex.IsMatch(ItemString,"javascript")||Regex.IsMatch(ItemString,"#"))
                {
                    continue; 
                }
               //外链检测--------------------------------
                if (Regex.Matches(ItemString, "http.*").Count == 0)
                {
                    //非外链添加前缀
                    ItemString = UrlMath + ItemString;
                    //重复检测
                    if (Url.IndexOf(item.Groups[1].Value) == -1)
                    {
                        Url.Add(ItemString);
                    }
                } 
                else {
                
                }
               ////重复检测
                if (Url.IndexOf(item.Groups[1].Value) == -1)
                {
                    Url.Add(ItemString);
                }
	        }
           //自定义正则表达式匹配
           if (paCong_parsing_string.getHtml_parsing().Count==0)
           {
               return;
           }
           for (int i = 0; i < paCong_parsing_string.getHtml_parsing().Count; i++)
           {
              Html_parsing =Regex.Matches(Html, paCong_parsing_string.getHtml_parsing()[i]);
              foreach (Match item in Html_parsing)
              {
                  //ZiYuanDowadlod(item, "", UrlMathlinshi, i);
                  paCong_parsing_string.setHtml_parsinglist(i, item.Groups[1].Value);
              }
           }
       }

       /// <summary>设置自定义解析方式
       /// </summary>
       /// <param name="HtmlmatchingString">自定义正则表达式</param>
       /// <param name="Html_parsing_string">自定义正则表达式英文列名</param>
       public void setHtmlmatchingString(List<string> HtmlmatchingString, List<string> Html_parsing_string)
       {
           paCong_parsing_string.setHtmlParsing(HtmlmatchingString);
           paCong_parsing_string.setHtml_parsing_string(Html_parsing_string);
       }

       private string String__String(string[] A){
           string B = "";
           for (int i = 0; i < A.Length; i++)
           {
               B += A[i];
           }
           return B;
       }

       /// <summary>资源下载
       /// </summary>
       private void ZiYuanDowadlod(Match item, string UrlLinshi, string[] UrlMathlinshi, int i)
       {
           if (Regex.Matches(item.Groups[1].Value, "http.*").Count == 0)
           {
               //没有http说明他不是外部图片,引用的是当前域名的图片
               //需要判断他是否有“../”上一层
               string[] linshi = item.Groups[1].Value.Split(new string[] { "../" }, StringSplitOptions.None);
               string[] urlhttp = item.Groups[1].Value.Split(new string[] { "http://", "//" }, StringSplitOptions.None);
               if (urlhttp.Length == 0)
               {
                   //非外链添加前缀
                   UrlLinshi = "http://";
                   for (int i1 = 2; i1 < UrlMathlinshi.Length - linshi.Length; i1++)
                   {
                       UrlLinshi += UrlMathlinshi[i1] + "/";
                   }
                   UrlLinshi += linshi[linshi.Length - 1];
                   paCong_parsing_string.setHtml_parsinglist(i, UrlLinshi);
                   //资源文件是否保存
                   //暂时为true
                   if (ZiYuanBaoChun)
                   {
                       dl.ResourcesDownload_(UrlLinshi, @"C:\Users\Administrator.WIN-20160427JSS\Desktop\PaCong_\text\" + linshi[linshi.Length - 1]);
                   }
               }
               else
               {
                   linshi = item.Groups[0].Value.Split(new string[] { "href", "src" }, StringSplitOptions.None);
                   if (linshi.Length > 1)
                   {
                       paCong_parsing_string.setHtml_parsinglist(i, UrlMath + item.Groups[1].Value);
                   }
                   else
                   {
                       paCong_parsing_string.setHtml_parsinglist(i, item.Groups[0].Value);
                   }
                   if (ZiYuanBaoChun)
                   {
                       dl.ResourcesDownload_(item.Groups[1].Value, @"C:\Users\Administrator.WIN-20160427JSS\Desktop\PaCong_\text\" + item.Groups[1].Value);
                   }

               }

           }
           else
           {
               paCong_parsing_string.setHtml_parsinglist(i, item.Groups[1].Value);
           }
       }
    }
}
