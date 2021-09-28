namespace Telephony.Models
{
    using System.Linq;
    using Telephony.Interfaces;
    using Telephony.Exceptions;

    public class Smartphone : ICallable, IBrowsable
    {
        public string Call(string phoneNumber)
        {
            if (!phoneNumber.All(x => char.IsDigit(x)))
            {
                throw new InvalidPhoneNumber();
            }
            return $"Calling... {phoneNumber}";
        }

        public string Browse(string url)
        {
            if (url.Any(x => char.IsDigit(x)))
            {
                throw new InvalidURLException();
            }
            return $"Browsing: {url}!";
        }
    }
}
