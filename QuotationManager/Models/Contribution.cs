using System.ComponentModel.DataAnnotations;

namespace QuotationManager.Models
{
    /// <summary>
    /// Взнос
    /// </summary>
    public class Contribution
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }

        /// <summary>
        /// Имя взноса
        /// </summary>
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string Name { get; set; }

        /// <summary>
        /// Базовая сумма
        /// </summary>
        [Required(ErrorMessage = "Base sum is required.")]
        [Range(1, 10)]
        public int BaseSum { get; set; }

        /// <summary>
        /// Идентификатор города
        /// </summary>
        [Required(ErrorMessage = "CityId is required.")]
        public int CityId { get; set; }

        /// <summary>
        /// Город
        /// </summary>
        public City City { get; set; }
    }
}
