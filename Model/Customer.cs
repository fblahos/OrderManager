using SQLite;

namespace OrderManager.Model
{
    public class Customer
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string? Telefon { get; set; }
        public string? Email { get; set; }

        public Address? Address { get; set; }


    }
}

