using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AbpCompanyName.AbpProjectName.Products
{
    [Table("ProductTranslations")]
    public class ProductTranslation : Entity, IEntityTranslation<Product>
    {
        public ProductTranslation(string name, int coreId, string language)
        {
            Name = name;
            CoreId = coreId;
            Language = language;
        }

        [StringLength(32)]
        public virtual string Name { get; set; }

        public virtual Product Core { get; set; }

        public virtual int CoreId { get; set; }

        public virtual string Language { get; set; }
    }
}
