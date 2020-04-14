using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Abp.Localization;
using Abp.MultiTenancy;
using AbpCompanyName.AbpProjectName.Products;
using AbpCompanyName.AbpProjectName.ProductCategories;

namespace AbpCompanyName.AbpProjectName.EntityFrameworkCore.Seed.App
{
    public class DefaultProductCategoryTranslationsCreator
    {
        public static List<ProductCategoryTranslation> InitialEntities => GetInitialEntities();

        private readonly AbpProjectNameDbContext _context;

        private static List<ProductCategoryTranslation> GetInitialEntities()
        {
            return new List<ProductCategoryTranslation>
            {
                new ProductCategoryTranslation("ProductCategory 1 en", 1, "en"),
                new ProductCategoryTranslation("ProductCategory 1 ar", 1, "ar"),
                new ProductCategoryTranslation("ProductCategory 2 ar", 1, "ar"),
                new ProductCategoryTranslation("ProductCategory 3 en", 1, "en"),
                //new ProductCategoryTranslation("ProductCategory 4 en", 1, "en"),
            };
        }

        public DefaultProductCategoryTranslationsCreator(AbpProjectNameDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateEntities();
        }

        private void CreateEntities()
        {
            foreach (var entity in InitialEntities)
            {
                AddEntityIfNotExists(entity);
            }
        }

        private void AddEntityIfNotExists(ProductCategoryTranslation entity)
        {
            if (_context.ProductCategoryTranslations.Any(p => p.Name == entity.Name && p.Language == entity.Language))
            {
                return;
            }

            _context.ProductCategoryTranslations.Add(entity);
            _context.SaveChanges();
        }
    }
}
