using System;

namespace Checkpoint.Crm.Core.Exceptions
{
    [Serializable]
    public class LoyaltyForbiddenException : LoyaltyException
    {
        public LoyaltyForbiddenException()
        {
        }

        public LoyaltyForbiddenException(string message) : base(message)
        {
        }

        public LoyaltyForbiddenException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}