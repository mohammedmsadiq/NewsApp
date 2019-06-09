using System;
using System.Xml.Linq;
using Xamarin.Forms;

namespace NewsApp.Models
{
    public class FeedItemModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public string PubDate { get; set; }

        public string Guid { get; set; }

        public string Thumbnail { get; set; }
    }
}

