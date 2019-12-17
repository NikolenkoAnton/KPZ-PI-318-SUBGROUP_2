using System.Collections.Generic;

namespace App.UserSupport.Models
{
    public class Handling
    {//unique id for Handling
        public int Id { get; set; }
        //context of Handling
        public List<Message> context { get; set; } = new List<Message>();
        //Status 
        public bool status { get; set; }
        //Client who write Handling
        private Client clientHandling;

        public Handling(Client client, string firstmessage, int id,int messageId)
        {
            Id = id;
            status = false;
            clientHandling = client;
            WriteMessage(firstmessage, messageId);
        }
        public Handling() { }
        public void WriteMessage(string mess,int id)
        {
            if (status == false)
                context.Add(new Message(clientHandling,mess,id));
        }

        public void WriteAnswer(string answer,int id)
        {
            if (status == false)
                context.Add(new Message(answer,id));
        }
        //If closed handling, no display in active handlings
        public override string ToString()
        {
            string temp = "";
            if (status == false)
            {
                foreach (Message a in context)
                    temp += a.mess;
            }
            return temp;
        }
    }
}
