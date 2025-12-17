using Application.Services.Localization;
using Infrastructure.Localization.Resources;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Localization;

public class ResourceLocalizationService : ILocalizationService
{
    private readonly IStringLocalizer<Messages> _localizer;

    public ResourceLocalizationService(IStringLocalizer<Messages> localizer)
    {
        _localizer = localizer;
    }

    public string Get(string key)
        => _localizer[key];

    public string Get(string key, params object[] arguments)
        => string.Format(_localizer[key], arguments);
}
