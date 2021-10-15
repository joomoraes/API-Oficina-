using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory:IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            // var connectionString = "Server=127.0.0.1;Port=3306;Database=dbAPI;Uid=root;Pwd=";
            var connectionString = "Server=DESKTOP-1DF7BFU;Initial Catalog=APIdb;MultipleActiveResultSets=true;User ID=sa;Password=lbr@2020";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            // optionsBuilder.UseMySql(connectionString);
            optionsBuilder.UseSqlServer(connectionString);
            return new MyContext(optionsBuilder.Options);
            
        }
    }
}
