using System;

namespace InensiaProject
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            Console.WriteLine("Main menu");
            Console.WriteLine("---------");
            Console.WriteLine();
            Console.WriteLine("1. View Movie Stars List");
            Console.WriteLine("2. Calculate Net Salary");
            Console.WriteLine("3. Exit");

            while (true)
            {
                string userChoise = Console.ReadLine();
                if (int.TryParse(userChoise, out int choise))
                {
                    if (choise == 1)
                    {
                        log.Info("User choise is 1.");
                        // Read the file as one string.
                        string text = System.IO.File.ReadAllText(@"..\..\..\..\InensiaProject\Input.txt");
                        // Display the file contents to the console. Variable text is a string.
                        Console.WriteLine(text);
                    }
                    else if (int.Parse(userChoise) == 2)
                    {
                        log.Info("User choise is 2.");
                        Console.WriteLine("Welcome to Imaginaria.");
                        Console.WriteLine("Please type your salary to see how much taxes you have to pay.");
                        double salary = double.Parse(Console.ReadLine());
                        if (salary <= 1000)
                        {
                            Console.WriteLine("Congratulations you don't have to pay any taxes.");
                            Console.WriteLine();
                        }
                        else
                        {
                            salary -= 1000;
                            double incomeTax = salary * 0.10;
                            if (salary > 3000)
                            {
                                Console.WriteLine("Your salary is bigger than 4000 IDR, you have to pay only Income tax of 10%.");
                                Console.WriteLine($"{incomeTax:f2} IDR");
                                Console.WriteLine($"You left with {salary + 1000 - incomeTax:f2} IDR");
                                Console.WriteLine();
                            }
                            else
                            {
                                double newSalary = salary - incomeTax;
                                double socialTax = newSalary * 0.15;
                                Console.WriteLine("Your salary is less than 4000 IDR, you have to pay Income tax of 10% and Social contributions of 15%.");
                                Console.WriteLine($"Income tax: {incomeTax:f2} IDR");
                                Console.WriteLine($"Social tax: {socialTax:f2} IDR");
                                Console.WriteLine($"You left with {salary + 1000 - socialTax - incomeTax:f2} IDR");
                                Console.WriteLine();
                            }

                        }

                    }
                    else if (int.Parse(userChoise) == 3)
                    {
                        log.Info("User choise is 3.");
                        Console.WriteLine("Come back soon!");
                        break;
                    }
                    else
                    {
                        log.Info($"{userChoise}");
                        Console.WriteLine($"{userChoise} is not in the menu.");
                    }

                }
                else
                {
                    log.Info($"{userChoise}");
                    Console.WriteLine($"{userChoise} is not in the menu.");
                }

            }

        }
    }
}