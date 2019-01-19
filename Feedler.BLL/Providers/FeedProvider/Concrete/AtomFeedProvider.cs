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
    public class AtomFeedProvider : IFeedProvider
    {
        public async Task<IEnumerable<IFeedItem>> GetFeed(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var data = await client.GetStringAsync(url);
                    var xml = XDocument.Parse(data);
                    var items = xml.Root?.Elements().Where(i => i.Name.LocalName == "entry").Select(x => new AtomFeedItem
                    {

                        Title = x.Elements().FirstOrDefault(i => i.Name.LocalName == "title")?.Value ?? string.Empty,
                        Link = x.Elements().FirstOrDefault(i => i.Name.LocalName == "link")?.Value ?? string.Empty,
                        Description = x.Elements().FirstOrDefault(i => i.Name.LocalName == "content")?.Value ?? string.Empty,
                        PublishDate = DateTime.TryParse(x.Elements().FirstOrDefault(i => i.Name.LocalName == "updated")?.Value, out var result) ? result : DateTime.UtcNow,
                        FeedType = FeedType.Atom
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