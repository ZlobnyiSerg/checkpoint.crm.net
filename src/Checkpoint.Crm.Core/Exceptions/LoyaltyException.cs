using System;

namespace Checkpoint.Crm.Core.Exceptions
{
    [Serializable]
    public class LoyaltyException : ApplicationException
    {
        public LoyaltyException()
        {
        }

        public LoyaltyException(string message) : base(message)
        {
        }

        public LoyaltyException(string message, Exception innerException) : base(message, innerException)
        {
        }
        
        
    }
}
