using Abp.Application.Services.Dto;
using AbpCompanyName.AbpProjectName.ProductCategories.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbpCompanyName.AbpProjectName.Products.Dto
{
    public class ProductDto : EntityDto
    {
        public int ProductCategoryId { get; set; }

        public ProductCategoryDto ProductCategory { get; set; }

        //this is optional all information needed is in ProductCategory property
        public string ProductCategoryName =>
            !string.IsNullOrEmpty(ProductCategory.Name) ?
            ProductCategory.Name :
            ProductCategory.DefaultName;

        public decimal Price { get; set; }

        public int Stock { get; set; }

        // Mapped from ProductTranslation.Name
        public string Name { get; set; }

        // Mapped from ProductTranslation.Language
        public string Language { get; set; }
    }
}
