using System;
using System.Collections.Generic;
using System.Text;
using App.UserSupport.Interface;
using App.UserSupport.Models;

namespace App.UserSupport.Models
{
    public class Handling : IHandling
    {   //unique id for Handling
        public int Id { get; set; }
        //context of Handling
        public List<string> context { get; set; } = new List<string>();
        //Status 
        private Client client_handling;
        public bool status { get; set; }
        public Handling(Client client,string firstmessage,int id) 
        {
            Id = id;
            status = false;
            client_handling = client;
            WriteMessage(firstmessage);
        }
        public void Set_Handling_Status_Completed() => status = true;
        public void WriteMessage(string mess) {
            if (status == false)
                context.Add(client_handling.Name + " :  " + mess + "\n");
        }
        public void WriteAnswer(string answer)
        {
            if (status == false)
                context.Add("Moderator :  " + answer + "\n");
        }
        public string Get_Handling_10_last_messages()
        {
            string temp = ""; 
            int i = 0;
            while (i < 10 || i < context.Count)
            {
                temp += context[i];
                i++;
            }
            return temp;
        }
        public override string ToString()
        {
            string temp = "";
            if (status == false)
            {
                foreach (string a in context)
                    temp += a;
            }
            return temp;
        }
    }
}
