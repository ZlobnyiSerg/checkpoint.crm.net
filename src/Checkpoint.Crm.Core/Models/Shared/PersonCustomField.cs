namespace Checkpoint.Crm.Core.Models.Shared
{
    /// <summary>
    ///     Дополнительное поле на профиле гостя
    /// </summary>
    public class PersonCustomField : ExtraField
    {
        /// <summary>
        ///     Идентификатор профиля
        /// </summary>
        public string PersonId { get; set; }

        public PersonCustomField(string personId, string name, string value) : base(name, value)
        {
            PersonId = personId;
        }
    }
}