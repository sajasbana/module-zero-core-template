using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AbpCompanyName.AbpProjectName.ProductCategories.Dto;
using System.Threading.Tasks;

namespace AbpCompanyName.AbpProjectName.ProductCategories
{
    public interface IProductCategoryAppService : IApplicationService
    {
        Task<ListResultDto<ProductCategoryDto>> GetProductCategories();

        Task CreateProductCategory(ProductCategoryCreateDto input);

        Task UpdateProductCategory(ProductCategoryUpdateDto input);

        Task Translate(int productCategoryId, ProductCategoryTranslationDto input);
    }
}
