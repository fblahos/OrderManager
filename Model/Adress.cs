using SQLite;

namespace OrderManager.Model
{
    public class Adress
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string? Firma { get; set; }
        public string? Jmeno { get; set; }
        public string? Ulice { get; set; }
        public string? PSC { get; set; }
        public string? Mesto { get; set; }
        public string? Stat { get; set; }
    }
}
