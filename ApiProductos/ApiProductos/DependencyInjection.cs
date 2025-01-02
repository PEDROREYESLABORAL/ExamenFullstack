namespace ApiProductos
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApi(this IServiceCollection services) {

            services.AddCors(options =>
            {
                // CorsOrigins
                var corsOrigins = new string[] {
                "http://localhost:3001"
                
            };
                options.AddPolicy("AllowSpecificOrigins", builder =>
                {
                    builder.WithOrigins(corsOrigins)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                });
            });
            
            services.AddControllers();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
}
