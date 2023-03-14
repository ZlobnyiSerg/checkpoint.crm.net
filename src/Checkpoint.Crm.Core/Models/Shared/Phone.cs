using Checkpoint.Crm.Core.Models.Base;

namespace Checkpoint.Crm.Core.Models.Shared
{
    /// <summary>
    ///     Телефонный номер
    /// </summary>
    public class Phone : Model
    {
        /// <summary>
        ///     Идентификатор гостя
        /// </summary>
        public string PersonId { get; set; }

        /// <summary>
        ///     Тип контактного телефона (домашний, рабочий и т.п.)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///     Номер телефона
        /// </summary>
        public string Number { get; set; }
    }
}