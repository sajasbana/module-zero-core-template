using Abp.AutoMapper;
using Abp.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpCompanyName.AbpProjectName.Authorization;
using AbpCompanyName.AbpProjectName.ProductCategories;
using AbpCompanyName.AbpProjectName.ProductCategories.Dto;
using AbpCompanyName.AbpProjectName.Products;
using AbpCompanyName.AbpProjectName.Products.Dto;
using AutoMapper;

namespace AbpCompanyName.AbpProjectName
{
    [DependsOn(
        typeof(AbpProjectNameCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class AbpProjectNameApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AbpProjectNameAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(AbpProjectNameApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            //can this be removed???
            //?????????????????????
            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );

            Configuration.Modules.AbpAutoMapper().Configurators.Add(configuration =>
            {
                CustomDtoMapper.CreateMappings(configuration, new MultiLingualMapContext(
                    IocManager.Resolve<ISettingManager>()
                ));
            });
        }

        internal static class CustomDtoMapper
        {
            public static void CreateMappings(IMapperConfigurationExpression configuration, MultiLingualMapContext context)
            {
                configuration.CreateMultiLingualMap<ProductCategory, ProductCategoryTranslation, ProductCategoryDto>(context);
                configuration.CreateMap<ProductCategoryCreateDto, ProductCategory>();
                configuration.CreateMap<ProductCategoryUpdateDto, ProductCategory>();
                configuration.CreateMap<ProductCategoryTranslationDto, ProductCategoryTranslation>();

                configuration.CreateMultiLingualMap<Product, ProductTranslation, ProductDto>(context);
                configuration.CreateMap<ProductCreateDto, Product>();
                configuration.CreateMap<ProductUpdateDto, Product>();
                configuration.CreateMap<ProductTranslationDto, ProductTranslation>();
            }
        }
    }
}
