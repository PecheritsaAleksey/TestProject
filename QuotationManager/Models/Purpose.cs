using System.ComponentModel.DataAnnotations;

namespace QuotationManager.Models
{
    /// <summary>
    /// Цель рефинансирования
    /// </summary>
    public class Purpose
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }

        /// <summary>
        /// Название цели
        /// </summary>
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
    }
}
