using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public class DesignDbContextFactory : IDesignTimeDbContextFactory<QuzzDbContext>
    {
        public QuzzDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(Directory.GetCurrentDirectory() + "../../Api/appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<QuzzDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseMySql(connectionString, new MariaDbServerVersion(new Version(11, 0, 2)));
            return new QuzzDbContext(builder.Options);
        }
    }
}
