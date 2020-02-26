using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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
            try
            {
                var shortUrl = await ShortenUrl4(url);

                items.Add(new BookieBookieItem()
                {
                    Title = title,
                    Url = shortUrl,
                    Image = image,
                    DateTime = DateTime.UtcNow
                });

                return shortUrl;
            }
            catch (System.Exception ex)
            {
                this.StatusCode(HttpStatusCode.InternalServerError);
                return ex.ToString();
            }
        }

        private static async Task<string> ShortenUrl4(string url)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var client = new HttpClient();
            var token = Environment.GetEnvironmentVariable("BitlyToken");
            token = "34b10af37f646d6d439967e20714315038621885";

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            var response = await client.PostAsJsonAsync(
                "https://api-ssl.bitly.com/v4/shorten"
                , new
                {
                    long_url = url
                });

            var json = JObject.Parse(await response.Content.ReadAsStringAsync());
            var shortUrl = json["link"].ToString();

            return shortUrl;
        }

        private static async Task<string> ShortenUrl3(string url)
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
            public DateTime DateTime { get; set; }
        }
    }
}