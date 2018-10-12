using System.Collections.Generic;
using QuotationManager.Models;

namespace QuotationManager.Repository
{
    public interface IPurposeRepository
    {
        /// <summary>
        /// Получить список всех целей
        /// </summary>
        /// <returns></returns>
        IEnumerable<Purpose> GetAll();
    }
}
