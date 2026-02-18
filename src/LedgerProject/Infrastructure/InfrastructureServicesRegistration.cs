using Application.Services.Localization;
using Core.CrossCuttingConcerns.Exceptions.Handlers;
using Core.Security.Hashing;
using Core.Security.JWT;
using Infrastructure.Localization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureService(this IServiceCollection services)
    {
        services.AddTransient<HttpExceptionHandler>();

        services.AddLocalization();
        services.AddScoped<ILocalizationService, ResourceLocalizationService>();
        
        services.AddScoped<IHashingService, HashingService>();
        services.AddScoped<ITokenHelper, JwtHelper>();

        return services; 
    }
}
