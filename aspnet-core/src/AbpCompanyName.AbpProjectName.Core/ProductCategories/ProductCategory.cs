using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AbpCompanyName.AbpProjectName.ProductCategories
{
    [Table("ProductCategories")]
    public class ProductCategory : Entity, IMultiLingualEntity<ProductCategoryTranslation>
    {
        public ProductCategory(string defaultName, bool isActive = true)
        {
            DefaultName = defaultName;
            IsActive = isActive;
        }

        //this property is to be show when there is no translation, if you don't want don't put it
        [Required]
        [StringLength(32)]
        public virtual string DefaultName { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual ICollection<ProductCategoryTranslation> Translations { get; set; }
    }
}
