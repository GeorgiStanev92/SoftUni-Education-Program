using System;

namespace Telephony
{
    using Telephony.Models;
    using Telephony.Exceptions;
    public class Program
    {
        static void Main(string[] args)
        {
            string[] number = Console.ReadLine().Split();
            string[] site = Console.ReadLine().Split();

            Smartphone smartPhone = new Smartphone();
            StationaryPhone stationPhone = new StationaryPhone();

            for (int i = 0; i < number.Length; i++)
            {
                string phoneNumber = number[i];

                try
                {
                    if (phoneNumber.Length == 7)
                    {
                        Console.WriteLine(stationPhone.Call(phoneNumber));
                    }
                    else
                    {
                        Console.WriteLine(smartPhone.Call(phoneNumber));
                    }
                }
                catch (InvalidPhoneNumber ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            for (int i = 0; i < site.Length; i++)
            {
                string url = site[i];

                try
                {
                    Console.WriteLine(smartPhone.Browse(url));
                }
                catch (InvalidURLException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
