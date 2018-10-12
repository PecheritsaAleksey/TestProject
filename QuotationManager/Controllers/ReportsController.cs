using System.Text;
using Microsoft.AspNetCore.Mvc;
using QuotationManager.Repository;

namespace QuotationManager.Controllers
{
    [Route("api/report")]
    public class ReportsController : Controller
    {
        private readonly IQuotasRepository _quotasRepository;

        public ReportsController(IQuotasRepository quotasRepository)
        {
            _quotasRepository = quotasRepository;
        }

        /// <summary>
        /// Получить список всех городов
        /// </summary>
        [HttpGet("{id}")]
        public async void Get(int id)
        {
            var quota = _quotasRepository.GetQuotaById(id);

            var template = $@" 
                <h2>Квота {quota.Id} </h2>
                <div>
                <p><b>Город:</b> {quota.City.Name} </p>
                <p><b>Цель:</b> {quota.Purpose.Name}</p>
                <p><b>Сумма рефинансирования:</b> {quota.RefinancingAmount}</p>
                <p><b>Комментарий:</b> {quota.Comment}</p>
                <p><b>Процентная ставка:</b> {quota.InterestRate}</p>
                <p>Взносы:</p>
                <ul>";
            foreach (var contribution in quota.QuotaContributions)
            {
                template += $@"<li> {contribution} </li>";
            }
            template += "</ul> </div>";

            var fileName = "report.html";

            byte[] fileBytes = Encoding.ASCII.GetBytes(template);

            Response.Headers.Add("content-disposition", "attachment; filename=report.html");

            await Response.Body.WriteAsync(fileBytes, 0, fileBytes.Length);
        }
    }
}