
using Microsoft.EntityFrameworkCore;
using Seller.Api.Data;
using Seller.Api.Repository;

namespace Seller.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddTransient<ISellerRepository, SellerRepository>();
            // Add services to the container.
            builder.Services.AddDbContext<SellerDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SellerDb")));
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
