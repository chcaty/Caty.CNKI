using System;
using System.Collections.Generic;
using System.Text;

namespace Caty.CNKI.Crawler.Events
{
    /// <summary>
    /// 爬虫错误事件
    /// </summary>
    public class OnErrorEventArgs
    {
        /// <summary>
        /// 爬虫URL地址
        /// </summary>
        public Uri Uri { get; set; }
        /// <summary>
        /// 爬虫异常信息
        /// </summary>
        public Exception Exception { get; set; }

        public OnErrorEventArgs(Uri uri,Exception exception)
        {
            this.Uri = uri;
            this.Exception = exception;
        }
    }
}
