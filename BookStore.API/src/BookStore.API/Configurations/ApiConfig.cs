using System.Net.Mime;
using System.Text.Json;

namespace BookStore.API.Configurations
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfig(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();



            return services;
        }
        public static IApplicationBuilder UseApiConfig(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapGet("/api/info", async (context) =>
                {
                    var result = new
                    {
                        environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                    };

                    context.Response.ContentType = MediaTypeNames.Application.Json;
                    await HttpResponseWritingExtensions.WriteAsync(context.Response, JsonSerializer.Serialize(result));
                });
            });

            return app;
        }
    }
}
