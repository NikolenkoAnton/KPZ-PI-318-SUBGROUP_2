﻿using System;
using System.Collections.Generic;
using System.Text;

namespace App.News.Exceptions
{
    public class ValidationException: Exception
    {
        public ValidationException(string message) : base(message)
        {

        }
    }
}
