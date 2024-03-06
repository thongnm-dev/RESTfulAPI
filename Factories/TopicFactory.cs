using System.Threading.Tasks;
using RESTfulAPI.Core.Domain.Topics;

namespace RESTfulAPI.Factories
{
    public class TopicFactory : IFactory<Topic>
    {
        public Task<Topic> InitializeAsync()
        {
            var topic = new Topic();
            return Task.FromResult(topic);
        }
    }
}
