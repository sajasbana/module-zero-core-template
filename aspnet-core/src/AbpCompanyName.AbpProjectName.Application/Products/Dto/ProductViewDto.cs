using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbpCompanyName.AbpProjectName.Products.Dto
{
    public class ProductViewDto
    {
        public ProductDto Product { get; set; }

        public string ProductCategoryName { get; set; }

    }
}
