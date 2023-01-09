using System.Security.Policy;

namespace Proiect_Dragut_Hanc.Models.ViewModels
{
    public class StoreIndexData
    {
        public IEnumerable<Store> Store { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
