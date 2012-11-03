using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Common.Interfaces;
using System.Collections.Generic;
using Common.BaseTypes;
using System.Xml;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Collections;
using System.Text;
using System.Collections.ObjectModel;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Services
{
    public class GeoService:IGeoService
    {
        public void GetAllCategoriesAsync(Action<ObservableCollection<Category>> reply)
        {
            var uri = new Uri(string.Format("", Properties.Resource.client_id, Properties.Resource.client_secret));
            WebClient client = new WebClient();

            client.DownloadStringCompleted += (object sender, DownloadStringCompletedEventArgs e) => 
                   {
                        lock (this)
                        {
                            reply(JsonToObject<ObservableCollection<Category>>(e.Result, "categories"));
                        }
                   };

            client.DownloadStringAsync(uri);
        }

        public void GetVenuesNearMeAsync(Action<ObservableCollection<Venue>> reply, List<Category> categories)
        {
            var catIds = new StringBuilder();

            if (categories != null)
            {
                categories.ForEach(c => catIds.AppendFormat("{0},", c.id));
                catIds.Remove(catIds.Length - 1, 1);
            }
                

            var uri = new Uri(string.Format(Properties.Resource.NearestVenuesRequest, "Воронеж", catIds, Properties.Resource.client_id, Properties.Resource.client_secret, DateTime.Now.Date.ToString("yyyyMMdd"), 1000));
            WebClient client = new WebClient();
            client.DownloadStringCompleted += (object sender, DownloadStringCompletedEventArgs e) =>
            {
                lock (this)
                {
                    reply(JsonToObject<ObservableCollection<Venue>>(e.Result, "venues"));
                }
            };

            client.DownloadStringAsync(uri);
        }

        private T JsonToObject<T>(string json, string key)
        {
            var data = JObject.Parse(json).SelectToken(string.Format("response.{0}", key)).ToString();
            return JsonConvert.DeserializeObject<T>(data);
        } 
    }
}
