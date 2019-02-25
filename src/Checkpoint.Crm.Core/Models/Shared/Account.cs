using Checkpoint.Crm.Core.Models.Base;

namespace Checkpoint.Crm.Core.Models.Shared
{
    public class Account : Model
    {
        /// <summary>
        /// Баланс
        /// </summary>
        public decimal Balance { get; set; }            
        
        /// <summary>
        /// Дебет баланса
        /// </summary>
        public decimal BalanceDebit { get; set; }
        
        /// <summary>
        /// Кредит баланса
        /// </summary>
        public decimal BalanceCredit { get; set; }
        
        /// <summary>
        /// Сумма баллов с ограниченным сроком действия
        /// </summary>
        public decimal BalanceExpirable { get; set; }  
        
        /// <summary>
        /// Сумма уровневых баллов
        /// </summary>
        public decimal BalanceLevel { get; set; }            
    }
}