using EBags.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace EBags.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BagController : ControllerBase

    {
        private readonly IConfiguration _configuration;
        public BagController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        [Route("AddToCart")]
        public ActionResult AddToCart(Cart cart)
        {
            BAL bal = new BAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCS").ToString());
            Response response = bal.AddToCart(cart, connection);

            if (response.StatusCode == 200)
                return Ok(new { Cart = cart, Response = response });
            else
                return Ok(new { Response = response });

        }
        [HttpPost]
        [Route("RemoveToCart")]
        public ActionResult RemoveToCart(Cart cart)
        {
            BAL bal = new BAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCS").ToString());
            Response response = bal.RemoveToCart(cart, connection);
            if (response.StatusCode == 200)
                return Ok(new { Cart = cart, Response = response });
            else
                return Ok(new { Response = response });


        }
        [HttpPost]
        [Route("PlaceOrder")]
        public ActionResult PlaceOrder(Users users)
        {
            BAL bal = new BAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCS").ToString());
            Response response = bal.PlaceOrder(users, connection);

            if (response.StatusCode == 200)
                return Ok(new { Users = users, Response = response });
            else
                return Ok(new { Response = response });
        }
        [HttpPost]
        [Route("OrderList")]
        public ActionResult OrderList(Users users)
        {
            BAL bal = new BAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCS").ToString());
            Response response = bal.OrderList(users, connection);

            if (response.StatusCode == 200)
                return Ok(new { Users = users, Response = response });
            else
                return Ok(new { Response = response });
        }
    }
    
    
}
