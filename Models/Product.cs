using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Proiect_Dragut_Hanc.Migrations;


namespace Proiect_Dragut_Hanc.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Display(Name = "Product")] 
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        [Column(TypeName ="decimal(6,2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime AvailabilityDate { get; set; }
        public int? StoreID{ get; set; }
        public Store? Store { get; set; }

        public Admin? Admin { get; set; }


        public ICollection<ProductCategory>? ProductCategories { get; set; }
          
    }
}
