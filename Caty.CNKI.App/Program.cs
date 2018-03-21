using AngleSharp.Parser.Html;
using Caty.CNKI.Crawler;
using System;

namespace Caty.CNKI.App
{
    class Program
    {
        static HtmlParser htmlParser = new HtmlParser();
        static void Main(string[] args)
        {
            var Url = "http://search.cnki.net/search.aspx?q=精准扶贫&rank=citeNumber&cluster=all&val=CJFDTOTAL&p=0";
            var cnkiCrawler = new SimpleCrawler();
            cnkiCrawler.OnStart += (s, e) =>
            {
                Console.WriteLine("爬虫开始抓取地址:" + e.Uri.ToString());
            };
            cnkiCrawler.OnError += (s, e) =>
            {
                Console.WriteLine("异常消息：" + e.Exception.Message);
            };
            cnkiCrawler.OnCompleted += (s, e) =>
            {
                //通过URL获取HTML
                var dom = htmlParser.Parse(e.PageSource);
                Console.WriteLine(e.PageSource);
            };
            cnkiCrawler.Start(new Uri(Url)).Wait();
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
