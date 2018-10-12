using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using QuotationManager.Models;
using QuotationManager.Repository;

namespace QuotationManager.Controllers
{
    [Route("api/cities")]
    public class CitiesController : Controller
    {
        private readonly ICityRepository _cityReposirory;

        public CitiesController(ICityRepository cityReposirory)
        {
            _cityReposirory = cityReposirory;
        }

        /// <summary>
        /// Получить список всех городов
        /// </summary>
        [HttpGet]
        public IEnumerable<City> Get()
        {
            return _cityReposirory.GetAll();
        }
    }
}