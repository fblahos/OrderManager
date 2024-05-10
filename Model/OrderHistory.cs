using SQLite;

namespace OrderManager.Model
{
    public class OrderHistory
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string? Date { get; set; }
        public string? PreviousValue { get; set; }
        public string? NewValue { get; set; }




    }
}
