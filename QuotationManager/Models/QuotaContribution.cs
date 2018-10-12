
using System.ComponentModel.DataAnnotations;

namespace QuotationManager.Models
{
    /// <summary>
    /// Взнос, относящийся к конкретной квоте
    /// </summary>
    public class QuotaContribution
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор квоты
        /// </summary>
        [Required(ErrorMessage = "QuotaId is required.")]
        public int QuotaId { get; set; }

        /// <summary>
        /// Сумма взноса
        /// </summary>
        [Required(ErrorMessage = "Value is required.")]
        public double Value { get; set; }
    }
}
