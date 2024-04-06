using EBagsDB.Models;

namespace EBagsDB.Models
{
    public class Products
    {
        public  int ID  { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal ActualPrice { get; set; }
        public decimal DiscountedPrice { get; set; }

    }
}
