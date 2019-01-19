using Feedler.DAL.Enums;

namespace Feedler.DAL.Entities
{
    public class Feed
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public FeedType Type { get; set; }
    }
}