using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Abp.Localization;
using Abp.MultiTenancy;
using AbpCompanyName.AbpProjectName.ProductCategories;

namespace AbpCompanyName.AbpProjectName.EntityFrameworkCore.Seed.App
{
    public class DefaultProductCategoriesCreator
    {
        public static List<ProductCategory> InitialEntities => GetInitialEntities();

        private readonly AbpProjectNameDbContext _context;

        private static List<ProductCategory> GetInitialEntities()
        {
            return new List<ProductCategory>
            {
                new ProductCategory("ProductCategory 1"),
                new ProductCategory("ProductCategory 2", false),
                new ProductCategory("ProductCategory 3", true),
                new ProductCategory("ProductCategory 4", false),
            };
        }

        public DefaultProductCategoriesCreator(AbpProjectNameDbContext context)
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

        private void AddEntityIfNotExists(ProductCategory entity)
        {
            if (_context.ProductCategories.Any(p => p.DefaultName == entity.DefaultName))
            {
                return;
            }

            _context.ProductCategories.Add(entity);
            _context.SaveChanges();
        }
    }
}
