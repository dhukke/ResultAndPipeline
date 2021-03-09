using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using ResultPipeline.Options;

namespace ResultPipeline.Configurators
{
    public static class ConfiguratorsExntesions
    {
        public static void ConfigureSwagger(
            this IApplicationBuilder app,
            IConfiguration configuration
        )
        {
            var swaggerOptions = new SwaggerOptions();
            configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

            app.UseSwagger(options => { options.RouteTemplate = swaggerOptions.JsonRoute; });

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(swaggerOptions.UiEndpoint, swaggerOptions.Description);
            });
        }
    }
}
