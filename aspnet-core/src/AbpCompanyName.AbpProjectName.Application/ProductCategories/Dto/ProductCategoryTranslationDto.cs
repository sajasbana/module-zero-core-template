using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AbpCompanyName.AbpProjectName.ProductCategories.Dto
{
    public class ProductCategoryTranslationDto
    {
        [StringLength(32, MinimumLength = 1)]
        public string Name { get; set; }

        public string Language { get; set; }
    }
}
