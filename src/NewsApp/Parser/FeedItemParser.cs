using System;
using System.Collections.Generic;
using System.Xml.Linq;
using NewsApp.Models;
using Xamarin.Forms;

namespace NewsApp.Parser
{
    public class FeedItemParser
    {

        public FeedItemParser()
        {
        }

        public List<FeedItemModel> ParseFeed(string response)
        {
            if (response == null)
            {
                return null;
            }
            XNamespace media = "http://search.yahoo.com/mrss/";
            XDocument doc = XDocument.Parse(response);
            List<FeedItemModel> feeds = new List<FeedItemModel>();
            foreach (var item in doc.Descendants("item"))
            {
                FeedItemModel feed = new FeedItemModel();
                feed.Title = item.Element("title").Value.ToString();
                feed.Link = item.Element("link").Value.ToString();
                feed.Thumbnail = item.Element(media + "thumbnail").Attribute("url").Value;
                feed.Description = item.Element("description").Value.ToString();
                feed.PubDate = item.Element("pubDate").Value.ToString();
                feed.Guid = item.Element("guid").Value.ToString();
                feeds.Add(feed);
            }
            return feeds;
        }
    }
}

