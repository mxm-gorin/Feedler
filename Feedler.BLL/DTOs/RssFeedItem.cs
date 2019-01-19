using System;
using Feedler.BLL.DTOs.Contract;
using Feedler.BLL.Enums;
using FeedType = Feedler.DAL.Enums.FeedType;

namespace Feedler.BLL.DTOs
{
    public class RssFeedItem : IFeedItem
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PublishDate { get; set; }
        public FeedType FeedType { get; set; }
    }
}