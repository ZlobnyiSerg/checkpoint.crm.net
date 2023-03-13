using Checkpoint.Crm.Core.Models.Base;

namespace Checkpoint.Crm.Core.Commands
{
    /// <summary>
    ///     Фильтр для списка визитов
    /// </summary>
    public class OrderFilter : FilterBase
    {
        /// <summary>
        ///     Идентификатор гостя
        /// </summary>
        public string? CustomerId { get; set; }
    
        /// <summary>
        /// Идентификатор родительского заказа
        /// </summary>
        public string? ParentId { get; set; }
    }
}
