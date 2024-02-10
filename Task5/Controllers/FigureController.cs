using Microsoft.AspNetCore.Mvc;
using Task5.Models;
using Task5.Models.Abstract;

namespace Task5.Controllers
{
    [ApiController]
    [Route("api/figure")]
    public class FigureController : Controller
    {
        private readonly ILogger<FigureController> _logger;
        private readonly IFigureCreator _creator;

        public FigureController(ILogger<FigureController> logger, IFigureCreator creator)
        {
            _logger = logger;
            _creator = creator;
        }

        [HttpGet("getInfo")]
        public IActionResult GetFigureInfo(int countFigure, FigureType figureType)
        {
            List<Figure> result = new List<Figure>();

            try
            {
                while (countFigure != 0)
                {
                    int[] data = FigureSchedule.GetValidData(figureType);
                    var figure = _creator.Create(figureType, data);
                    figure.GetInfo();
                    result.Add(figure);
                    countFigure--;
                }

                var json = JsonConvert.SerializeObject(result);
                return Content(json, "application/json");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Вы ввели некорректные параметры.");
            }
        }
    }


}
