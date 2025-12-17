using Application.Services.Localization;
using Core.CrossCuttingConcerns.Exceptions.Handlers;
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

        return services; 
    }
}
