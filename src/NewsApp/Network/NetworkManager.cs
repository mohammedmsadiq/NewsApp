using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using NewsApp.Models;
using NewsApp.Parser;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace NewsApp.Network
{
    public class NetworkManager
    {
        public static NetworkManager network_manager = new NetworkManager();
        public static string network_url = "https://feeds.bbci.co.uk/news/uk/rss.xml";
        private NetworkManager()
        {
        }

        public static NetworkManager Instance
        {
            get
            {
                return network_manager;
            }
        }

        public async Task<List<FeedItemModel>> GetSyncFeedAsync()
        {
            if (this.IsConnected())
            {
                Uri uri = new Uri(network_url);
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(uri);
                String response_string = await response.Content.ReadAsStringAsync();
                FeedItemParser parser = new FeedItemParser();
                List<FeedItemModel> list = await Task.Run(() => parser.ParseFeed(response_string));
                return list;
            }
            return null;
        }

        public bool IsConnected()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                return true;
            }
            return false;
        }
    }
}

