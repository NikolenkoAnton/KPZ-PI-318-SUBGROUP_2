using System;
using System.Collections.Generic;
using System.Text;
using App.UserSupport.Interface;
using App.UserSupport.Models;

namespace App.UserSupport.Models
{
    public class Handling : IHandling
    {//unique id for Handling
        public int Id { get; set; }
        //context of Handling
        public List<string> context { get; set; } = new List<string>();
        //Status 
        public bool status { get; set; }
        public Handling(Client client,string firstmessage,int id) 
        {
            Id = id;
            status = true;
            WriteMessage(client.Name, firstmessage);
        }
        public void WriteMessage(string Name, string mess) {
            if (status == true)
                context.Add(Name + " :  " + mess + "\n");
        }
    }
}
