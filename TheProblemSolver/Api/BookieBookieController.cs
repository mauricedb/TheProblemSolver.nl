using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using DotNetOpenAuth.Messaging;
using Newtonsoft.Json.Linq;

namespace TheProblemSolver.Api
{
    public class BookieBookieController : ApiController
    {
        private static List<BookieBookieItem> items = new List<BookieBookieItem>();

        public List<BookieBookieItem> Get()
        {
            var currentItems = items;

            if (Request.RequestUri.Query.Contains("reset"))
            {

                items = new List<BookieBookieItem>();
            }

            return currentItems;
        }

        public async Task<string> Get(string url, string title, string image)
        {
            var shortUrl = await ShortenUrl(url);

            items.Add(new BookieBookieItem()
            {
                Title = title,
                Url = shortUrl,
                Image = image
            });

            return shortUrl;
        }

        private static async Task<string> ShortenUrl(string url)
        {
            var client = new HttpClient();
            var token = Environment.GetEnvironmentVariable("BitlyToken");
            token = "34b10af37f646d6d439967e20714315038621885";
            var response =
                await client.GetStringAsync(@"https://api-ssl.bitly.com/v3/shorten?access_token=" + token + "&longUrl=" + url);
            var json = JObject.Parse(response);
            var shortUrl = json["data"]["url"].ToString();
            return shortUrl;
        }


        public class BookieBookieItem
        {
            public string Title { get; set; }
            public string Url { get; set; }
            public string Image { get; set; }
        }
    }
}