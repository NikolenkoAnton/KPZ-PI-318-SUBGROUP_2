using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
namespace App.News.Localization
{
     public interface ILocalizationManager
    {
        string GetResource(string key);
       
        string GetResource(string key, CultureInfo culture);
    }
}
