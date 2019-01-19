using Feedler.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Feedler.DAL
{
    public class FeedlerContext : DbContext
    {
        public FeedlerContext(DbContextOptions<FeedlerContext> options)
            : base(options)

        {
        }

        public DbSet<Feed> Feeds;
        public DbSet<FeedsCollection> Collections;
    }
}