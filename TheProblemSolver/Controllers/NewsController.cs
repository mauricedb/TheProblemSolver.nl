using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Argotic.Common;
using Argotic.Syndication;
using TheProblemSolver.Models;
using TweetSharp;
using System.Configuration;

namespace TheProblemSolver.Controllers
{
    public class NewsController : Controller
    {
        //
        // GET: /News/
        [OutputCache(Duration = 15 * 60)]
        public ActionResult Index()
        {
            var news = GetTwitterFeed();
            return PartialView(news);
        }

        private static List<NewsItem> _news;
        private static DateTime _lastFetch;

        private static IEnumerable<NewsItem> GetTwitterFeed()
        {
            if (_lastFetch.AddMinutes(30) < DateTime.UtcNow)
            {
                _news = null;
            }

            if (_news == null)
            {
                try
                {
                    _news = GetTwitterFeedFromWeb();
                    _lastFetch = DateTime.UtcNow;
                }
                catch (Exception)
                {
                }
            }
            return _news ?? Enumerable.Empty<NewsItem>();
        }


        private static List<NewsItem> GetTwitterFeedFromWeb()
        {
            var presentations = new List<NewsItem>();
            var feed = GetRssFeed();
            foreach (var item in feed)
            {
                var newsItem = new NewsItem
                {
                    Description = item.TextAsHtml,
                    Date = item.CreatedDate,
                    //Uri = item.
                };

                presentations.Add(newsItem);
            }

            return presentations;
        }

        private static IEnumerable<TwitterStatus> GetRssFeed()
        {

            var service = new TwitterService(ConfigurationManager.AppSettings["TwitterConsumerKey"], ConfigurationManager.AppSettings["TwitterConsumerSecret"]);
            service.AuthenticateWith(ConfigurationManager.AppSettings["TwitterToken"], ConfigurationManager.AppSettings["TwitterTokenSecret"]);

            var statusses = service.ListTweetsOnUserTimeline(new ListTweetsOnUserTimelineOptions()
            {
                ScreenName = "mauricedb",
                Count = 9
            });

            return statusses;
        }
    }
}
