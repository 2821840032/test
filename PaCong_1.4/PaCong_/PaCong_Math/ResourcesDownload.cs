using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace PaCong_Math
{
    /// <summary>下载指定url到指定位置
    /// </summary>
   public class ResourcesDownload
    {
       
       /// <summary>从网上下载资源文件
       /// </summary>
       /// <param name="FileUrl">资源文件地址</param>
       /// <param name="FielBaoCun">保存地址加文件名与后缀</param>
       public void ResourcesDownload_(string FileUrl, string FielBaoCun) {
           if (File.Exists(FielBaoCun))
           {
               return;
           }
           System.IO.Directory.CreateDirectory(FielBaoCun);//不存在就创建目录 
           Directory.Delete(FielBaoCun, false);
           Uri url=new Uri(FileUrl);
           WebClient webClient = new WebClient();
           try
           {
               webClient.DownloadFile(url, FielBaoCun);
           }
           catch (Exception)
           {
               
               throw;
           }
          
       }
    }
}
