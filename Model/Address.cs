using SQLite;

namespace OrderManager.Model
{
    public class Address
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string? Company { get; set; }
        public string? Name { get; set; }
        public string? Street { get; set; }
        public string? ZipCode { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? VatId { get; set; }
        public string? Identitycard { get; set; }
    }
}
