namespace EBags.Models
{
    public class OrderItem
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public string BagBrand { get; set; }
        public int Price { get; set; }
        public decimal Discount { get; set; }

        public int QuantityID { get; set; }
        public int TotalPrice { get; set; }

    }
}
