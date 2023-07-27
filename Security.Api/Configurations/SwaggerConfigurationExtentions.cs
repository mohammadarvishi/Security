using Microsoft.OpenApi.Models;

namespace Security.Api.Configurations
{
    public static class SwaggerConfigurationExtentions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Security", Version = "v1" });

               
            });
        }

        public static void UseSwaggerAndUI(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Security v1"));

        }
    }
}
