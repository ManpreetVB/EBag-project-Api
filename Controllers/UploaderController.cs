using EBags.Models;
using EBagsDB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EBagsDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploaderController : ControllerBase
    {
        [HttpPost]
        [Route("UploadFile")]
        public Response UploadFile([FromForm] FileModel fileModel)
        {
            Response response = new Response();
            try
            {
                string path = Path.Combine(@"C:\Users\kaurk\Learning\HealthCare\EBags\images", fileModel.FileName);
                using (Stream stream=new FileStream (path, FileMode.Create))
                {
                    fileModel.file.CopyTo(stream);
                }
                response.StatusCode = 200;
                response.ErrorMessage = "image created successfully";
            }
           catch(Exception ex)
            {
                response.StatusCode = 100;
                response.ErrorMessage = "some error occured" + ex.Message;
            }
            
            return response;
        }
    }
}
