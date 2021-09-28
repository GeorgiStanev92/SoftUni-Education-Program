namespace Telephony.Models
{
    using System.Linq;
    using Telephony.Interfaces;
    using Telephony.Exceptions;

    public class StationaryPhone : ICallable
    {
        public string Call(string phoneNumber)
        {
            if (!phoneNumber.All(x => char.IsDigit(x)))
            {
                throw new InvalidPhoneNumber();
            }
            return $"Dialing... {phoneNumber}";
        }
    }
}
