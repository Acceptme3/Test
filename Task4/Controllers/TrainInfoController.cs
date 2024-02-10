using Microsoft.AspNetCore.Mvc;

namespace Task4.Controllers
{
    [ApiController]
    [Route("api/train")]
    public class TrainInfoController : Controller
    {
        private readonly ILogger<TrainInfoController> _logger;

        public TrainInfoController(ILogger<TrainInfoController> logger)
        {
            _logger = logger;
        }

        [HttpGet("trainNumber")]
        public ActionResult<Train> GetTrainInfo(int num)
        {
            try
            {
                Train train = TrainSchedule.trains.FirstOrDefault(train => train.Number == num);
                if (train.TownTo == null)
                {
                    return BadRequest("Поезда с таким номером нет в базе данных");
                }
                return Ok(train);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message);
                return BadRequest("Некорректный параметр");
            }
        }

        [HttpGet("sort")]
        public ActionResult<Train[]> GetSortSchedule()
        {
            try
            {
                var sortingArray = TrainSchedule.trains.OrderBy(train => train.TownTo).ThenBy(train => train.DepartureTime);
                return Ok(sortingArray);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Произошла ошибка при работе с данными");
            }
        }

        [HttpGet("select")]
        public ActionResult<Train[]> GetSelectionSchedule()
        {
            try 
            {
                var currTime = new TimeOnly(DateTime.Now.TimeOfDay.Hours,DateTime.Now.TimeOfDay.Minutes);
                var result = TrainSchedule.trains.Where(tr => tr.DepartureTime > currTime);
                if(result.Count()==0)
                {
                    return Ok("На сегодня больше нет отправлений");
                }
                return Ok(result);
            }
            catch(Exception ex) 
            {
                _logger.LogError(ex.Message);
                return BadRequest("Некорректный запрос");
            }
            
        }
    }
}
