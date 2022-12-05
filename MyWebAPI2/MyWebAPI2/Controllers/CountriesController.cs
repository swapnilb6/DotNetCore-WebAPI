using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        [BindProperty]
        public CountryModel country { get; set; }

        [HttpPost]
        [Route("Country")]

        public IActionResult AddCountries()
        {
            return Ok($"Name = {this.country.Name},Population =  {this.country.Population}");
        }
    }
}
