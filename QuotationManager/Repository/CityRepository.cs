using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuotationManager.Models;

namespace QuotationManager.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationContext _context;

        public CityRepository(ApplicationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получить список всех городов
        /// </summary>
        public IEnumerable<City> GetAll()
        {
            return _context.Cities.ToList();
        }

        /// <summary>
        /// Получить город по идентификатору
        /// </summary>
        public City GetCityById(int id)
        {
            return _context.Cities.FirstOrDefault(x => x.Id == id);
        }
    }
}
