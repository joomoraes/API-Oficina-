using System;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceColletion) 
        {
            serviceColletion.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            serviceColletion.AddScoped<IUserRepository, UserImplementation>();

            serviceColletion.AddScoped<IUfRepository, UfImplementation>();
            serviceColletion.AddScoped<IMunicipioRepository, MunicipioImplementation>();
            serviceColletion.AddScoped<ICepRepository, CepImplementation>();

            if(Environment.GetEnvironmentVariable("DATABASE").ToLower() == "SQLSERVER".ToLower()) 
            {
                serviceColletion.AddDbContext<MyContext> (
                    //options => options.UseMySql ("Server=127.0.0.1;Port=3306;Database=dbAPI;Uid=root;Pwd=")
                    options => options.UseSqlServer (Environment.GetEnvironmentVariable("DB_CONNECTION"))
                );
            }
            else 
            {
                serviceColletion.AddDbContext<MyContext> (
                    //options => options.UseMySql ("Server=127.0.0.1;Port=3306;Database=dbAPI;Uid=root;Pwd=")
                    options => options.UseSqlServer ("Server=DESKTOP-1DF7BFU;Initial Catalog=APIdb_2;MultipleActiveResultSets=true;User ID=sa;Password=lbr@2020")
                );
            }
        }
    }
}
