var builder = WebApplication.CreateBuilder(args);

// Adicionando suporte a controllers
builder.Services.AddControllers();

// Adicionando o mecanismo que vai nos ajudar a mepear todos nossos endpoints
builder.Services.AddEndpointsApiExplorer();

// Adicionando o Swagger
builder.Services.AddSwaggerGen();

// Fazendo o build da aplicação
var app = builder.Build();

// Expondo o Swagger se o ambiente for de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirecionamento de HTTPS
app.UseHttpsRedirection();

// Adicionando autorização de usuários
app.UseAuthorization();

// Mapeando todas as controller da aplicação para gerar as rotas
app.MapControllers();

// Alternativa para mapear as rotas da aplicação sem ser diretamente na controller
app.MapGet("/", () => "Acesse /swagger para mais informações"); 
app.MapGet("/teste-get", () => "Teste");

// Rodando a aplicação
app.Run();
