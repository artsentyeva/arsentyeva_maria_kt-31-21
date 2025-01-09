using ArsentyevaMashaKT3121.Interfaces.TeachersInterfaces;
using ArsentyevaMashaKT3121.Properties.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArsentyevaMashaKT3121.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentService, DepartmentService>();
            return services;
        }
    }
}
