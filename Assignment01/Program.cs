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
                        else if (appliance is Vacuum)
                        {
                            newFileLines[i] += $";{appliance.Grade};{appliance.BatteryVoltage}";
                        }
                        else if (appliance is Microwave)
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

        static void DisplayAppliancesByType(List<Appliance> applianceList)
        {
            Console.WriteLine("Appliance Types");
            Console.WriteLine("1 - Refrigerators");
            Console.WriteLine("2 - Vacuums");
            Console.WriteLine("3 - Microwaves");
            Console.WriteLine("4 - Dishwashers");
            Console.WriteLine("Enter type of appliance:");
            string UserResponse;
            bool continueAsking = true;

            while (continueAsking)
            {
                UserResponse = Console.ReadLine().Trim();
                if (UserResponse == "1")
                {
                    Console.WriteLine("Enter number of doors: 2 (double door), 3 (three doors) or 4 (four doors):");
                    while (continueAsking)
                    {
                        UserResponse = Console.ReadLine().Trim();
                        if (UserResponse != "2" && UserResponse != "3" && UserResponse != "4")
                        {
                            Console.WriteLine("Please enter a valid number of doors (2, 3, or 4):");
                        }
                        else
                        {
                            continueAsking = false;
                            Console.WriteLine("Matching refrigerators:\n");  
                            foreach (Appliance appliance in applianceList)
                            {
                                if(appliance is Refrigerator)
                                {
                                    if (appliance.NumberOfDoors == Int32.Parse(UserResponse))
                                    {
                                        Console.WriteLine(appliance.ToString());
                                    }
                                }
                            }
                        }
                    }
                }
                else if (UserResponse == "2")
                {
                    Console.WriteLine("Enter battery voltage value. 18 V (low) or 24 V (high):");
                    while (continueAsking)
                    {
                        UserResponse = Console.ReadLine().Trim();
                        if (UserResponse != "18" && UserResponse != "24")
                        {
                            Console.WriteLine("Please enter a valid number of battery voltage value: 18 (Low V) or 24 (High V):");
                        }
                        else
                        {
                            continueAsking = false;
                            Console.WriteLine("Matching vacuums:\n");
                            foreach (Appliance appliance in applianceList)
                            {
                                if (appliance is Vacuum)
                                {
                                    if (appliance.BatteryVoltage == Int32.Parse(UserResponse))
                                    {
                                        Console.WriteLine(appliance.ToString());
                                    }
                                }
                            }
                        }
                    }
                }
                else if (UserResponse == "3")
                {
                    Console.WriteLine("Room where the microwave will be installed: K (kitchen) or W (work site):");
                    while (continueAsking)
                    {
                        UserResponse = Console.ReadLine().Trim().ToUpper();
                        if (UserResponse != "K" && UserResponse != "W")
                        {
                            Console.WriteLine("Please enter a valid room where the microwave will be installed: K (kitchen) or W (work site):");
                        }
                        else
                        {
                            continueAsking = false;
                            Console.WriteLine("Matching microwaves:\n");
                            foreach (Appliance appliance in applianceList)
                            {
                                if (appliance is Microwave)
                                {
                                    if (appliance.RoomType == UserResponse)
                                    {
                                        Console.WriteLine(appliance.ToString());
                                    }
                                }
                            }
                        }
                    }
                }
                else if (UserResponse == "4")
                {
                    Console.WriteLine("Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate):");
                    while (continueAsking)
                    {
                        UserResponse = Console.ReadLine().Trim().ToUpper();
                        if (UserResponse != "QT" && UserResponse != "QR" && UserResponse != "QU" && UserResponse != "M")
                        {
                            Console.WriteLine("Please enter a valid sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate):");
                        }
                        else
                        {
                            continueAsking = false;
                            Console.WriteLine("Matching dishwashers:\n");
                            foreach (Appliance appliance in applianceList)
                            {
                                if (appliance is Dishwasher)
                                {
                                    if (appliance.SoundRating == UserResponse)
                                    {
                                        Console.WriteLine(appliance.ToString());
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. please enter a valid type of appliance (1, 2, 3, or 4):");
                }
            }
        }
    }
}
