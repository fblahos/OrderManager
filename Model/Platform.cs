using SQLite;

namespace OrderManager.Model
{
    public class Platform
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public double Delka { get; set; }
        public double Sirka { get; set; }
        public Najezd HorniNajezd { get; set; }
        public Najezd DolniNajezd { get; set; }
        public Najezd CetniNajezd { get; set; }
        public Sedacka sedacka { get; set; }
        public Nosnost nosnost { get; set; }
        public Mechanismus mechanismus { get; set; }
        public int CisloPodlahy { get; set; }

    }

    public enum Sedacka
    {
        Zadna,
        Ocelova,
        Calounena
    }


    public enum Nosnost
    {
        Nosnost225 = 225,
        Nosnost250 = 250,
        Nosnost300 = 300
    }
    public enum Mechanismus
    {
        Automat,
        Manual
    }

    public enum Najezd
    {
        Najezd150 = 150,
        Najezd200 = 200,
        Najezd300 = 300,
        Zadny
    }
}
