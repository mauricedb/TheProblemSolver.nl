using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Glimpse.Core.Tab;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Newtonsoft.Json.Linq;

namespace TheProblemSolver.Api
{
    public class BookieBookieController : ApiController
    {
        public async Task<string> Get(string url, string title)
        {
            var shortUrl = await ShortenUrl(url);
            await SaveInSpreadSheet(title, shortUrl);
            return shortUrl;
        }

        private static async Task SaveInSpreadSheet(string title, string shortUrl)
        {
            try
            {
                var clientId = Environment.GetEnvironmentVariable("BookieBookieClientId");
                var clientSecret = Environment.GetEnvironmentVariable("BookieBookieSecret");

                var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    new ClientSecrets()
                    {
                        ClientId = clientId,
                        ClientSecret = clientSecret
                    },
                    new[] { SheetsService.Scope.Spreadsheets },
                    "user",
                    CancellationToken.None);

                var sheetService = new SheetsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential
                });

                var value = new ValueRange()
                {
                    Values = new List<IList<object>>()
                };

                value.Values.Add(new List<object>() { title, "User", shortUrl, DateTime.Today.ToString("yyyy-MM-dd") });

                var sheetId = Environment.GetEnvironmentVariable("BookieBookieSheetId");
                var request = sheetService.Spreadsheets.Values.Append(value, sheetId, "Sheet1!A2:D");
                request.ValueInputOption =
                    SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
                var response2 = request.Execute();
                Console.WriteLine(response2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
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
    }
}