using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Abp.Localization;
using Abp.MultiTenancy;
using AbpCompanyName.AbpProjectName.Products;

namespace AbpCompanyName.AbpProjectName.EntityFrameworkCore.Seed.App
{
    public class DefaultProductsCreator
    {
        public static List<Product> InitialEntities => GetInitialEntities();

        private readonly AbpProjectNameDbContext _context;

        private static List<Product> GetInitialEntities()
        {
            return new List<Product>
            {
                new Product(1),
                new Product(2, 5, 20),
                new Product(2, 4, 2),
                new Product(3, 4, 2),
            };
        }

        public DefaultProductsCreator(AbpProjectNameDbContext context)
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

        private void AddEntityIfNotExists(Product entity)
        {
            if (_context.Products.Any(p => p.Id == entity.Id))
            {
                return;
            }

            _context.Products.Add(entity);
            _context.SaveChanges();
        }
    }
}
