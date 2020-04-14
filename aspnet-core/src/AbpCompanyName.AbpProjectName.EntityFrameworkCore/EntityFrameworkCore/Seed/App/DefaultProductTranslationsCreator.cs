using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Abp.Localization;
using Abp.MultiTenancy;
using AbpCompanyName.AbpProjectName.Products;

namespace AbpCompanyName.AbpProjectName.EntityFrameworkCore.Seed.App
{
    public class DefaultProductTranslationsCreator
    {
        public static List<ProductTranslation> InitialEntities => GetInitialEntities();

        private readonly AbpProjectNameDbContext _context;

        private static List<ProductTranslation> GetInitialEntities()
        {
            return new List<ProductTranslation>
            {
                new ProductTranslation("Product 1 en", 1, "en"),
                new ProductTranslation("Product 1 ar", 1, "ar"),
                new ProductTranslation("Product 2 ar", 2, "ar"),
                new ProductTranslation("Product 3 en", 3, "en"),
            };
        }

        public DefaultProductTranslationsCreator(AbpProjectNameDbContext context)
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

        private void AddEntityIfNotExists(ProductTranslation entity)
        {
            if (_context.ProductTranslations.Any(p => p.Name == entity.Name && p.Language == entity.Language))
            {
                return;
            }

            _context.ProductTranslations.Add(entity);
            _context.SaveChanges();
        }
    }
}
