using System.Collections.Generic;

namespace Feedler.BLL.Services.FeedService.Contract
{
    public interface IFeedsCollectionService
    {
        int CreateCollection(string name);
        IList<int> GetCollectionsId();
        void DeleteCollection(int id);
        void AddFeedToCollection(int id, string url);
    }
}