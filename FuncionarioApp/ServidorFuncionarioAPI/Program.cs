var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços para controladores e endpoints da API
builder.Services.AddControllers();
// Adiciona os serviços do Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura o middleware HTTP
if (app.Environment.IsDevelopment())
{
    // Habilita o middleware do Swagger
    app.UseSwagger();
    // Habilita o middleware do SwaggerUI
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Habilita o roteamento
app.UseAuthorization();
app.MapControllers();

app.Run();