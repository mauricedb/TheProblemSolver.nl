using System;

namespace TheProblemSolver.Models
{
    public class Presentation
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Link { get; set; }
        public string Tags { get; set; }
        public Uri ImageUrl { get; set; }
    }
}
