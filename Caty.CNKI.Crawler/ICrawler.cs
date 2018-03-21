using Caty.CNKI.Crawler.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Caty.CNKI.Crawler
{
    public interface ICrawler
    {
        // 爬虫启动事件
        event EventHandler<OnStartEventArgs> OnStart;

        // 爬虫完成事件
        event EventHandler<OnCompletedEventArgs> OnCompleted;

        // 爬虫出错事件
        event EventHandler<OnErrorEventArgs> OnError;

        //异步爬虫
        Task<string> Start(Uri uri, string proxy);
    }
}
