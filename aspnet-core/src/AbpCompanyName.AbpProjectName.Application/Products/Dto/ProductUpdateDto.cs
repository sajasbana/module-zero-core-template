using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbpCompanyName.AbpProjectName.Products.Dto
{
    public class ProductUpdateDto : EntityDto
    {
        public string DefaultName { get; set; }

        public int ProductCategoryId { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public ICollection<ProductTranslationDto> Translations { get; set; }
    }
}
