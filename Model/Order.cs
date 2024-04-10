using SQLite;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;



namespace OrderManager.Model
{

    public class Order
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [SQLite.MaxLength(50)]

        public string? Name { get; set; }

        [SQLite.MaxLength(100)]
        [Required]
        public string? Number { get; set; }

        [SQLite.MaxLength(50)]
        [Required]
        public int? WeekOfManufacture { get; set; }

        public string? Product { get; set; }
        public string? Status { get; set; }
        public string? Operation { get; set; }
        public string? Date { get; set; }

        [ForeignKey("Customer")] // Odkaz na třídu Customer
        public int CustomerId { get; set; }


        [ForeignKey("Platform")] // Odkaz na třídu Customer
        public int PlatformId { get; set; }



        public enum Products
        {
            [Display(Name = "Stratos")]
            Stratos,
            [Display(Name = "Omega")]
            Omega,
            [Display(Name = "Delta")]
            Delta,
            [Display(Name = "Alfa")]
            Alfa,
            [Display(Name = "Monorail")]
            Monorail
        }

        public enum Statuses
        {
            [Display(Name = "Hotovo")]
            Hotovo,
            [Display(Name = "Zadáno")]
            Zadano,
            [Display(Name = "Dotaz")]
            Dotaz,
            [Display(Name = "Zrušeno")]
            Zruseno,
        }

        public enum Operations
        {
            [Display(Name = "Měření")]
            Mereni,
            [Display(Name = "Zástavba")]
            Zastavba,
            [Display(Name = "Schválení")]
            Schvaleni,
            [Display(Name = "Výkresy")]
            Vykresy,
            [Display(Name = "Dimenze")]
            Dimenze,
            [Display(Name = "Elektro")]
            Elektro,
            [Display(Name = "Uzavření")]
            Uzavreni,
        }
    }

    public static class EnumExtensions
    {
        public static string GetDisplayValue(this Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .FirstOrDefault()?
                            .GetCustomAttribute<DisplayAttribute>()?
                            .Name ?? enumValue.ToString();
        }
    }

}
