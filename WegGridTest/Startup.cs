using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using WegGridCore.Data;
using WegGridCore.EF;

namespace WegGridTest
{
        public class Startup
        {


        public void ConfigureServices(IServiceCollection services)
            {
            services.AddDbContext<DataContext>(options => options.UseSqlite($"Data Source={System.IO.Path.GetFullPath(@"..\..\..\..\WegGridApplication")}/WegGridDb.db"));
            services.AddTransient<IOrderRepository, OrderRepository>();
            }
        }
}
