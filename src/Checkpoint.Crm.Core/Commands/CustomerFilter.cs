using System;
using Checkpoint.Crm.Core.Models.Base;

namespace Checkpoint.Crm.Core.Commands
{
    /// <summary>
    ///     Фильтр для списка гостей
    /// </summary>
    public class CustomerFilter : FilterBase
    {
        /// <summary>
        /// Емейл
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; }
        
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? BirthDate { get; set; }
        
        /// <summary>
        /// Внешний идентификатор
        /// </summary>
        public string ExternalId { get; set; }        
    }
}