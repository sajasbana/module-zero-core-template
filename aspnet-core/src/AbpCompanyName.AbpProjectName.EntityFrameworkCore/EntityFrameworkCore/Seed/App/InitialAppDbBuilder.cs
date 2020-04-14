namespace AbpCompanyName.AbpProjectName.EntityFrameworkCore.Seed.App
{
    public class InitialAppDbBuilder
    {
        private readonly AbpProjectNameDbContext _context;

        public InitialAppDbBuilder(AbpProjectNameDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultProductCategoriesCreator(_context).Create();
            new DefaultProductCategoryTranslationsCreator(_context).Create();
            new DefaultProductsCreator(_context).Create();
            new DefaultProductTranslationsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
