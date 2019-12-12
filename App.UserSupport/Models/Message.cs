using System;
using System.Collections.Generic;
using System.Text;

namespace App.UserSupport.Models
{
    public class Message
    {
        private Client clientHandling;
        public int Id { get; set; }
        public string mess { get; set; }
        public Message(Client client,string mess,int id)
        {
            this.Id = id;
            this.clientHandling = client;
            this.mess = clientHandling.Name + " : " + mess + " ";
        }
        public Message(string answer,int id)
        {
            this.Id = id;
            this.mess = "Moderator : " + answer + " ";
        }
        public Message() { }
    }
}
