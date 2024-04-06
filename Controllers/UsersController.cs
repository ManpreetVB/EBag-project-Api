using EBags.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace EBags.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        [Route("Registration")]
        public ActionResult Registration(Users users)
        {
            BAL bal = new BAL();
            
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCS").ToString());
            Response response = bal.Registration(users, connection);
            if (response.StatusCode == 200)
                return Ok(new {Users=users, Response = response });
            else
                return Ok(new { Response = response });

        }
        [HttpPost]
        [Route("Login")]
        public ActionResult Login(Users users)
        {
            BAL bal = new BAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCS").ToString());
            Response response = bal.Login(users, connection);

            if (response.StatusCode == 200)
                return Ok(new {Users = users, Response = response });
            else
                return Ok(new { Response = response });
        }
        [HttpPost]
        [Route("ViewUser")]
        public ActionResult ViewUser(Users users)
        {
            BAL bal = new BAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCS").ToString());
            Response response = bal.ViewUser(users, connection);
            if (response.StatusCode == 200)
                return Ok(new { Users = users, Response = response });
            else
                return Ok(new { Response = response });
        }
        [HttpPut]
        [Route(" UpdateUserProfile")]
        public ActionResult UpdateUserProfile(Users users)
        {
            BAL bal = new BAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DBCS").ToString());
            Response response = bal.UpdateUserProfile(users, connection);

            if (response.StatusCode == 200)
                return Ok(new { Users = users, Response = response });
            else
                return Ok(new { Response = response });
        }
    }
}
