using System.Data.SqlClient;

namespace EBags.Models
{
    public class BAL
    {
        public Response Registration(Users users, SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.Registration(users, connection);
        }
        public Response Login(Users users, SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.Login(users, connection);
        }
        public Response ViewUser(Users users, SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.ViewUser(users, connection);
        }
        public Response UpdateUserProfile(Users users, SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.UpdateUserProfile(users, connection);
        }
        public Response AddToCart(Cart cart, SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.AddToCart(cart, connection);
        }

        public Response RemoveToCart(Cart cart, SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.RemoveToCart(cart, connection);
        }
        public Response PlaceOrder(Users users,SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.PlaceOrder(users, connection);        
        }
        public Response OrderList( Users users ,SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.OrderList( users,connection);
        }
        public Response AddUpdateBag(Bag bag, SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.AddUpdateBag(bag, connection);
        }

        public Response UserList(SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.UserList(connection);
        }

        public Response CartList(string email,SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.CartList( email,connection);
        }

        public Response UpdateOrderStatus(Orders order, SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.UpdateOrderStatus(order, connection);
        }

        public Response ProductList(SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.ProductList(connection);
        }

        public Response AddProduct(EBagsDB.Models.Products products,SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.AddProduct(products,connection);
        }

        public Response RemoveProduct(EBagsDB.Models.Products products, SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.AddProduct(products, connection);
        }
        public Response ProductListCarts(SqlConnection connection)
        {
            DAL dal = new DAL();
            return dal.ProductListCarts(connection);
        }

    }

}
