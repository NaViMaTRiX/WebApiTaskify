using System.Text.Json;
using System.Text.Json.Serialization;
using Asp.Versioning;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using WebApiTaskify.Data;
using WebApiTaskify.Interface;
using WebApiTaskify.Models.Enum;
using WebApiTaskify.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddApiVersioning(options =>
    {
        options.DefaultApiVersion = new ApiVersion(1, 0);
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.ReportApiVersions = true;
    })
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });


builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddScoped<IBoardRepository, BoardRepository>();
builder.Services.AddScoped<IListRepository, ListRepository>();
builder.Services.AddScoped<ICardRepository, CardRepository>();
builder.Services.AddScoped<IOrgLimitRepository, OrgLimitRepository>();
builder.Services.AddScoped<IOrgSubscriptionRepository, OrgSubscriptionRepository>();
builder.Services.AddScoped<IAuditLogRepository, AuditLogRepository>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
app.UseHttpsRedirection();
app.Run();