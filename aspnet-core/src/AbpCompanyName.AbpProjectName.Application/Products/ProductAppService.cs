using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AbpCompanyName.AbpProjectName.Products.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpCompanyName.AbpProjectName.Products
{
    public class ProductAppService : ApplicationService, IProductAppService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductTranslation> _productTranslationRepository;

        public ProductAppService(
            IRepository<Product> productRepository,
            IRepository<ProductTranslation> productTranslationRepository
        )
        {
            _productRepository = productRepository;
            _productTranslationRepository = productTranslationRepository;
        }

        public async Task<ListResultDto<ProductDto>> GetProducts()
        {
            var products = await _productRepository
                .GetAllIncluding(p => p.Translations)
                .Include(p => p.ProductCategory)
                .Include(p => p.ProductCategory.Translations)
                .ToListAsync();

            var c = System.Globalization.CultureInfo.CurrentUICulture.Name;

            var governorateList = products
                .Select(o => ObjectMapper.Map<ProductDto>(o))
                //.Select(o => ObjectMapper.Map<ProductViewDto>(o))
                .ToList();

            return new ListResultDto<ProductDto>(governorateList);
        }

        public async Task CreateProduct(ProductCreateDto input)
        {
            var product = ObjectMapper.Map<Product>(input);
            await _productRepository.InsertAsync(product);
        }

        public async Task UpdateProduct(ProductUpdateDto input)
        {
            var product = await _productRepository.GetAllIncluding(p => p.Translations)
                .FirstOrDefaultAsync(p => p.Id == input.Id);

            product.Translations.Clear();

            ObjectMapper.Map(input, product);
        }

        public async Task Translate(int productId, ProductTranslationDto input)
        {
            var translation = await _productTranslationRepository.GetAll()
                                                           .FirstOrDefaultAsync(pt => pt.CoreId == productId && pt.Language == input.Language);

            if (translation == null)
            {
                var newTranslation = ObjectMapper.Map<ProductTranslation>(input);
                newTranslation.CoreId = productId;

                await _productTranslationRepository.InsertAsync(newTranslation);
            }
            else
            {
                ObjectMapper.Map(input, translation);
            }
        }
    }
}
