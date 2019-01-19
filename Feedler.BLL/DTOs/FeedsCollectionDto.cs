using System.Collections.Generic;

namespace Feedler.BLL.DTOs
{
    public class FeedsCollectionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<string> FeedsUrls { get; set; }
    }
}