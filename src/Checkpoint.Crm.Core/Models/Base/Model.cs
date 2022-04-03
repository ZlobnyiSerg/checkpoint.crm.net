using System;

namespace Checkpoint.Crm.Core.Models.Base
{
    public class Model
    {
        /// <summary>
        ///     Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Внутреннаяя дата создания в системе лояльности. Для указания внешней даты используйте <see cref="ExtDateCreated"/>.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        ///     Внутреннаяя дата изменения объекта в системе лояльности. Для указания внешней даты используйте <see cref="ExtDateModified"/>.
        /// </summary>
        public DateTime? DateModified { get; set; }               
    }

    public class ExternallyIdentifiedModel : Model
    {
        /// <summary>
        ///     Внешний идентификатор
        /// </summary>
        public string? ExternalId { get; set; }
        
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