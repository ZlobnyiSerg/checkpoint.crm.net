using Checkpoint.Crm.Core.Models.Base;

namespace Checkpoint.Crm.Core.Models.Cards
{
    /// <summary>
    /// Уровень гостя в системе лояльности
    /// </summary>
    public class Tier : DictionaryEntityBaseModel
    {        
        /// <summary>
        /// Минимальная сумма уровневых баллов, необходимых для достижения данного уровня
        /// </summary>
        public int MinPoints { get; set; }
        /// <summary>
        /// Общее описание уровня
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Список привилегий и возможностей уровня
        /// </summary>
        public string[] Features { get; set; }
    }
}
