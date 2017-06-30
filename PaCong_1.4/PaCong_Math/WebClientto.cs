using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PaCong_Math
{
    //WebClient重新，新增超时功能
    class WebClientto :WebClient
    {
        int Timeout { get; set; }
        public WebClientto(int Time) {
            Timeout = Time;
        }

        protected override WebRequest GetWebRequest(Uri address) {
            HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(address);
            request.Timeout = Timeout;
            request.ReadWriteTimeout = Timeout;
            return request;  
        }
        
    }
}
