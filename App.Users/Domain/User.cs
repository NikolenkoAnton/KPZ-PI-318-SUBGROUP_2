using System;
using System.Collections.Generic;
using System.Text;

namespace App.Users.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
    }
}
