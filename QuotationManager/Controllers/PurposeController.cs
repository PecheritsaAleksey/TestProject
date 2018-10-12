using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using QuotationManager.Models;
using QuotationManager.Repository;

namespace QuotationManager.Controllers
{
    [Route("api/purposes")]
    public class PurposeController : Controller
    {
        private readonly IPurposeRepository _purposeRepository;

        public PurposeController(IPurposeRepository purposeRepository)
        {
            _purposeRepository = purposeRepository;
        }

        /// <summary>
        /// Получить список всех целей
        /// </summary>
        [HttpGet]
        public IEnumerable<Purpose> Get()
        {
            return _purposeRepository.GetAll();
        }
    }
}