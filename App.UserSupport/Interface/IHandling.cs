using System;
using System.Collections.Generic;
using System.Text;

namespace App.UserSupport.Interface
{
    public interface IHandling
    {
        void WriteMessage(string mess);
        void WriteAnswer(string answer);
        string Get_Handling_10_last_messages();
    }
}
