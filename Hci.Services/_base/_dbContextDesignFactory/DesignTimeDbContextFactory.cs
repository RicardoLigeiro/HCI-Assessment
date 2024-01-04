using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Hci.Services;

internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
{
    /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
    public DatabaseContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(Directory.GetCurrentDirectory() + "/../Hci.WebApi/appsettings.json").Build();
        var connectionString = configuration.GetSection("Settings:ConnectionStrings:Databases:Sql").Value;

        var builder = new DbContextOptionsBuilder<DatabaseContext>();
        builder.UseSqlServer(connectionString);
        return new DatabaseContext(builder.Options);
    }
}