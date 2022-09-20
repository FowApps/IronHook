using IronHook.EntityFrameworkCore.Extensions;
using IronHook.EntityFrameworkCore.PostgreSql.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIronHook(opts =>
{
    opts.UseNpgsql(
        builder.Configuration.GetConnectionString("Default"),
        opts =>opts.UseIronHookNpgsqlMigrations()
        );
});

var app = builder.Build();

app.MigrateIronHook();

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
