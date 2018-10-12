using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuotationManager.Models;

namespace QuotationManager.Repository
{
    public class ContributionRepository : IContributionReposirory
    {
        private readonly ApplicationContext _context;

        public ContributionRepository(ApplicationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получить список всех взносов для города
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Contribution> GetAllByCity(int cityId)
        {
            return _context.Contributions.Where(x => x.CityId == cityId);
        }
    }
}
