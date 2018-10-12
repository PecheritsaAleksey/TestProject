using System.Collections.Generic;
using QuotationManager.Models;

namespace QuotationManager.Repository
{
    public interface IContributionReposirory
    {
        /// <summary>
        /// Получить список всех взносов для города
        /// </summary>
        /// <returns></returns>
        IEnumerable<Contribution> GetAllByCity(int cityId);
    }
}
