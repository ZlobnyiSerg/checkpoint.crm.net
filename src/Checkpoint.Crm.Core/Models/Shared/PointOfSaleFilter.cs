using Checkpoint.Crm.Core.Models.Base;

namespace Checkpoint.Crm.Core.Models.Shared
{
    public class PointOfSaleFilter : FilterBase
    {
        /// <summary>
        /// Код точки продаж
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Название точки продаж
        /// </summary>
        public string Name { get; set; }
    }
}