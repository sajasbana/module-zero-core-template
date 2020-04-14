using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbpCompanyName.AbpProjectName.Products.Dto
{
    public class ProductDto : EntityDto
    {
        public string DefaultName { get; set; }

        public int ProductCategoryId { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        // Mapped from ProductTranslation.Name
        public string Name { get; set; }

        // Mapped from ProductTranslation.Language
        public string Language { get; set; }
    }
}
