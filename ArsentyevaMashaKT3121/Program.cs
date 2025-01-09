using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using ArsentyevaMashaKT3121.Controllers;
using ArsentyevaMashaKT3121.Database;
using static ArsentyevaMashaKT3121.ServiceExtensions.ServiceExtensions;
using ArsentyevaMashaKT3121.Interfaces.TeachersInterfaces;


var builder = WebApplication.CreateBuilder(args);
var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

try
{
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();
    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<TeacherDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddScoped<IDepartmentService, DepartmentService>();
 
/*    builder.Services.AddDbContext<DepartmentDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));*/

    builder.Services.AddServices();


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }


    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}

catch (Exception ex)
{
    logger.Error(ex, "Stopped program because of exception");
}

finally
{
    LogManager.Shutdown();
}




