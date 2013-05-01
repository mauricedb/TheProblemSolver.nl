using System;

namespace TheProblemSolver.Models
{
    public class BlogItem
    {
        public DateTime Date { get; set; }
        public Uri Uri { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}