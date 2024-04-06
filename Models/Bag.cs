namespace EBags.Models
{
    public class Bag
    {
        public int ID { get; set; }
        public string BagBrand { get; set; }
        public string Material { get; set; }
        public string BagColor { get; set; }
        public decimal Price  { get; set; }
        public string BagType { get; set; }
        public decimal Discount { get; set; }
        
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
        public int IsActive { get; set; }
public string ActionType { get; set; }

    }
}
