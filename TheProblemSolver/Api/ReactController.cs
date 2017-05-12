using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using System.Globalization;
using System.Web.Http;

namespace TheProblemSolver.Api
{
    public class ReactController : ApiController
    {
        //
        // GET: /React/

        public IEnumerable<Item> Get()
        {
            var sheetService = new SheetsService(new BaseClientService.Initializer()
            {
                ApiKey = Environment.GetEnvironmentVariable("GoogleApiKey")
            });

            var request = sheetService.Spreadsheets.Values.Get(Environment.GetEnvironmentVariable("ReactSheetId"), "Sheet2!A2:D");
            var response = request.Execute();
            var values = response.Values;

            var result = new List<Item>();

            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    result.Add(new Item()
                    {
                        title = (string)row[0],
                        author = (string)row[1],
                        link = (string)row[2],
                        date = DateTime.Parse((string)row[3]).ToString("s", CultureInfo.InvariantCulture),
                    });
                }
            }

            result.Sort((x, y) => string.Compare(y.date, x.date));

            return result;
        }

        public class Item
        {
            public string title { get; set; }
            public string author { get; set; }
            public string link { get; set; }
            public string date { get; set; }
        }
    }
}
