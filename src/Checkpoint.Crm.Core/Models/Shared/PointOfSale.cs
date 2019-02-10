using Checkpoint.Crm.Core.Models.Base;

namespace Checkpoint.Crm.Core.Models.Shared
{
    public class PointOfSale : DictionaryEntityBaseModel
    {
        public string CurrencyCode { get; set; }

        public PointOfSale()
        {
        }

        public PointOfSale(string code, string name) : base(code, name)
        {
        }
    }
}
