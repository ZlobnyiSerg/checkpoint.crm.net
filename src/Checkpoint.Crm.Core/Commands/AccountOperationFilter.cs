using Checkpoint.Crm.Core.Models.Base;

namespace Checkpoint.Crm.Core.Commands
{
    /// <summary>
    /// Фильтр по операциям бонусного счёта
    /// </summary>
    public class AccountOperationFilter : FilterBase
    {
        /// <summary>
        /// Идентификатор аккаунта (счёта) бонусного счёта
        /// </summary>
        public int? AccountId { get; set; }
    }
}