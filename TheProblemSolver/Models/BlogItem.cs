using System;
using TheProblemSolver.Controllers;

namespace TheProblemSolver.Models
{
    public class BlogItem
    {
        public DateTime Date { get; set; }
        public Uri Uri { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string ShortDescription
        {
            get
            {
                var maxLength = 200;
                var convertor = new HtmlToText();
                var text = convertor.ConvertHtml(Description).Trim();
                if (text.Length > maxLength)
                {
                    text = text.Substring(0, maxLength);
                    var i = text.LastIndexOf(' ');
                    if (i > 0)
                    {
                        text = text.Substring(0, i);
                    }
                    text += "...";
                }
                return text;
            }
        }
    }
}