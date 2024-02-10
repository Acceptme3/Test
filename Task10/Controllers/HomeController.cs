using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Task10.Configurations;
using Task10.Domain;
using Task10.Domain.Entities;
using Task10.Models;
using static System.Net.WebRequestMethods;

namespace Task10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _appDbContext;
        private readonly IEntityRepository<Investment> _repository;
        private readonly HttpClient _httpClient;
        public Investment investment1 { get; set; } = new Investment();

        public HomeController(ILogger<HomeController> logger, AppDbContext appDbContext, IEntityRepository<Investment> repository, HttpClient httpClient)
        {
            _logger = logger;
            _appDbContext = appDbContext;
            _repository = repository;
            _httpClient = httpClient;
        }

        [HttpPost]
        public async Task<IActionResult> Index(Investment investment)
        {
            string url = $"https://localhost:7187/api/getCalc?countMonth={investment.CountMonth}&depo={investment.Deposit}&percent={Config.PercentageValue}";
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Investment inv = investment;
                    inv.TotalDeposit = int.Parse(responseBody);
                    await _repository.AddAsync(inv);
                    return RedirectToAction("Privacy", inv);
                }
                else
                {
                    return StatusCode((int)response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
            
        }

        public IActionResult Index()
        {
           
            return View();
        }

        public IActionResult Privacy(Investment investment)
        {
            var example = investment;
            if (example == null)
            {
                example = new Investment()
                {
                    Deposit = 0,
                    CountMonth = 0
                };
            }
            return View(example);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
