using System;

namespace Checkpoint.Crm.Core.Exceptions
{
    [Serializable]
    public class LoyaltyUnauthorizedException : LoyaltyException
    {
        public LoyaltyUnauthorizedException()
        {
        }

        public LoyaltyUnauthorizedException(string message) : base(message)
        {
        }

        public LoyaltyUnauthorizedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}