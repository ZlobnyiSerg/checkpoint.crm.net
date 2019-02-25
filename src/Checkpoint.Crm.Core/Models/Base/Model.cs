using System;

namespace Checkpoint.Crm.Core.Models.Base
{
    public class Model
    {
        /// <summary>
        ///     Идентификатор
        /// </summary>
        public int Id { get; }

        /// <summary>
        ///     Внутреннаяя дата создания в системе лояльности. Для указания внешней даты используйте <see cref="ExtDateCreated"/>.
        /// </summary>
        public DateTime DateCreated { get; }

        /// <summary>
        ///     Внутреннаяя дата изменения объекта в системе лояльности. Для указания внешней даты используйте <see cref="ExtDateModified"/>.
        /// </summary>
        public DateTime? DateModified { get; }               
    }

    public class ExternallyIdentifiedModel : Model
    {
        /// <summary>
        ///     Внешний идентификатор
        /// </summary>
        public string ExternalId { get; set; }
        
        /// <summary>
        ///     Дата создания
        /// </summary>
        public DateTime? ExtDateCreated { get; set; }

        /// <summary>
        ///     Дата изменения (может быть пустой, если объект не изменялся)
        /// </summary>
        public DateTime? ExtDateModified { get; set; }
    }
}