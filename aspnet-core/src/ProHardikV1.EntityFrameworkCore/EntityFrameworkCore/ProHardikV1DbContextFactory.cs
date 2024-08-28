using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ProHardikV1.Configuration;
using ProHardikV1.Web;

namespace ProHardikV1.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ProHardikV1DbContextFactory : IDesignTimeDbContextFactory<ProHardikV1DbContext>
    {
        public ProHardikV1DbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ProHardikV1DbContext>();
            
            /*
             You can provide an environmentName parameter to the AppConfigurations.Get method. 
             In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
             Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
             https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
             */
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            ProHardikV1DbContextConfigurer.Configure(builder, configuration.GetConnectionString(ProHardikV1Consts.ConnectionStringName));

            return new ProHardikV1DbContext(builder.Options);
        }
    }
}
