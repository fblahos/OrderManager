using SQLite;

namespace OrderManager.Model
{
    public class Distributor
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public string? Telefon { get; set; }
        public string? Email { get; set; }

        public Address? Address { get; set; }
    }
}
