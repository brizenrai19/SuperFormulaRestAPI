using SuperFormulaRestAPI.Data;
using Microsoft.EntityFrameworkCore;
using SuperFormulaRestAPI.BusinessLogic;
using SuperFormulaRestAPI.BusinessLogic.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddSingleton<IPolicyValidator, PolicyValidatorRepository>();
builder.Services.AddSingleton<IEventBusService, EventBusService>();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapDefaultControllerRoute();

app.Run();

public partial class Program { };


