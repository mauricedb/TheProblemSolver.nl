using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Argotic.Common;
using Argotic.Extensions.Core;
using Argotic.Syndication;
using TheProblemSolver.Models;

namespace TheProblemSolver.Controllers
{
    public class PresentationsController : Controller
    {
        //
        // GET: /Presentations/

        public ActionResult Index()
        {
            var presentations = GetPresentations();

            return View(presentations);
        }

        private static List<Presentation> _presentations;
        private static List<Presentation> GetPresentations()
        {
            if (_presentations == null)
            {
                _presentations = GetPresentationsFromWeb();
            }
            return _presentations;
        }

        private static List<Presentation> GetPresentationsFromWeb()
        {
            var presentations = new List<Presentation>();
            var feed = GetRssFeed();

            foreach (var item in feed.Channel.Items)
            {
                var media = item.FindExtension<YahooMediaSyndicationExtension>();
                var description = media.Context.Contents.First().Description.Content;
                var url = media.Context.Contents.First().Thumbnails.First().Url;
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

            var feedUrl = new Uri("http://www.slideshare.net/rss/user/mauricedb");
            var feed = RssFeed.Create(feedUrl, settings);

            return feed;
        }
    }
}
