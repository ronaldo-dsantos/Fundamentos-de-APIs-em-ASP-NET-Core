namespace ApiFuncional.Configuration
{
    // Configurações de Cors
    public static class CorsConfig
    {
        public static WebApplicationBuilder AddCorsConfig(this WebApplicationBuilder builder)
        {            
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Development", builder => // Adicionando uma política de acesso para o ambiente de desenvolvimento
                                    builder
                                        .AllowAnyOrigin() // Permitindo o acesso de qualquer origem
                                        .AllowAnyMethod() // Permitindo o acesso a qualquer método
                                        .AllowAnyHeader()); // Permitindo qualquer cabeçalho

                options.AddPolicy("Production", builder => // Adicionando uma política de acesso para o ambiente de produção
                                    builder
                                        .WithOrigins("https://localhost:9000") // Restringindo a origem do acesso
                                        .WithMethods("POST") // Restringindo o método de acesso
                                        .AllowAnyHeader()); // Permitindo qualquer cabeçalho
            });

            return builder;
        }
    }
}
