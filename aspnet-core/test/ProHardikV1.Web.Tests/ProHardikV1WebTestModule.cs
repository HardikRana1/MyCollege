using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ProHardikV1.EntityFrameworkCore;
using ProHardikV1.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace ProHardikV1.Web.Tests
{
    [DependsOn(
        typeof(ProHardikV1WebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class ProHardikV1WebTestModule : AbpModule
    {
        public ProHardikV1WebTestModule(ProHardikV1EntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ProHardikV1WebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(ProHardikV1WebMvcModule).Assembly);
        }
    }
}