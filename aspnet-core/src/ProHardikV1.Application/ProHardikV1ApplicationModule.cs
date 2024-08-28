using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ProHardikV1.Authorization;

namespace ProHardikV1
{
    [DependsOn(
        typeof(ProHardikV1CoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ProHardikV1ApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ProHardikV1AuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ProHardikV1ApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
