using System.Collections.Generic;
using System.Linq;
using QuotationManager.Models;

namespace QuotationManager.Repository
{
    public class PurposeRepository : IPurposeRepository
    {
        private readonly ApplicationContext _context;

        public PurposeRepository(ApplicationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получить список всех целей
        /// </summary>
        public IEnumerable<Purpose> GetAll()
        {
            return _context.Purposes.ToList();
        }
    }
}
