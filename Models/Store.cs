namespace Proiect_Dragut_Hanc.Models
{
    public class Store
    {
        public int? StoreID { get; set; }
        public string? StoreName { get; set; }

        public ICollection<Product> Products { get; set; }  
    }
}
