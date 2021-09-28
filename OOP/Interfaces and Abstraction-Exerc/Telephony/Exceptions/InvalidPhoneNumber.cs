using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Exceptions
{
    public class InvalidPhoneNumber : Exception
    {
        private const string Invalid_number_exception_message = "Invalid number!";
        public InvalidPhoneNumber(): base(Invalid_number_exception_message)
        {

        }
    }
}
