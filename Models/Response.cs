using EBagsDB.Models;

namespace EBags.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
       public string StatusMessage { get; set; }
        public List<Users> listUsers { get; set; }
        public Users user { get; set; }
        public List<Bag> listBag { get; set; }
        public Bag bag { get; set; }
        public List<Cart> listCart { get; set; }
        public List<Orders> listOrders { get; set; }
        public Orders order { get; set; }
        public List<OrderItem> listOrderItem { get; set; }
        public OrderItem OrderItem { get; set; }
        public Products products { get; set; }
       public List<Products> listProducts { get; set; }
        public string ErrorMessage { get; set; }
        public string Type { get; set; }

    }

}
