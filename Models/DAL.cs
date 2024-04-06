using System.Data.SqlClient;
using System.Data;
using EBagsDB.Models;
using System.Reflection.Metadata.Ecma335;
using System.ComponentModel.DataAnnotations;

namespace EBags.Models
{
    public class DAL
    {
        public Response Registration(Users users, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_Registration", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", users.UserID);
            cmd.Parameters.AddWithValue("@FirstName", users.FirstName);
            cmd.Parameters.AddWithValue("@LastName", users.LastName);
            cmd.Parameters.AddWithValue("@Email", users.Email);
            cmd.Parameters.AddWithValue("@Password", users.Password);
            cmd.Parameters.AddWithValue("@Address", users.Address);
            cmd.Parameters.AddWithValue("@Type", users.Type);
            cmd.Parameters.AddWithValue("@IsActive", users.IsActive);
            cmd.Parameters.Add("@Output_Message", SqlDbType.VarChar, 100);
            cmd.Parameters["@Output_Message"].Direction = ParameterDirection.Output;

            
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.Type = users.Type;
                response.StatusCode = 200;
                response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
            }
            else
            {
                response.Type = null;
                response.StatusCode = 100;
                response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
            }
            return response;
        }
        public Response Login(Users users, SqlConnection connection)
        {
            SqlDataAdapter da = new SqlDataAdapter("sp_Login", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Email", users.Email);
            da.SelectCommand.Parameters.AddWithValue("@Password", users.Password);
            
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response response = new Response();
            Users user = new Users();
            if ( dt.Rows.Count > 0)
            {
                user.UserID = Convert.ToInt32(dt.Rows[0]["UserID"]);
                user.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                user.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                user.Email = Convert.ToString(dt.Rows[0]["Email"]);
                user.Type = Convert.ToString(dt.Rows[0]["Type"]);
                response.StatusCode = 200;
                response.StatusMessage = "User is valid";
                response.user = user;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Invalid user";
                response.user = null;
            }
            return response;

        }
        public Response ViewUser(Users users, SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand("sp_ViewUser", connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", users.UserID);
            cmd.Parameters.AddWithValue("@Email", users.Email);

            da.SelectCommand.Parameters.Add("@Output_Message", SqlDbType.VarChar, 100);
            da.SelectCommand.Parameters["@Output_Message"].Direction = ParameterDirection.Output;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response response = new Response();
            Users user = new Users();
            if (dt.Rows.Count > 0)
            {
                user.UserID = Convert.ToInt32(dt.Rows[0]["UserID"]);
                user.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                user.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                user.Email = Convert.ToString(dt.Rows[0]["Email"]);
                user.Password = Convert.ToString(dt.Rows[0]["Password"]);
                user.Address = Convert.ToString(dt.Rows[0]["Address"]);
                user.Type = Convert.ToString(dt.Rows[0]["Type"]);
               
                response.StatusCode = 200;
                response.StatusMessage = "User exists"; Convert.ToString(cmd.Parameters["@Output_Message"].Value);
                response.user = user;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "User does not exists"; Convert.ToString(cmd.Parameters["@Output_Message"].Value);
                response.user = null;
            }
            return response;

        }
        public Response UpdateUserProfile(Users users, SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand("sp_UpdateUserProfile", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserID", users.UserID);
            cmd.Parameters.AddWithValue("@FirstName", users.FirstName);
            cmd.Parameters.AddWithValue("@LastName", users.LastName);
            cmd.Parameters.AddWithValue("@Email", users.Email);
            cmd.Parameters.AddWithValue("@Password", users.Password);
            cmd.Parameters.AddWithValue("@Address", users.Address);
            cmd.Parameters.AddWithValue("@Type", users.Type);
            cmd.Parameters.AddWithValue("@IsActive", users.IsActive);
            cmd.Parameters.Add("@Output_Message", SqlDbType.VarChar, 100);
            cmd.Parameters["@Output_Message"].Direction = ParameterDirection.Output;

            Response response = new Response();
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
            }
            return response;
        }
        public Response AddToCart(Cart cart, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_AddToCart", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.AddWithValue("@BagBrand", cart.BagBrand); 
            cmd.Parameters.AddWithValue("@BagType", cart.BagType);
            cmd.Parameters.AddWithValue("@Discount", cart.Discount);
            cmd.Parameters.AddWithValue("@TotalPrice", cart.TotalPrice);
            cmd.Parameters.AddWithValue("@Price", cart.Price);
            cmd.Parameters.AddWithValue("@Email", cart.Email);
            cmd.Parameters.AddWithValue("@Quantity", cart.Quantity);
            cmd.Parameters.AddWithValue("@BagID", cart.BagID);
            cmd.Parameters.Add("@Output_Message", SqlDbType.VarChar, 100);
            cmd.Parameters["@Output_Message"].Direction = ParameterDirection.Output;

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
            }
            return response;

        }

        public Response RemoveToCart(Cart cart, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_RemoveToCart", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Email", cart.Email);
            cmd.Parameters.AddWithValue("@ID", cart.ID);

            cmd.Parameters.Add("@Output_Message", SqlDbType.VarChar, 100);
            cmd.Parameters["@Output_Message"].Direction = ParameterDirection.Output;
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
            }
            return response;
        }


            public Response PlaceOrder(Users users, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_PlaceOrder ", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Email", users.Email);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Order has been placed successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Order could not be placed";
            }
            return response;

        }
        public Response OrderList(Users users , SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand("sp_OrderList", connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
           
            da.SelectCommand.Parameters.AddWithValue("@UserID", users.UserID);
            
            da.SelectCommand.Parameters.AddWithValue("@Type", users.Type);
            da.SelectCommand.Parameters.AddWithValue("@Email", users.Email);
           



            da.SelectCommand.Parameters.Add("@Output_Message", SqlDbType.VarChar, 100);
            da.SelectCommand.Parameters["@Output_Message"].Direction = ParameterDirection.Output;
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Orders> listOrder = new List<Orders>();
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Orders orders = new Orders();
                    orders.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    orders.OrderNumber = Convert.ToString(dt.Rows[i]["OrderNumber"]);
                    orders.OrderTotal = Convert.ToInt32(dt.Rows[i]["OrderTotal"]);
                    orders.OrderStatus = Convert.ToString(dt.Rows[i]["OrderStatus"]);
                    orders.CustomerName = Convert.ToString(dt.Rows[i]["CustomerName"]);

                    if (users.Type == "UserItems")
                    {
                        orders.BagBrand = Convert.ToString(dt.Rows[i]["BagBrand"]);
                        orders.Material = Convert.ToString(dt.Rows[i]["Material"]);
                        orders.Material = Convert.ToString(dt.Rows[i]["BagColor"]);
                        orders.Material = Convert.ToString(dt.Rows[i]["BagType"]);
                        orders.Price = Convert.ToInt32(dt.Rows[i]["Price"]);
                        orders.Quantity = Convert.ToInt32(dt.Rows[i]["Quantity"]);
                        orders.TotalPrice = Convert.ToInt32(dt.Rows[i]["TotalPrice"]);
                        orders.ImageUrl = Convert.ToString(dt.Rows[i]["ImageUrl"]);
                    }
                    listOrder.Add(orders);
                }
                if (listOrder.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
                    response.listOrders = listOrder;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value); ;
                    response.listOrders = null;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
                response.listOrders = null;
            }
            return response;

        }
        public Response AddUpdateBag(Bag bag, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_AddUpdateBag", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            List<Bag> listBag = new List<Bag>();
            cmd.Parameters.AddWithValue("@ID", bag.ID);
            cmd.Parameters.AddWithValue("@BagBrand", bag.BagBrand);
            cmd.Parameters.AddWithValue("@Material", bag.Material);
            cmd.Parameters.AddWithValue("@BagColor", bag.BagColor);
            cmd.Parameters.AddWithValue("@Price", bag.Price);
            cmd.Parameters.AddWithValue("@BagType", bag.BagType);
            cmd.Parameters.AddWithValue("@Discount", bag.Discount);
            cmd.Parameters.AddWithValue("@ImageUrl", bag.ImageUrl);
            cmd.Parameters.AddWithValue("@Quantity", bag.Quantity);
            cmd.Parameters.AddWithValue("@IsActive", bag.IsActive);
            cmd.Parameters.AddWithValue("@ActionType", bag.ActionType);
            cmd.Parameters.Add("@Output_Message", SqlDbType.VarChar, 100);
            cmd.Parameters["@Output_Message"].Direction = ParameterDirection.Output;
            if (bag.ActionType != "Get" && bag.ActionType != "GetByID")
            {
                connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {

                    response.StatusCode = 200;
                    if (bag.ActionType == "Add")
                        response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);

                    if (bag.ActionType == "Update")
                        response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);

                    if (bag.ActionType == "Delete")
                        response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);

                }
                else
                {
                    response.StatusCode = 100;
                    if (bag.ActionType == "Add")
                        response.StatusMessage = "Bag did not save. try again.";
                    if (bag.ActionType == "Update")
                        response.StatusMessage = "Bag did not update. try again.";
                    if (bag.ActionType == "Delete")
                        response.StatusMessage = "Bag did not delete. try again.";
                }
            }
            {
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Bag bags = new Bag();
                        bags.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                        bags.BagBrand = Convert.ToString(dt.Rows[i]["BagBrand"]);
                        bags.Material = Convert.ToString(dt.Rows[i]["Material"]);
                        bags.BagColor = Convert.ToString(dt.Rows[i]["BagColor"]);
                        bags.BagType = Convert.ToString(dt.Rows[i]["BagType"]);
                        bags.Discount = Convert.ToDecimal(dt.Rows[i]["Discount"]);
                        bags.Quantity = Convert.ToInt32(dt.Rows[i]["Quantity"]);
                       bags.ImageUrl = Convert.ToString(dt.Rows[i]["ImageUrl"]);
                        bags.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
                        listBag.Add(bags);
                    }
                    if (listBag.Count > 0)
                    {
                        response.StatusCode = 200;
                        response.listBag = listBag;
                    }
                    else
                    {
                        response.StatusCode = 100;
                        response.listBag = null;
                    }
                }
            }
            return response;

        }
        public Response UserList(SqlConnection connection)
        {
            
            SqlCommand cmd = new SqlCommand("sp_UserList", connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Output_Message", SqlDbType.VarChar, 100);
            da.SelectCommand.Parameters["@Output_Message"].Direction = ParameterDirection.Output;
            Response response = new Response();
            List<Users> listUsers = new List<Users>();
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Users user = new Users();
                    user.UserID = Convert.ToInt32(dt.Rows[i]["UserID"]);
                    user.FirstName = Convert.ToString(dt.Rows[i]["FirstName"]);
                    user.LastName = Convert.ToString(dt.Rows[i]["LastName"]);
                    user.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    user.Password = Convert.ToString(dt.Rows[i]["Password"]);
                    user.Address = Convert.ToString(dt.Rows[i]["Address"]);
                    user.Type = Convert.ToString(dt.Rows[i]["Type"]);
                    user.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);

                    listUsers.Add(user);
                }
                if (listUsers.Count > 0)
                {


                    response.StatusCode = 200;
                    response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
                    response.listUsers = listUsers;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
                    response.listUsers = null;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
                response.listUsers = null;
            }

                return response;
            }


        public Response CartList( string email, SqlConnection connection)
        {
            Response response = new Response();
            List<Cart> listCart = new List<Cart>();
            SqlDataAdapter da = new SqlDataAdapter("sp_CartList", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Email",email);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Cart carts= new Cart();
                   carts.ID= Convert.ToInt32(dt.Rows[i]["ID"]);
                   
                   
                    carts.BagBrand = Convert.ToString(dt.Rows[i]["BagBrand"]);
                    carts.BagType = Convert.ToString(dt.Rows[i]["BagType"]);
                    carts.Price = Convert.ToInt32(dt.Rows[i]["Price"]);
                    carts.Discount = Convert.ToInt32(dt.Rows[i]["Discount"]);
                    carts.Quantity = Convert.ToInt32(dt.Rows[i]["Quantity"]);
                    carts.TotalPrice = Convert.ToInt32(dt.Rows[i]["TotalPrice"]);
                   
                    listCart.Add(carts);

                }
                if (listCart.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Cart details fetched";
                    response.listCart = listCart;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "Cart details are not available";
                    response.listCart = null;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Cart details are not available";
                response.listCart = null;
            }
            return response;
        }

        public Response UpdateOrderStatus(Orders order, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_UpdateOrderStatus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OrderNumber", order.OrderNumber);
            cmd.Parameters.AddWithValue("@OrderStatus", order.OrderStatus);

            cmd.Parameters.Add("@Output_Message", SqlDbType.VarChar, 100);
            cmd.Parameters["@Output_Message"].Direction = ParameterDirection.Output;


            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = Convert.ToString(cmd.Parameters["@Output_Message"].Value);
            }
            return response;
        }


        public Response ProductList( SqlConnection connection)
        {
            List<Products> listproducts = new List<Products>();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Products;", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response response = new Response();
            if(dt.Rows.Count>0)
            {
                for (int i=0;i<dt.Rows.Count;i++)
                {
                    Products product = new Products();
                    product.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    product.Name = Convert.ToString(dt.Rows[i]["Name"]);
                    product.Image = Convert.ToString(dt.Rows[i]["Image"]);
                    product.ActualPrice = Convert.ToDecimal(dt.Rows[i]["ActualPrice"]);
                    product.DiscountedPrice = Convert.ToDecimal(dt.Rows[i]["DiscountedPrice"]);
                    listproducts.Add(product);
                }
                if(listproducts.Count>0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Data Found";
                    response.listProducts = listproducts;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = " No Data Found";
                    response.listProducts = null;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = " No Data Found";
                response.listProducts = null;
            }
            return response;
        }

      
        public Response AddProduct(Products products,SqlConnection connection)
        {
            Response response = new Response();
            if(products.ID>0)
            {
             
                SqlCommand cmd = new SqlCommand("Insert into Carts(ProductID)VALUES('"+products.ID+"')",connection);

                connection.Open();
                int i = cmd.ExecuteNonQuery();
                connection.Close();
                if(i>0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "item added";
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = " item not added";
                }
            }
            return response;
        }


        public Response RemoveProduct(Products products, SqlConnection connection)
        {
            Response response = new Response();
            if (products.ID > 0)
            {

                SqlCommand cmd = new SqlCommand("DELETE FROM Carts WHERE ProductID = @ProductID AND ID=@ID", connection);
              


                connection.Open();
                int i = cmd.ExecuteNonQuery();
                connection.Close();
                if (i > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "item has been removed ";
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = " something went wrong";
                }
            }
            return response;
        }


        public Response ProductListCarts(SqlConnection connection)
        {
            List<Products> listproducts = new List<Products>();
            SqlDataAdapter da = new SqlDataAdapter("Select P.ID,P.Name,P.Image,P.ActualPrice,P.DiscountedPrice FROM Carts C INNER JOIN Products P\r\nON C.ProductID=P.ID;\r\n", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Products product = new Products();
                    product.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    product.Name = Convert.ToString(dt.Rows[i]["Name"]);
                    product.Image = Convert.ToString(dt.Rows[i]["Image"]);
                    product.ActualPrice = Convert.ToDecimal(dt.Rows[i]["ActualPrice"]);
                    product.DiscountedPrice = Convert.ToDecimal(dt.Rows[i]["DiscountedPrice"]);
                    listproducts.Add(product);
                }
                if (listproducts.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Data Found";
                    response.listProducts = listproducts;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = " No Data Found";
                    response.listProducts = null;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = " No Data Found";
                response.listProducts = null;
            }
            return response;
        }


    }

}
