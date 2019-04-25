using Checkpoint.Crm.Core.Models.Base;

namespace Checkpoint.Crm.Core.Models.Dictionaries
{
    /// <summary>
    /// Категория предпочтений клиента
    /// </summary>
    public class PreferenceCategory : Model
    {
        /// <summary>
        /// Название категории предпочтений
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Описание категории предпочтений
        /// </summary>
        public string Description { get; set; }
    }
}