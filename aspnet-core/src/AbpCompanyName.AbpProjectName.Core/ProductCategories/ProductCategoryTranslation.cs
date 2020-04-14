using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AbpCompanyName.AbpProjectName.ProductCategories
{
    [Table("ProductCategoryTranslations")]
    public class ProductCategoryTranslation : Entity, IEntityTranslation<ProductCategory>
    {
        public ProductCategoryTranslation(string name, int coreId, string language)
        {
            Name = name;
            CoreId = coreId;
            Language = language;
        }

        //i made translation optional, if you want it to be required uncomment below line
        //[Required]
        [StringLength(32)]
        public virtual string Name { get; set; }

        public virtual ProductCategory Core { get; set; }

        public virtual int CoreId { get; set; }

        public virtual string Language { get; set; }
    }
}
