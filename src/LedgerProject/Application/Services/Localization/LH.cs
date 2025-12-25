using Application.Services.Localization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.Localization;

public static class LH // Localization Helper
{
    public static string Get(string key)
    {
        var context = new HttpContextAccessor();
        var localizationServiceObject = context.HttpContext.RequestServices.GetService(typeof(ILocalizationService));
        if (localizationServiceObject != null)
        {
            var localizationService = (ILocalizationService)localizationServiceObject;
            var localizedString = localizationService.Get(key);
            return string.IsNullOrEmpty(localizedString) ? key : localizedString;
        }
        return key;
    }
}
