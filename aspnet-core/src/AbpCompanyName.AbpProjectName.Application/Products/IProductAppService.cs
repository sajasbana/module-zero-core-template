using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AbpCompanyName.AbpProjectName.Products.Dto;
using System.Threading.Tasks;

namespace AbpCompanyName.AbpProjectName.Products
{
    public interface IProductAppService : IApplicationService
    {
        Task<ListResultDto<ProductDto>> GetProducts();

        Task CreateProduct(ProductCreateDto input);

        Task UpdateProduct(ProductUpdateDto input);

        Task Translate(int productId, ProductTranslationDto input);
    }
}
