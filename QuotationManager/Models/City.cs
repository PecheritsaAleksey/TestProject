using System.ComponentModel.DataAnnotations;

namespace QuotationManager.Models
{
    /// <summary>
    /// Город
    /// </summary>
    public class City
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }

        /// <summary>
        /// Название города
        /// </summary>
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string Name { get; set; }

        /// <summary>
        /// Уровень значимости
        /// </summary>
        [Required(ErrorMessage = "Significance level is required.")]
        public int SignificanceLevel { get; set; }
    }
}
