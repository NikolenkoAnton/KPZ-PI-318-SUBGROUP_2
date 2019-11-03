using System;
using System.Collections.Generic;
using System.Text;

namespace App.UserSupport.Models
{
    public class Message
    {
        private Client clientHandling;

        public string mess { get; set; }
        public Message(Client client,string mess)
        {
            this.clientHandling = client;
            this.mess = clientHandling.Name + " : " + mess + " ";
        }
        public Message(string answer)
        {
            this.mess = "Moderator : " + answer + " ";
        }
    }
}
