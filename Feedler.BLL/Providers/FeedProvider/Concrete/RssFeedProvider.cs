using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using Feedler.BLL.DTOs;
using Feedler.BLL.DTOs.Contract;
using Feedler.BLL.Providers.FeedProvider.Contract;
using Feedler.DAL.Enums;

namespace Feedler.BLL.Providers.FeedProvider.Concrete
{
    public class RssFeedProvider : IFeedProvider
    {
        public async Task<IEnumerable<IFeedItem>> GetFeed(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var data = await client.GetStringAsync(url);
                    var xml = XDocument.Parse(data);
                    var items = xml.Root?.Descendants().First(i => i.Name.LocalName == "channel").Elements().Where(i => i.Name.LocalName == "item").Select(x => new RssFeedItem
                    {
                        Title = x.Elements().First(i => i.Name.LocalName == "title").Value,
                        Link = x.Elements().First(i => i.Name.LocalName == "link").Value,
                        Description = x.Elements().First(i => i.Name.LocalName == "description").Value,
                        PublishDate = DateTime.TryParse(x.Elements().FirstOrDefault(i => i.Name.LocalName == "pubDate")?.Value, out var result) ? result : DateTime.MinValue,
                        FeedType = FeedType.Rss
                    });
                    return items;
                }
            }
            catch (Exception e)
            {
                //logger
                return new List<IFeedItem>();
            }
        }
    }
}