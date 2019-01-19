using System;
using System.Collections.Generic;
using System.Text;
using Feedler.BLL.Providers.FeedProvider.Concrete;
using Feedler.BLL.Providers.FeedProvider.Contract;
using Feedler.DAL.Enums;

namespace Feedler.BLL.Providers
{
    class ProviderFactory
    {
        public IFeedProvider GetProvider(FeedType type)
        {
            switch (type)
            {
                case (FeedType.Rss): return new RssFeedProvider();
                case (FeedType.Atom): return new AtomFeedProvider();
                default: throw new ArgumentException("Invalid type", "type");
            }
        }
    }
}
