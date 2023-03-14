using Checkpoint.Crm.Core.Models.Base;

namespace Checkpoint.Crm.Core.Commands
{
    /// <summary>
    ///     Фильтр карт лояльности
    /// </summary>
    public class CardFilter : FilterBase
    {
        /// <summary>
        ///     Идентификатор карты
        /// </summary>
        public string CardNo { get; set; }

        /// <summary>
        ///     Признак активации карты
        /// </summary>
        public bool? IsActive { get; set; }
        
        /// <summary>
        ///     Идентификатор клиента, к которому привязана карта
        /// </summary>
        public string? CustomerId { get; set; }
    }
}
