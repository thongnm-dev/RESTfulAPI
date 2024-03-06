using RESTfulAPI.Core.Domain.Topics;
using RESTfulAPI.AutoMapper;
using RESTfulAPI.DTOs.Topics;

namespace RESTfulAPI.MappingExtensions
{
    public static class TopicDtoMappings
    {
        public static TopicDto ToDto(this Topic topic)
        {
            return topic.MapTo<Topic, TopicDto>();
        }
    }
}
