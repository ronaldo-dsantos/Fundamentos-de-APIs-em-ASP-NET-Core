namespace ApiFuncional.Configuration
{
    // Configurações de Controllers
    public static class ApiConfig
    {
        public static WebApplicationBuilder AddApiConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers()
                            .ConfigureApiBehaviorOptions(options =>
                            {
                                options.SuppressModelStateInvalidFilter = true;
                            });

            return builder;
        }
    }
}
