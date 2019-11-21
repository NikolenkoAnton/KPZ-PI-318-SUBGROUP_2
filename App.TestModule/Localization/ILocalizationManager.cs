using System.Globalization;

namespace App.Example.Localization
{
    // TODO add documentation
    public interface ILocalizationManager
    {
        string GetResource(string key);
        string GetResource(string key, CultureInfo culture);
    }
}