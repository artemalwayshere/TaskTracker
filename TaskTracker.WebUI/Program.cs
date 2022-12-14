using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using TaskTracker.DAL;
using TaskTracker.Logic.Implementations;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TaskTrackerAPI", Version = "v1" });

    var filePath = Path.Combine(System.AppContext.BaseDirectory, "TaskTracker.xml");
    c.IncludeXmlComments(filePath);
});

builder.Services.AddDbContext<TrackerDBContext>(
    i => i.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<MyTaskService>();
builder.Services.AddTransient<ProjectService>();
builder.Services.AddTransient<SortService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
