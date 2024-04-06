namespace EBags.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public int BagID { get; set; }
        public int UserID { get; set; }
        public string BagBrand { get; set; }
        public string BagType { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set;}
        public decimal TotalPrice { get; set; }
        public string Email { get; set; }
    }
}
