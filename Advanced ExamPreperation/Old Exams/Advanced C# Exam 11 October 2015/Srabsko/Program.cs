using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class MaxSequenceOfEqualElement
    {
        static void Main(string[] args)

        {
            Dictionary<string, Dictionary<string, ulong>> performerInfo = new Dictionary<string, Dictionary<string, ulong>>();
            string performer = "";
            string venue = "";
            ulong ticketPrice = 0;
            ulong ticketCount = 0;
            ulong totalCurrentProfit = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input.StartsWith("End"))
                {
                    break;
                }

                string[] checkInvalid = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (checkInvalid.Length < 4)
                {
                    continue;
                }

                string[] arr = input.Split('@').ToArray();

                performer = arr[0];

                string[] venuePriceTickets = arr[1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


                ticketCount = ulong.Parse(venuePriceTickets[venuePriceTickets.Length - 1]);
                ticketPrice = ulong.Parse(venuePriceTickets[venuePriceTickets.Length - 2]);
                totalCurrentProfit = ticketPrice * ticketCount;

                string[] venueArr = venuePriceTickets.ToArray();
                venueArr = venueArr.Take(venueArr.Length - 2).ToArray();
                venue = string.Join(" ", venueArr);

                if (performerInfo.ContainsKey(venue))
                {
                    if (performerInfo[venue].ContainsKey(performer))
                    {
                        performerInfo[venue][performer] += totalCurrentProfit;
                    }
                    else
                    {
                        performerInfo[venue].Add(performer, totalCurrentProfit);
                    }
                }
                else
                {
                    Dictionary<string, ulong> currentDict = new Dictionary<string, ulong>();
                    currentDict.Add(performer, totalCurrentProfit);
                    performerInfo.Add(venue, currentDict);
                }

            }


            foreach (var kvp in performerInfo)
            {
                Console.WriteLine(kvp.Key);

                foreach (var name in kvp.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine("#  " + name.Key + "-> " + name.Value);
                }
            }
        }
    }
}