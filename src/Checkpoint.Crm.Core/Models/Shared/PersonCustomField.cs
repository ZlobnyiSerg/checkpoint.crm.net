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
        public int PersonId { get; private set; }

        public PersonCustomField(int personId, string name, string value) : base(name, value)
        {
            PersonId = personId;
        }
    }
}