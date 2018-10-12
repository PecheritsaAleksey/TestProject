using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuotationManager.Models
{
    /// <summary>
    /// Квота
    /// </summary>
    public class Quota
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор города
        /// </summary>
        [Required(ErrorMessage = "CityId is required.")]
        public int CityId { get; set; }

        /// <summary>
        /// Идентификатор цели
        /// </summary>
        [Required(ErrorMessage = "PurposeId is required.")]
        public int PurposeId { get; set; }

        /// <summary>
        /// Сумма рефинансирования
        /// </summary>
        [Required(ErrorMessage = "Refinancing amount is required.")]
        [Range(0, 5000000)]
        public int RefinancingAmount { get; set; }

        /// <summary>
        /// Дата создания квоты
        /// </summary>
        [Required(ErrorMessage = "Creation date is required.")]
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Дата редактирования квоты
        /// </summary>
        public DateTime EditDate { get; set; }

        /// <summary>
        /// Комментарий
        /// </summary>
        [StringLength(1024, ErrorMessage = "Comment cannot be longer than 1024 characters.")]
        public string Comment { get; set; }

        /// <summary>
        /// Процентная ставка
        /// </summary>
        [Required(ErrorMessage = "Interest rate is required.")]
        public double InterestRate { get; set; }

        /// <summary>
        /// Список дополнительных взносов за предоставление кредитования
        /// </summary>
        public List<QuotaContribution> QuotaContributions { get; set; }

        /// <summary>
        /// Город
        /// </summary>
        public City City { get; set; }

        /// <summary>
        /// Цель рефинансирования
        /// </summary>
        public Purpose Purpose { get; set; }
    }
}
