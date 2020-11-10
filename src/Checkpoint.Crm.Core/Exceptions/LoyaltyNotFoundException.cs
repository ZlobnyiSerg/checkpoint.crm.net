using System;

namespace Checkpoint.Crm.Core.Exceptions
{
    [Serializable]
    public class LoyaltyNotFoundException : LoyaltyException
    {
        public LoyaltyNotFoundException()
        {
        }

        public LoyaltyNotFoundException(string message) : base(message)
        {
        }

        public LoyaltyNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}