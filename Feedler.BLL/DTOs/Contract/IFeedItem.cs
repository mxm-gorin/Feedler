using System;
using Feedler.BLL.Enums;
using FeedType = Feedler.DAL.Enums.FeedType;

namespace Feedler.BLL.DTOs.Contract
{
    public interface IFeedItem
    {
        int Id { get; set; }
        string Link { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        DateTime? PublishDate { get; set; }
        FeedType FeedType { get; set; }
    }
}