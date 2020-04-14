using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AbpCompanyName.AbpProjectName.ProductCategories.Dto
{
    public class ProductCategoryCreateDto
    {
        [Required]
        [StringLength(32, MinimumLength = 1)]
        public virtual string DefaultName { get; set; }

        public bool IsActive { get; set; }

        public ICollection<ProductCategoryTranslationDto> Translations { get; set; }
    }
}
