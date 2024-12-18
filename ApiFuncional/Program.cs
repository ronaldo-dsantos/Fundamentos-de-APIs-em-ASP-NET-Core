using ApiFuncional.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Adicionando as configura��es que colocamos em uma pasta espec�fica para organiza��o de nossa aplica��o
builder.AddApiConfig()
       .AddCorsConfig()
       .AddSwaggerConfig()
       .AddDbContextConfig()
       .AddIdentityConfig();

var app = builder.Build();

// Configura��es para o ambiente de desenvolvimento / produ��o
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

// Adicionando a autentica��o de usu�rio em nossa API
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
