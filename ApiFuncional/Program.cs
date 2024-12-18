using ApiFuncional.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Adicionando as configurações que colocamos em uma pasta específica para organização de nossa aplicação
builder.AddApiConfig()
       .AddCorsConfig()
       .AddSwaggerConfig()
       .AddDbContextConfig()
       .AddIdentityConfig();

var app = builder.Build();

// Configurações para o ambiente de desenvolvimento / produção
if (app.Environment.IsDevelopment()) 
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors("Development"); 
}
else
{
    app.UseCors("Production");
}

app.UseHttpsRedirection();

// Adicionando a autenticação de usuário em nossa API
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
