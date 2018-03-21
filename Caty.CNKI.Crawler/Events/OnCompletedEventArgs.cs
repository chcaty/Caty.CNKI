using System;
using System.Collections.Generic;
using System.Text;

namespace Caty.CNKI.Crawler.Events
{
    /// <summary>
    /// 爬虫完成事件
    /// </summary>
    public class OnCompletedEventArgs
    {
        /// <summary>
        /// 爬虫URL地址
        /// </summary>
        public Uri Uri { get; private set; }
        /// <summary>
        /// 任务线程ID
        /// </summary>
        public int ThreadId { get; private set; }
        /// <summary>
        /// 页面源代码
        /// </summary>
        public string PageSource { get; private set; }
        /// <summary>
        /// 爬虫请求执行时间
        /// </summary>
        public long Milliseconds { get; private set; }

        public OnCompletedEventArgs(Uri uri, int threadId, long millseconds, string pageSource)
        {
            this.Uri = uri;
            this.ThreadId = threadId;
            this.PageSource = pageSource;
            this.Milliseconds = millseconds;
        }
    }
}
