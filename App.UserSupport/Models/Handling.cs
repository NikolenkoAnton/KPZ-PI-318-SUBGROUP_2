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
            WriteMessage(clientHandling.Name, firstmessage);
        }

        public void SetHandlingStatusCompleted() => status = true;

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

        public string GetHandling10LastMessages()
        {
            string temp = "";
            List<string> somelist = context;
            somelist.Reverse();
            int i = context.Count - 1;
            int j = 0;
            while (i >= 0)
            {
                if (j < 10)
                    temp += somelist.ToArray()[i];
                i--;
                j++;
            }
            return temp;
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

        public void WriteMessage(string Name, string mess)
        {
            if (status == false)
                context.Add(Name + " :  " + mess + "   ");
        }
    }
}
