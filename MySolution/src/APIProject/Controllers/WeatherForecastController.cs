using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text;

namespace APIProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static List<Student> students = new List<Student>()
        {
             new Student {FirstName="Tom", LastName=".S", ID=1, 
                          Marks= new List<int>() {97, 92, 81, 60}},
             new Student {FirstName="Jerry", LastName=".M", ID=2, 
                          Marks= new List<int>() {75, 84, 91, 39}},
             new Student {FirstName="Bob", LastName=".P", ID=3, 
                          Marks= new List<int>() {88, 94, 65, 91}},
             new Student {FirstName="Mark", LastName=".G", ID=4, 
                          Marks= new List<int>() {97, 89, 85, 82}},
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("weather")]
        public IEnumerable<WeatherForecast> Get2()
        {
            var rng = new Random();
            return Enumerable.Range(1, 4).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

         [HttpGet("{location}")]
        public IEnumerable<WeatherForecast> Get3(string location)
        {
            var rng = new Random();
            return Enumerable.Range(1, 4).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)],
                Location = location
            })
            .ToArray();
        }

        [HttpPost]
        public object Post([FromBody] WeatherForecast weather)
        {
            WeatherForecast WF = new WeatherForecast();
            WF.Date = weather.Date;
            WF.TemperatureC = weather.TemperatureC;
            WF.Summary = weather.Summary;
            WF.Location = weather.Location;
            return WF; 
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Student student)
        {
            var entity = students.FirstOrDefault(s => s.ID == id);
            entity.FirstName = student.FirstName;
            entity.LastName = student.LastName;
            entity.Marks= new List<int>() {97, 97, 97, 97};
        }

        [HttpGet("student")]
        public IEnumerable<Student> GetStudents()
        {
            return students;
        }
    }
}
