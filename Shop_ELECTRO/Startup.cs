using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop_ELECTRO.Data.DataBase;
using Shop_ELECTRO.Data.Interfaces;
using Shop_ELECTRO.Data.Models;
using System.Collections.Generic;

namespace Shop_ELECTRO
{
    public class Startup
    {
        //public static List<ItemsBasket> BasketItem = new List<ItemsBasket>();
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IItems, DBItems>();
            services.AddTransient<ICategorys, DBCategory>();
            services.AddMvc(option => option.EnableEndpointRouting = false);
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}