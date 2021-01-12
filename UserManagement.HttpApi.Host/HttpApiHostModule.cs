using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Swagger;

namespace UserManagement
{
    public static class HttpApiHostModule
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddControllers();
            ConfigureSwaggerServices(services);
        }

        private static void ConfigureSwaggerServices(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "User Management API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
                options.DocumentFilter<LowercaseDocumentFilter>();
            });
        }

        public static void ApplicationInitialize(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "User Management API");
            });
        }
    }
}
