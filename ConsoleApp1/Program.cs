using System;

namespace ShipmentCheckerApp
{
    public class Program
    {
        public static bool inputCheck(int distance, int weight, int size, int fuel)
        {
            // Assume that fuel cannot be negative. 
            // Assume distance is accurate to the .001

            int maxWeight = 500;

            if (size > 300 && size <= 1000)
            {
                maxWeight = 400;
            }

            if (fuel > 230 || fuel <= 0)
            {
                return false;
            }
            if (weight > maxWeight || weight < 0)
            {
                return false;
            }
            if (distance > 43.692) // Max possible distance possible at full tank capacity
            {
                return false;
            }
            if (size > 1000 || size < 0)
            {
                return false;
            }
            return true;
        }
        public  bool checkIfDeliverable(int fuel, int size, int weight, int distance)
        {
            if (inputCheck(distance, weight, size, fuel))
            {
                // Simplified form of general equation of:
                // (Fuel / 6.5 gallons per minute) * 60 seconds per minute * 41.156 meters per second = 2 * Flight Distance one way in km / 1000 meters per km
                double maxDistanceKm = fuel * (2469.36 / 3250); 
                if (maxDistanceKm >= distance)
                {
                    return true;
                }
            }
            return false;
        }
        public static void Main(string[] args)
        {
            Program p = new Program();
            Console.Write("Enter Fuel Amount (gal): ");
            int fuel = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Size (cm): ");
            int size = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Weight (kg): ");
            int weight = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Distance (km): ");
            int distance = Convert.ToInt32(Console.ReadLine());
            var deliveryCheck = new Program();
            if (p.checkIfDeliverable(fuel, size, weight, distance))
            {
                Console.WriteLine("Delivery is possible.");
            }
            else
            {
                Console.WriteLine("Delivery impossible.");
            }
        }
    }
}
