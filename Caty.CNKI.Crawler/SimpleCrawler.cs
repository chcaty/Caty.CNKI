using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Caty.CNKI.Crawler.Events;

namespace Caty.CNKI.Crawler
{
    public class SimpleCrawler : ICrawler
    {
        // 爬虫启动事件
        public event EventHandler<OnStartEventArgs> OnStart;
        // 爬虫完成事件
        public event EventHandler<OnCompletedEventArgs> OnCompleted;
        // 爬虫出错事件
        public event EventHandler<OnErrorEventArgs> OnError;
        // 定义Cookie容器
        public CookieContainer CookiesContainer { get; set; }

        public SimpleCrawler() { }

        /// <summary>
        /// 异步创建爬虫
        /// </summary>
        /// <param name="uri">爬虫URL地址</param>
        /// <param name="proxy">代理服务器</param>
        /// <returns>网页源代码</returns>
        public async Task<string> Start(Uri uri, string proxy = null)
        {
            return await Task.Run(async () =>
            {
                var pageSource = string.Empty;
                try
                {
                    if (this.OnStart != null)
                    {
                        this.OnStart(this, new OnStartEventArgs(uri));
                    }
                    var watch = new Stopwatch();
                    watch.Start();
                    using (HttpClient http = new HttpClient())
                    {
                        pageSource = await http.GetStringAsync(uri);
                    }
                    watch.Stop();
                    var threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;//获取当前任务线程ID
                    var milliseconds = watch.ElapsedMilliseconds;//获取请求执行时间
                    if (this.OnCompleted != null)
                    {
                        this.OnCompleted(this, new OnCompletedEventArgs(uri, threadId, milliseconds, pageSource));
                    }
                }
                catch (Exception ex)
                {
                    if (this.OnError != null) this.OnError(this, new OnErrorEventArgs(uri, ex));
                }
                return pageSource;
            });
        }
    }
}
