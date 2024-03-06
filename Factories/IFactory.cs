using System.Threading.Tasks;

namespace RESTfulAPI.Factories
{
    public interface IFactory<T>
    {
        Task<T> InitializeAsync();
    }
}
