namespace ApiFuncional.Models
{
    public class JwtSettings
    {
        public string? Segredo { get; set; } // Segredo do token

        public int ExpiracaoHoras { get; set; } // Tempo de expiração do token

        public string? Emissor { get; set; } // Aplicação que está emitindo o token

        public string? Audiencia { get; set; } // Onde esse token é válido
    }
}

