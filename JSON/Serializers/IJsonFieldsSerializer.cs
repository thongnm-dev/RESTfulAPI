using RESTfulAPI.DTO;

namespace RESTfulAPI.JSON.Serializers
{
    public interface IJsonFieldsSerializer
    {
        string Serialize(ISerializableObject objectToSerialize, string fields);
    }
}
