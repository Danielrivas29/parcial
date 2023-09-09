using data;
using data.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connection = new mysqlconfig(builder.Configuration.GetConnectionString("mysqlConnection"));
builder.Services.AddSingleton(connection);
builder.Services.AddScoped<iClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped<iEmpleadosRepositorio, EmpleadosRepositorio>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
