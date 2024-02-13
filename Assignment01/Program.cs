using System.Runtime.CompilerServices;

namespace Assignment01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool keepAsking = true;
            string userSelection;
            List<Appliance> appliancesTest = new List<Appliance>();
            string testFilePath = "";

            while (keepAsking)
            {
                Console.WriteLine("Welcome to Modern Appliances!");
                Console.WriteLine("How may we assist you?");
                Console.WriteLine("1 – Check out appliance");
                Console.WriteLine("2 – Find appliances by brand");
                Console.WriteLine("3 – Display appliances by type");
                Console.WriteLine("4 – Produce random appliance list");
                Console.WriteLine("5 – Save & exit");
                Console.WriteLine("Enter option:");
                userSelection = Console.ReadLine().Trim();

                if (userSelection == "5")
                {
                    keepAsking = false;
                    /* List of txt lines that will be written into .txt file (with updated info) */
                    string[] newFileLines = new string[appliancesTest.Count()];
                    Appliance appliance;

                    for (int i = 0; i < appliancesTest.Count(); i++)
                    {
                        appliance = appliancesTest.ElementAt(i);
                        /* first 6 attributes for each line are the same regardless of type of appliance */
                        newFileLines[i] = $"{appliance.ItemNumber};{appliance.Brand};{appliance.Quantity};{appliance.Wattage};{appliance.Color};{appliance.Price}";

                        if (appliance is Refrigerator)
                        {
                            newFileLines[i] += $";{appliance.NumberOfDoors};{appliance.Height};{appliance.Width}";
                        }
                        else if(appliance is Vacuum)
                        {
                            newFileLines[i] += $";{appliance.Grade};{appliance.BatteryVoltage}";
                        }
                        else if(appliance is Microwave)
                        {
                            newFileLines[i] += $";{appliance.Capacity};{appliance.RoomType}";
                        }
                        else if (appliance is Dishwasher)
                        {
                            newFileLines[i] += $";{appliance.Feature};{appliance.SoundRating}";
                        }

                        File.WriteAllLines(testFilePath, newFileLines);
                    }
                }
                else if (userSelection == "4")
                {
                    //call method 4
                    Console.WriteLine("Method 4 should be called.");
                }
                else if (userSelection == "3")
                {
                    //call method 3 
                    Console.WriteLine("Method 3 should be called.");
                }
                else if (userSelection == "2")
                {
                    //call method 2 
                    Console.WriteLine("Method 2 should be called.");
                }
                else if (userSelection == "1")
                {
                    //call method 1 
                    Console.WriteLine("Method 1 should be called.");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please select one of the options displayed (1, 2, 3, 4 or 5)");
                }

                Console.WriteLine(""); /* Bottom margin for each asking block */
            }
        }
    }
}
