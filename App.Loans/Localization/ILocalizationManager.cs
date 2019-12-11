
using System.Globalization;


namespace App.Loans.Localization
{
    public interface ILocalizationManager
    {
        string GetResource(string key);
        string GetResource(string key, CultureInfo culture);
    }
}
