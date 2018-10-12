using System.Collections.Generic;
using QuotationManager.Models;

namespace QuotationManager.Repository
{
    public interface ICityRepository
    {
        /// <summary>
        /// Получить список всех взносов по городу
        /// </summary>
        /// <returns></returns>
        IEnumerable<City> GetAll();

        /// <summary>
        /// Получить город по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор квоты</param>
        /// <returns></returns>
        City GetCityById(int id);
    }
}
