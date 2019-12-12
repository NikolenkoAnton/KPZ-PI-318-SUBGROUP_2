using System;
using System.Collections.Generic;
using System.Text;

namespace App.Stocks.Exceptions {
    public class IncorrectParamsFormatException : Exception {
        public string ParamName { get; private set; }
        public IncorrectParamsFormatException (string ParamName) {
            this.ParamName = ParamName;
        }
    }
}