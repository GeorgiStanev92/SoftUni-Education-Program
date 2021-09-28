using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int waves = int.Parse(Console.ReadLine());

        int[] plates = Console.ReadLine().Split().Select(int.Parse).ToArray();


        var myQueue = new Queue<int>(plates);
        var mystack = new Stack<int>();

        int counter = 0;

        for (int i = 0; i < waves; i++)
        {
            int[] orcks = Console.ReadLine().Split().Select(int.Parse).ToArray();


            mystack = new Stack<int>(orcks);

            while (myQueue.Any() && mystack.Any())
            {
                if (myQueue.Peek() > mystack.Peek())
                {
                    var curr = myQueue.Dequeue();
                    curr -= mystack.Pop();

                    var myList = new List<int>(myQueue);
                    myQueue.Clear();
                    myQueue.Enqueue(curr);
                    foreach (var item in myList)
                    {
                        myQueue.Enqueue(item);
                    }
                    myList.Clear();
                }
                else if (myQueue.Peek() == mystack.Peek())
                {
                    myQueue.Dequeue();
                    mystack.Pop();
                }
                else if (myQueue.Peek() < mystack.Peek())
                {
                    var curr = mystack.Pop() - myQueue.Peek();
                    myQueue.Dequeue();
                    mystack.Push(curr);
                }
            }

            counter++;

            if (counter % 3 == 0)
            {
                int curr = int.Parse(Console.ReadLine());
                myQueue.Enqueue(curr);
            }
            if (!myQueue.Any())
            {
                Console.WriteLine($"The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", mystack)}");
                return;
            }
        }
        if (myQueue.Any())
        {
            Console.WriteLine($"The people successfully repulsed the orc's attack.");
            Console.WriteLine($"Plates left: {string.Join(", ", myQueue)}");
        }
    }
}