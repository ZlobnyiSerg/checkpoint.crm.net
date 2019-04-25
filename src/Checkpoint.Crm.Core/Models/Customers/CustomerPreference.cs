using Checkpoint.Crm.Core.Models.Base;
using Checkpoint.Crm.Core.Models.Dictionaries;

namespace Checkpoint.Crm.Core.Models.Customers
{
    /// <summary>
    /// Предпочтение клиента
    /// </summary>
    public class CustomerPreference : Model
    {
        /// <summary>
        /// Категория предпочтения
        /// </summary>
        public PreferenceCategory Category { get; set; }
        
        /// <summary>
        /// Название предпочтения
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Значение предпочтения
        /// </summary>
        public string Value { get; set; }
    }
}