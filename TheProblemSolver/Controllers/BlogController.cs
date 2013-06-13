using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Argotic.Common;
using Argotic.Syndication;
using TheProblemSolver.Models;

namespace TheProblemSolver.Controllers
{
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

            var feedUrl = new Uri("http://msmvps.com/blogs/theproblemsolver/rss.aspx");
            var feed = RssFeed.Create(feedUrl, settings);

            return feed;
        }
    }
}
