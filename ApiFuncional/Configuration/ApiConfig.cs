namespace ApiFuncional.Configuration
{
    // Configurações de Controllers
    public static class ApiConfig
    {
        public static WebApplicationBuilder AddApiConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers()
                            .ConfigureApiBehaviorOptions(options => // Configuração de comportamento da API
                            {
                                options.SuppressModelStateInvalidFilter = true; // Suprimindo (ignorando) a validação de modelo que iserimos na model
                            });

            return builder;
        }
    }
}
