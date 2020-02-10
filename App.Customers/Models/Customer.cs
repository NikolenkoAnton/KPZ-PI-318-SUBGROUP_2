namespace App.Customers.Models
{
    public class Customer
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public long CardNumber { get; set; }

        public Customer(string surname, string name, long cardNumber)
        {
            this.Surname = surname;
            this.Name = name;
            this.CardNumber = cardNumber;
        }

        public Customer()
        {
        }
    }
}
