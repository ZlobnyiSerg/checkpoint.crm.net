using System.ComponentModel.DataAnnotations;
using Checkpoint.Crm.Core.Models.Base;

namespace Checkpoint.Crm.Core.Models.Shared
{
    /// <summary>
    ///     Дополнительное поле
    /// </summary>
    public class ExtraField : Model
    {
        /// <summary>
        ///     Код поля
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        ///     Наименование
        /// </summary>
        public string Value { get; set; }

        public ExtraField()
        {
        }

        public ExtraField(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}