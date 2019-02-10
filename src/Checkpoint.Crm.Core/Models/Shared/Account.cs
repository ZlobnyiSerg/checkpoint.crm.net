using Checkpoint.Crm.Core.Models.Base;

namespace Checkpoint.Crm.Core.Models.Shared
{
    public class Account : Model
    {
        /// <summary>
        /// Баланс
        /// </summary>
        public decimal Balance { get; set; }            
    }
}