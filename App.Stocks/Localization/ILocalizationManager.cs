using System.Globalization;

namespace App.Stocks.Localization
{
    public interface ILocalizationManagerStocks
    {
        string GetResource(string key);
        string GetResource(string key, CultureInfo culture);
    }
}
