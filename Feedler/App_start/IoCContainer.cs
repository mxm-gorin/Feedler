using Feedler.BLL.Services.FeedService.Concrete;
using Feedler.BLL.Services.FeedService.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace Feedler.App_start
{
    public static class IoCContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IFeedsCollectionService, FeedsCollectionService>();
        }
    }
}