using System;

namespace Checkpoint.Crm.Core.Exceptions
{
    [Serializable]
    public class LoyaltyValidationException : LoyaltyException
    {
        public LoyaltyValidationException()
        {
        }

        public LoyaltyValidationException(string message) : base(message)
        {
        }

        public LoyaltyValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}