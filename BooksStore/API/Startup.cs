using API.Controllers;
using API.Controllers.Interface;
using API.Controllers.Repository;
using API.Data;
using API.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;

namespace API
{
    public class Startup
    {
        //testing
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("Product", new OpenApiInfo
                {
                    Title = "Product",
                    Version = "v1"
                });
                c.SwaggerDoc("Mobile", new OpenApiInfo
                {
                    Title = "Mobile",
                    Version = "v1"
                });
                c.SwaggerDoc("Account", new OpenApiInfo
                {
                    Title = "Account",
                    Version = "v1"
                });

                c.SwaggerDoc("BlogImage", new OpenApiInfo
                {
                    Title = "BlogImageNew",
                    Version = "v1"
                });
            });
             services.AddScoped<IProduct,ProductRepo>();
             services.AddScoped<IBookDetail,BookDetailRepo>();
             services.AddScoped(typeof(IGenericDetail<>),typeof(GenericRepo<>));
             services.AddScoped<ITokenService,TokenService>();
            services.AddScoped<IBlogImage, BlogImageRepo>();
           // services.AddScoped<IBasketInterface, BasketRepo>();
            //services.AddScoped<CustomMiddleware>();
             //services.AddScoped<IAccountInterface,AccountRepo>();
             //this is for configuring the automapper and provide it 
             //with Current assesmbly as it would find the same.

            services.AddDbContext<StoreContext>
            (x=>x.UseSqlServer(Configuration.GetConnectionString("DefaultConection")));

            //for auth identity Server
            services.AddDbContext<AuthDbContext>
            (x => x.UseSqlServer(Configuration.GetConnectionString("AuthConection")));

            ////for Redis In Memory Data structure
            //services.AddSingleton<IConnectionMultiplexer>(c =>
            //{
            //    var options = ConfigurationOptions.Parse(Configuration.GetConnectionString("Redis"));
            //        return ConnectionMultiplexer.Connect(options);
            //});
            //services.AddScoped<StoreContext,ProductController>();
            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

            // Named Policy - allow anyone (any origin, any header, any method)
            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowAll",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            //For AutoMapper using
            services.AddAutoMapper(typeof(AccountController).Assembly);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/Product/swagger.json", "Product");
                c.SwaggerEndpoint("/swagger/Mobile/swagger.json", "Mobile");
                c.SwaggerEndpoint("/swagger/Account/swagger.json", "Account");
                c.SwaggerEndpoint("/swagger/BlogImage/swagger.json", "BlogImage");
            });

            app.UseMiddleware<ExceptionHandingMiddleware>();

            app.UseHttpsRedirection();

            app.UseCustomNewMiddleware();


            app.UseRouting();

            // Apply the named CORS policy here so requests from any origin are allowed.
            app.UseCors("AllowAll");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", context =>
                {
                    context.Response.Redirect("/swagger/index.html");
                    return Task.CompletedTask;
                });
            });
        }
    }
}
