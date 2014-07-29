using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Argotic.Common;
using Argotic.Syndication;
using TheProblemSolver.Models;

namespace TheProblemSolver.Controllers
{
#if !DEBUG
    [OutputCache(Duration = 15 * 60)]
#endif
    public class BlogController : Controller
    {
        //public ActionResult TopStory()
        //{
        //    var blogItem = GetBlogFeed().First();
        //    return PartialView(blogItem);

        //}


        public ActionResult Recent()
        {
            var blogItems = GetBlogFeed().Take(5);
            return PartialView(blogItems);
        }


        private static List<BlogItem> _news;
        private static DateTime _lastFetch;

        private static IEnumerable<BlogItem> GetBlogFeed()
        {
            if (_news == null || _lastFetch.AddHours(1) < DateTime.UtcNow)
            {
                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        _news = GetTwitterFeedFromWeb();
                        _lastFetch = DateTime.UtcNow;
                    }
                    catch (Exception)
                    {
                    }
                });
            }
            return _news ?? Enumerable.Empty<BlogItem>();
        }


        private static List<BlogItem> GetTwitterFeedFromWeb()
        {
            var blogItems = new List<BlogItem>();
            var feed = GetRssFeed();

            foreach (var item in feed.Channel.Items)
            {
                var newsItem = new BlogItem
                {
                    Title = item.Title,
                    Description = item.Description,
                    Date = item.PublicationDate,
                    Uri = item.Link
                };

                blogItems.Add(newsItem);
            }

            return blogItems;
        }

        private static RssFeed GetRssFeed()
        {

            var settings = new SyndicationResourceLoadSettings
            {
                RetrievalLimit = 9
            };

            var feedUrl   = new Uri("http://blogs.msmvps.com/theproblemsolver/feed/");
            var feed = RssFeed.Create(feedUrl, settings);

            return feed;
        }
    }
}
