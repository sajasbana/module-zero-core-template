using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbpCompanyName.AbpProjectName.ProductCategories.Dto
{
    public class ProductCategoryDto : EntityDto
    {
        //name to be shown in ui as default if no translated name found
        //is it possible to set value of DefaultName into Name if Name is not found???
        public virtual string DefaultName { get; set; }

        public bool IsActive { get; set; }

        // Mapped from ProductCategoryTranslation.Name
        public string Name { get; set; }

        // Mapped from ProductCategoryTranslation.Language
        public string Language { get; set; }
    }
}
