using Microsoft.AspNetCore.Mvc;

namespace Task10_Web_API.Controllers
{
    [ApiController]
    [Route("api/getCalc")]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult<int> Index(int countMonth, int depo, int percent)
        {
            try 
            {
                int result = depo;
                for (int i = 1; i <= countMonth; i++)
                {
                    int per = (result / 100) * percent;
                    result += per;
                }
                return result;
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
