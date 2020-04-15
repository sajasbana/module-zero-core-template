using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using AbpCompanyName.AbpProjectName.ProductCategories.Dto;
using AbpCompanyName.AbpProjectName.Products.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpCompanyName.AbpProjectName.ProductCategories
{
    public class ProductCategoryAppService : ApplicationService, IProductCategoryAppService
    {
        private readonly IRepository<ProductCategory> _productCategoryRepository;
        private readonly IRepository<ProductCategoryTranslation> _productCategoryTranslationRepository;

        public ProductCategoryAppService(
            IRepository<ProductCategory> productCategoryRepository,
            IRepository<ProductCategoryTranslation> productCategoryTranslationRepository
        )
        {
            _productCategoryRepository = productCategoryRepository;
            _productCategoryTranslationRepository = productCategoryTranslationRepository;
        }

        [AbpAllowAnonymous]
        public async Task<ListResultDto<ProductCategoryDto>> GetProductCategories()
        {
            var tenantId = AbpSession.TenantId;

            var productCategories = await _productCategoryRepository
                .GetAllIncluding(p => p.Translations)
                .ToListAsync();

            var governorateList = productCategories
                .Select(o => new ProductCategoryViewDto()
                {
                    ProductCategory = ObjectMapper.Map<ProductCategoryDto>(o)
                })
                .ToList();

            return new ListResultDto<ProductCategoryDto>(
                ObjectMapper.Map<List<ProductCategoryDto>>(productCategories)
                );
        }

        public async Task CreateProductCategory(ProductCategoryCreateDto input)
        {
            var productCategory = ObjectMapper.Map<ProductCategory>(input);
            await _productCategoryRepository.InsertAsync(productCategory);
        }

        public async Task UpdateProductCategory(ProductCategoryUpdateDto input)
        {
            var productCategory = await _productCategoryRepository.GetAllIncluding(p => p.Translations)
                .FirstOrDefaultAsync(p => p.Id == input.Id);

            productCategory.Translations.Clear();

            ObjectMapper.Map(input, productCategory);
        }

        public async Task Translate(int productCategoryId, ProductCategoryTranslationDto input)
        {
            var translation = await _productCategoryTranslationRepository.GetAll()
                                                           .FirstOrDefaultAsync(pt => pt.CoreId == productCategoryId && pt.Language == input.Language);

            if (translation == null)
            {
                var newTranslation = ObjectMapper.Map<ProductCategoryTranslation>(input);
                newTranslation.CoreId = productCategoryId;

                await _productCategoryTranslationRepository.InsertAsync(newTranslation);
            }
            else
            {
                ObjectMapper.Map(input, translation);
            }
        }
    }
}
