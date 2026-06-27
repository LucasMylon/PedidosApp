using Microsoft.EntityFrameworkCore;
using PedidosApp.Api.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//MediatR
builder.Services.AddMediatR(m => {
    m.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
});

//Injeção de dependência para configurar a conexão
//com o banco de dados do SqlServer
builder.Services.AddDbContext<SqlServerContext>
    (options => options.UseSqlServer
        (builder.Configuration.GetConnectionString("SqlServer")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
