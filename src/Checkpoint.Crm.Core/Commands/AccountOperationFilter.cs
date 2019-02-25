using Checkpoint.Crm.Core.Models.Base;

namespace Checkpoint.Crm.Core.Commands
{
    /// <summary>
    /// Фильтр по операциям бонусного счёта
    /// </summary>
    public class AccountOperationFilter : FilterBase
    {
        /// <summary>
        /// Код точки продаж
        /// </summary>
        public string PointOfSaleCode { get; set; }               
        
        /// <summary>
        /// Внешний идентификатор операции по счёту
        /// </summary>
        public string ExternalId { get; set; }
        
        /// <summary>
        /// Идентификатор аккаунта (счёта) бонусного счёта
        /// </summary>
        public int? AccountId { get; set; }
    }
}