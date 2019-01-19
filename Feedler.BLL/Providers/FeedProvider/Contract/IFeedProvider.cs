using System.Collections.Generic;
using System.Threading.Tasks;
using Feedler.BLL.DTOs.Contract;

namespace Feedler.BLL.Providers.FeedProvider.Contract
{
    public interface IFeedProvider
    {
        Task<IEnumerable<IFeedItem>> GetFeed(string url);
    }
}