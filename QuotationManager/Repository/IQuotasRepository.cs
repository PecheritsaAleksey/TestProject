using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using QuotationManager.Models;

namespace QuotationManager.Repository
{
    public interface IQuotasRepository
    {
        /// <summary>
        /// Получить список всех квот
        /// </summary>
        /// <returns></returns>
        IEnumerable<Quota> GetAll();

        /// <summary>
        /// Получить квоту по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор квоты</param>
        /// <returns></returns>
        Quota GetQuotaById(int id);

        /// <summary>
        /// Добавить новую квоту
        /// </summary>
        /// <param name="quota">Объект квоты</param>
        /// <returns></returns>
        void AddNewQuota(Quota quota);

        /// <summary>
        /// Обновить квоту
        /// </summary>
        /// <param name="quota">Объект квоты</param>
        /// <returns></returns>
        void UpdateQuota(Quota quota);

        /// <summary>
        /// Удалить квоту
        /// </summary>
        /// <param name="quota">Объект квоты</param>
        /// <returns></returns>
        void Remove(Quota quota);
    }
}
