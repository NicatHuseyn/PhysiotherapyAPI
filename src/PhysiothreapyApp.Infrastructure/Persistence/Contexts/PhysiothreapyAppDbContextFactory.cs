using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using PhysiothreapyApp.Domain.Options;

namespace PhysiothreapyApp.Infrastructure.Persistence.Contexts;

//public class PhysiothreapyAppDbContextFactory(IConfiguration configuration) : IDesignTimeDbContextFactory<PhysiothreapyAppDbContext>
//{
//    public PhysiothreapyAppDbContext CreateDbContext(string[] args)
//    {

//        var connectionString = configuration.GetSection(ConnectionStringOption.Key).Get<ConnectionStringOption>();

//        var optionsBuilder = new DbContextOptionsBuilder<PhysiothreapyAppDbContext>();

//        optionsBuilder.UseSqlServer(connectionString!.SqlServer);

//        return new PhysiothreapyAppDbContext(optionsBuilder.Options);
//    }
//}
