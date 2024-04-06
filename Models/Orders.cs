namespace EBags.Models
{
    public class Orders
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string OrderNumber { get; set; }
        public int OrderTotal { get; set; }
        public string OrderStatus { get; set; }
        public string CustomerName { get; set; }

        public string BagBrand { get; set; }
        public string Material { get; set; }
        public int Price  { get; set; }
        public int  Quantity { get; set; }
        public int  TotalPrice { get; set; }
        public string ImageUrl { get; set; }
    }
}
