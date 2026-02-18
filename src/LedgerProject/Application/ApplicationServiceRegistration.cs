using Application.Features.Corp.Companies.Rules;
using Application.Features.Corp.CompanyUsers.Rules;
using Application.Features.Finance.AccountingPeriods.Rules;
using Application.Features.Finance.CurrentAccounts.Rules;
using Application.Features.Finance.CurrentMovementDetails.Rules;
using Application.Features.Finance.CurrentMovements.Rules;
using Application.Features.Finance.MovementTypes.Rules;
using Application.Features.Identity.OperationClaims.Rules;
using Application.Features.Identity.UserOperationClaims.Rules;
using Application.Features.Identity.UserSessions.Rules;
using Core.Application.Piplines.Validation;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddTransient<CompanyBusinessRules>();
        services.AddTransient<CompanyUserBusinessRules>();

        services.AddTransient<AccountingPeriodBusinessRules>();
        services.AddTransient<CurrentAccountBusinessRules>();
        services.AddTransient<CurrentMovementBusinessRules>();
        services.AddTransient<CurrentMovementDetailRules>();
        services.AddTransient<MovementTypeBusinessRules>();

        services.AddTransient<OperationClaimBusinessRules>();
        services.AddTransient<UserOperationClaimBusinessRules>();
        services.AddTransient<UserSessionBusinessRules>();

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
        });
        return services;
    }
}
