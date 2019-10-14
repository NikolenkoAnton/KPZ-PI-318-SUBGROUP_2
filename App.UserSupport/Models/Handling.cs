using System.Collections.Generic;

namespace App.UserSupport.Models
{
    public class Handling
    {//unique id for Handling
        public int Id { get; set; }
        //context of Handling
        public List<string> context { get; set; } = new List<string>();
        //Status 
        public bool status { get; set; }
        //Client who write Handling
        private Client clientHandling;

        public Handling(Client client, string firstmessage, int id)
        {
            Id = id;
            status = false;
            clientHandling = client;
            WriteMessage(firstmessage);
        }
        public void WriteMessage(string mess)
        {
            if (status == false)
                context.Add(clientHandling.Name + " :  " + mess + "   ");
        }

        public void WriteAnswer(string answer)
        {
            if (status == false)
                context.Add("   Moderator :  " + answer);
        }
        //If closed handling, no display in active handlings
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
