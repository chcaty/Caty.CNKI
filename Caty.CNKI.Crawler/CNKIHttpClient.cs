using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Caty.CNKI.Crawler
{
    public class CNKIHttpClient:HttpClient
    {
        public CNKIHttpClient(string Uri)
        {
            BaseAddress = new Uri(Uri);
            Timeout = TimeSpan.FromSeconds(30);
            DefaultRequestHeaders.Clear();
            DefaultRequestHeaders.Add("Accept", "text/html");
            DefaultRequestHeaders.Connection.Add("Keep-Alive");
        }
    }
}
