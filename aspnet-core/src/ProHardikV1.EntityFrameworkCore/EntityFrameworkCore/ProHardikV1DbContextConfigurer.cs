using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ProHardikV1.EntityFrameworkCore
{
    public static class ProHardikV1DbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ProHardikV1DbContext> builder, string connectionString)
        {
            builder.UseNpgsql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ProHardikV1DbContext> builder, DbConnection connection)
        {
            builder.UseNpgsql(connection);
        }
    }
}
