using System;
using Checkpoint.Crm.Core.Models.Base;

namespace Checkpoint.Crm.Core.Commands
{
    /// <summary>
    ///     Фильтр для списка гостей
    /// </summary>
    public class CustomerFilter : FilterBase
    {
        public string Email { get; set; }
        
        public string Phone { get; set; }
        
        public string ExternalId { get; set; }       
        
        /// <summary>
        /// Поисковой запрос (по фио, емейлу и т.п.)
        /// </summary>
        public string Query { get; set; }
    }
}