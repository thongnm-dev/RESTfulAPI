using RESTfulAPI.Core.Domain.Messages;
using RESTfulAPI.AutoMapper;
using RESTfulAPI.DTO.NewsLetterSubscriptions;

namespace RESTfulAPI.MappingExtensions
{
    public static class NewsLetterSubscriptoonDtoMappings
    {
        public static NewsLetterSubscriptionDto ToDto(this NewsLetterSubscription newsLetterSubscription)
        {
            return newsLetterSubscription.MapTo<NewsLetterSubscription, NewsLetterSubscriptionDto>();
        }

        public static NewsLetterSubscription ToEntity(this NewsLetterSubscriptionDto newsLetterSubscriptionDto)
        {
            return newsLetterSubscriptionDto.MapTo<NewsLetterSubscriptionDto, NewsLetterSubscription>();
        }
    }
}
