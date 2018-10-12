using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuotationManager.Models;
using QuotationManager.Repository;

namespace QuotationManager.Controllers
{
    [Route("api/quotas")]
    public class QuotasController : Controller
    {
        private readonly IQuotasRepository _quotasRepository;
        private readonly ICityRepository _cityReposirory;
        private readonly IContributionReposirory _contributionReposirory;

        public QuotasController(IQuotasRepository quotasRepository, ICityRepository cityReposirory, IContributionReposirory contributionReposirory)
        {
            _quotasRepository = quotasRepository;
            _cityReposirory = cityReposirory;
            _contributionReposirory = contributionReposirory;
        }

        /// <summary>
        /// Получить список всех квот
        /// </summary>
        [HttpGet]
        public IEnumerable<Quota> GetQuotas()
        {
            return _quotasRepository.GetAll();
        }

        /// <summary>
        /// Получить квоту по идентификатору
        /// </summary>
        [HttpGet("{id}")]
        public Quota Get(int id)
        {
            return _quotasRepository.GetQuotaById(id);
        }

        /// <summary>
        /// Добавить новую квоту
        /// </summary>
        [HttpPost]
        public IActionResult Post([FromBody]Quota quota)
        {
            if (ModelState.IsValid)
            {   
                CalculateQuota(quota);
                quota.CreationDate = DateTime.Now;
                _quotasRepository.AddNewQuota(quota);
                return Ok(quota);
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Обновить квоту
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Quota quota)
        {
            if (ModelState.IsValid)
            {
                CalculateQuota(quota);
                _quotasRepository.UpdateQuota(quota);
                return Ok(quota);
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Удалить квоту
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var quota = _quotasRepository.GetQuotaById(id);

            if (quota != null)
            {
                _quotasRepository.Remove(quota);
                return Ok(quota);
            }
            return BadRequest(ModelState);
        }

        private void CalculateQuota(Quota quota)
        {
            double interestRate = 0;
            var citySignificanceLevel = _cityReposirory.GetCityById(quota.CityId).SignificanceLevel;

            //Расчет процентной ставки
            switch (quota.PurposeId)
            {
                case 1:
                    interestRate = (citySignificanceLevel + 10) * 1;
                    break;
                case 2:
                    interestRate = (citySignificanceLevel + 10) * 1.2;
                    break;
                case 3:
                    interestRate = (citySignificanceLevel + 10) * 1.3;
                    break;
                default:
                    interestRate = 0;
                    break;
            }

            quota.InterestRate = interestRate;

            quota.EditDate = DateTime.Now;

            //Заполнение платежей
            var quotaContributions = new List<QuotaContribution>();
            var cityContributions = _contributionReposirory.GetAllByCity(quota.CityId);
            foreach (var cityContribution in cityContributions)
            {
                quotaContributions.Add(new QuotaContribution { Value = quota.RefinancingAmount * citySignificanceLevel * cityContribution.BaseSum * 0.0001 });
            }
            quota.QuotaContributions = quotaContributions;
        }
    }
}