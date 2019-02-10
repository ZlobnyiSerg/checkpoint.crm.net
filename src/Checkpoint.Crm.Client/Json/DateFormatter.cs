using Newtonsoft.Json.Converters;

namespace Checkpoint.Crm.Client.Json
{
    public class DateFormatter : IsoDateTimeConverter
    {
        public DateFormatter()
        {
            DateTimeFormat = "yyyy-MM-dd";
        }
    }
}