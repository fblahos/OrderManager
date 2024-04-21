using SQLite;

namespace OrderManager.Model
{
    public class Platform
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public double Length { get; set; }
        public double Width { get; set; }
        public string? UpperRamp { get; set; }
        public string? LowerRamp { get; set; }
        public string? FrontRamp { get; set; }
        public string? Seat { get; set; }
        public string? LoadingCapacity { get; set; }

        public int PlatformNumber { get; set; }

        public bool IsAutomaticFolding { get; set; }
        public bool IsManualFolding { get; set; }

        public bool IsFixedFront { get; set; }
        public bool IsFoldableFront { get; set; }
        public bool IsFrontRamp85Degrees { get; set; }


    }



}
