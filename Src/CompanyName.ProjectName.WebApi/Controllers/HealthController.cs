using Microsoft.AspNetCore.Mvc;

namespace CompanyName.ProjectName.WebApi.Controllers
{
    [Route("ns-ms-name/api/[controller]")]
    [ApiController]
    public class Health : ControllerBase
    {
        [HttpGet("GetHealthCheck")]
        public string Get()
        {
            return "i'm helthy";
        }

        public StatusCodeResult DefaultResponse()
        {
            return StatusCode(505);
        }
        
    }
}