using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbpCompanyName.AbpProjectName.Products.Dto
{
    public class ProductViewDto
    {
        public ProductDto Product { get; set; }

        //if you want ProductCategoryName here uncomment below lines else check inside ProductDto
        //public ProductCategoryDto ProductCategory { get; set; }
        //public string ProductCategoryName =>
        //    !string.IsNullOrEmpty(Product.ProductCategory.Name) ?
        //    Product.ProductCategory.Name :
        //    Product.ProductCategory.DefaultName;

    }
}
