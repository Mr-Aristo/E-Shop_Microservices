using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;

namespace Order.Infrastructure
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // appsettings.json dosyasından konfigürasyonu okuma
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Connection string'i okuma
            var connectionString = configuration.GetConnectionString("Database");

            // DbContextOptions oluşturma
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ApplicationDbContext(optionsBuilder.Options);


        }
    }
}
/*Bu sinifin amaci migrasyon yapilirken .netcore program.cs icindeki injeksiyonu kullanamiyor ve DI tam olarak calismiyor. 
 bu yapi sayesinde .net core tam olarak hangi contexti calistiracagini biliyor.
 */