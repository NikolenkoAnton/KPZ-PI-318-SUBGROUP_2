using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;

namespace App.Web
{
    // TODO documentation
    public partial class Startup
    {
        private const string EnglishCultureCode = "en-US";
        private const string GermanCultureCode = "de-de";

        private void ConfigureLocalization(IServiceCollection services)
        {
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(EnglishCultureCode);
                options.SupportedCultures = new List<CultureInfo>
                {
                    new CultureInfo(EnglishCultureCode), // English
                    new CultureInfo(GermanCultureCode), // German
                };
                options.RequestCultureProviders.Clear();
                options.RequestCultureProviders.Add(new QueryStringRequestCultureProvider());
            });
        }
    }
}