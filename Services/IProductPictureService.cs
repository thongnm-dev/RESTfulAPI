using RESTfulAPI.Core.Domain.Catalog;

namespace RESTfulAPI.Services
{
    public interface IProductPictureService
    {
        ProductPicture GetProductPictureByPictureId(int pictureId);
    }
}
