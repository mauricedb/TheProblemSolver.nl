using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Argotic.Common;
using Argotic.Syndication;
using TheProblemSolver.Models;

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
            foreach (var item in feed.Channel.Items)
            {
                var newsItem = new NewsItem
                {
                    Description = item.Description,
                    Date = item.PublicationDate,
                    Uri = item.Link
                };

                presentations.Add(newsItem);
            }

            return presentations;
        }

        private static RssFeed GetRssFeed()
        {

            var settings = new SyndicationResourceLoadSettings();
            settings.RetrievalLimit = 9;

            var feedUrl = new Uri("https://api.twitter.com/1/statuses/user_timeline.rss?screen_name=mauricedb");
            var feed = RssFeed.Create(feedUrl, settings);

            return feed;
        }

    }
}
