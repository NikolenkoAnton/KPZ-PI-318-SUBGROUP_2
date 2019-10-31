using System;
using System.Collections.Generic;
using System.Text;

namespace App.Stocks.Exceptions
{
    public class IncorrectParamsFormat : Exception
    {
        public string ParamName { get; private set; }
        public IncorrectParamsFormat(string ParamName) 
        {
            this.ParamName = ParamName;
        }
    }
}
