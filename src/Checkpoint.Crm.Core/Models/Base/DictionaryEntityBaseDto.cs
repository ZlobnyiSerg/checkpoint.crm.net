namespace Checkpoint.Crm.Core.Models.Base
{
    /// <summary>
    ///     Словарная сущность (расширяет базовую полями код и наименование)
    /// </summary>
    public class DictionaryEntityBaseModel : Model
    {
        /// <summary>
        ///     Код
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        ///     Наименование
        /// </summary>
        public string Name { get; set; }

        public DictionaryEntityBaseModel()
        {
        }

        public DictionaryEntityBaseModel(string code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}