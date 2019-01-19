using System.Collections.Generic;
using Feedler.BLL.Services.FeedService.Contract;
using Feedler.DAL;
using Feedler.DAL.Entities;

namespace Feedler.BLL.Services.FeedService.Concrete
{
    public class FeedsCollectionService : IFeedsCollectionService
    {
        private FeedlerContext _context;

        public FeedsCollectionService(FeedlerContext context)
        {
            _context = context;
        }

        public int CreateCollection(string name)
        {
            _context.Collections.Add(new FeedsCollection() { Name = name, });
            _context.SaveChanges();
            var i = _context.Collections.ToString();
            return 1;
        }

        public IList<int> GetCollectionsId()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCollection(int id)
        {
            throw new System.NotImplementedException();
        }

        public void AddFeedToCollection(int id, string url)
        {
            throw new System.NotImplementedException();
        }
    }
}