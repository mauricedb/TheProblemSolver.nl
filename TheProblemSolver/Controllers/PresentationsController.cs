using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Argotic.Common;
using Argotic.Extensions.Core;
using Argotic.Syndication;
using TheProblemSolver.Models;

namespace TheProblemSolver.Controllers
{
#if !DEBUG
    [OutputCache(Duration = 15 * 60)]
#endif
    public class PresentationsController : Controller
    {
        //
        // GET: /Presentations/

        private static List<Presentation> _presentations;
        private static DateTime _lastFetch;

        public ActionResult Index()
        {
            List<Presentation> presentations = GetPresentations();

            return View(presentations);
        }

        private static List<Presentation> GetPresentations()
        {
            if (_presentations == null || _lastFetch.AddDays(1) < DateTime.UtcNow)
            {
                _presentations = GetPresentationsFromWeb();
                _lastFetch = DateTime.UtcNow;
            }
            return _presentations;
        }

        private static List<Presentation> GetPresentationsFromWeb()
        {
            var presentations = new List<Presentation>();
            RssFeed feed = GetRssFeed();

            foreach (RssItem item in feed.Channel.Items)
            {
                var media = item.FindExtension<YahooMediaSyndicationExtension>();
                string description = media.Context.Contents.First().Description.Content;
                Uri url = media.Context.Contents.First().Thumbnails.First().Url;
                var p = new Presentation
                {
                    Id = item.Guid.Value,
                    Title = item.Title,
                    Description = description,
                    PublicationDate = item.PublicationDate,
                    Link = item.Link.ToString(),
                    Tags = String.Join(", ", item.Categories.Select(c => c.Value)),
                    ImageUrl = url,
                };

                presentations.Add(p);
            }

            return presentations;
        }


        private static RssFeed GetRssFeed()
        {
            var settings = new SyndicationResourceLoadSettings();
            settings.RetrievalLimit = 555;

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var feedUrl = new Uri("https://www.slideshare.net/rss/user/mauricedb");
            RssFeed feed = RssFeed.Create(feedUrl, settings);

            return feed;
        }
    }
}