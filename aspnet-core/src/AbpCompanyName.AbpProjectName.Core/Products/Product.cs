using Abp.Domain.Entities;
using AbpCompanyName.AbpProjectName.ProductCategories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AbpCompanyName.AbpProjectName.Products
{
    [Table("Products")]
    public class Product : Entity, IMultiLingualEntity<ProductTranslation>
    {
        public Product(int productCategoryId, decimal price = 10, int stock = 10)
        {
            ProductCategoryId = productCategoryId;
            Price = price;
            Stock = stock;
        }

        //this property is to be show when there is no translation, if you don't want don't put it
        //[Required]
        //[StringLength(32)]
        //public virtual string DefaultName { get; set; }

        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }

        public virtual decimal Price { get; set; }

        public virtual int Stock { get; set; }

        public virtual ICollection<ProductTranslation> Translations { get; set; }
    }
}
