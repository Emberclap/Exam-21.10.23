using System.Globalization;

namespace _01._Offroad_Challenge
{
    public class Program
    {
        static void Main()
        {
            {
               

                Stack<int> fuel = new Stack<int>(Console.ReadLine()
                    .Split()
                    .Select(int.Parse));

                Queue<int> additionalConsumptionIndex = new Queue<int>(Console.ReadLine()
                    .Split()
                    .Select(int.Parse));
                Queue<int> fuelNeeded = new Queue<int>(Console.ReadLine()
                    .Split()
                    .Select(int.Parse));
                List<string> Altitudes = new List<string>();
                
                for (int i = 1; i <= 4; i++) 
                {

                    int substractValue = fuel.Peek() - additionalConsumptionIndex.Peek();
                    int currentFuel = fuelNeeded.Peek();
                        

                    if (substractValue >= currentFuel)
                    {
                        additionalConsumptionIndex.Dequeue();
                        fuel.Pop();
                        fuelNeeded.Dequeue();
                        Console.WriteLine($"John has reached: Altitude {i}");
                        Altitudes.Add($"Altitude {i}");
                    }
                    else
                    {
                        Console.WriteLine($"John did not reach: Altitude {i}");
                        break;
                    }
                    
                }
                if (fuelNeeded.Count > 0)
                {
                    Console.WriteLine("John failed to reach the top.");
                    if (fuelNeeded.Count == 4)
                    {
                        Console.WriteLine("John didn't reach any altitude.");
                    }
                    else
                    {
                        Console.Write("Reached altitudes: ");
                        Console.Write($"{string.Join(", ", Altitudes)}");
                    }
                }
                else
                {
                    Console.WriteLine("John has reached all the altitudes and managed to reach the top!");
                }
               
            }
        }
    }
}