using System;
using System.Collections.Generic;
using System.Text;

namespace Caty.CNKI.Crawler.Events
{
    /// <summary>
    /// 爬虫开始事件
    /// </summary>
    public class OnStartEventArgs
    {
        /// <summary>
        /// 爬虫URL地址
        /// </summary>
        public Uri Uri { get; set; }

        public OnStartEventArgs(Uri uri)
        {
            this.Uri = uri;
        }
    }
}
