using Checkpoint.Crm.Core.Models.Base;

namespace Checkpoint.Crm.Core.Models
{
    /// <summary>
    ///     Промо-предложение, применимое к визитам гостя
    /// </summary>
    public class PromoOffer : Model
    {
        /// <summary>
        ///     Уникальный код промо-предложения. Служит для идентификации предложения во внешеней системе
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        ///     Наименование промо-предложения (например, "3-й массаж бесплатно", "скидка на проживание 7%", "скидка в понедельник 10%")
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Расширенное описание промо-предложения и описание условий его применения
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Признак того, что промо-предложение можно применить к визиту/визитам гостя. Если оно недоступно, см. <see cref="UnavailabilityReason"/>
        /// </summary>
        public bool IsAvailable { get; set; }

        /// <summary>
        ///     Причина недоступности применения промо-предложения, например: предложение уже было применено максимально доступное количество раз
        /// </summary>
        public string UnavailabilityReason { get; set; }  
        
        /// <summary>
        ///     Признак, указывающий на то, что данное промо-предложение должно применяться автоматически
        /// </summary>
        public bool AutoApply { get; set; }
        
        /// <summary>
        ///     Признак, что применение промо-предложения может отслеживаться в системе лояльности.
        ///     Не все предложения позволяют это делать, например предложения, ограничивающие лимит оплаты баллами. 
        /// </summary>
        public bool CanBeTracked { get; set; }
    }
}