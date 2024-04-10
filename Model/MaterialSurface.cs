using SQLite;

namespace OrderManager.Model
{
    public class MaterialSurface
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public Material? material { get; set; }
        public Surface? PlosinaVoziky { get; set; }
        public Surface? DrahaPrichky { get; set; }
        public Surface? Sloupky { get; set; }
    }


    public enum Surface
    {
        Zinek,
        RAL,
        ZinekRal,
        Nerez

    }


    public enum Material
    {
        S235JR,
        Nerez304,
        Nerez316
    }
}
