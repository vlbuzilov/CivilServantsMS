using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OOP_Lab5.Properties;


namespace OOP_Lab5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            MainMenuConditions();
            MainMenu();
        }

        static void MainMenuConditions()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\tMain menu");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Specialists, civil servants, heads of court, secretaries of state");
            Console.WriteLine("2. Specialists, civil servants, heads of court, secretaries of state (with overloaded operators)");
            Console.WriteLine("3. Specialists (work with indexation)\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("0. Exit\n");
            
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void Conditions1()  //menu 1
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\tCivil servant");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Print object's data");
            Console.WriteLine("2. Input object's data\n");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\tState secretary");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("3. Print object's data");
            Console.WriteLine("4. Input object's data");
            Console.WriteLine("5. Prepare work plan");
            Console.WriteLine("6. Enter work and payment for it");
            Console.WriteLine("7. Print work and payment for it");
            Console.WriteLine("8. Define criminal responsibility\n");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\tHead of court");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("9. Print object's data");
            Console.WriteLine("10. Input object's data");
            Console.WriteLine("11. Develop budget for court");
            Console.WriteLine("12. Enter work and payment for it");
            Console.WriteLine("13. Print work and payment for it");
            Console.WriteLine("14. Define criminal responsibility\n");
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\tSpecialist");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("15. Print object's data");
            Console.WriteLine("16. Input object's data");
            Console.WriteLine("17. Enter work and payment for it");
            Console.WriteLine("18. Print work and payment for it");
            Console.WriteLine("19. Define criminal responsibility\n");
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("0. Exit");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
        }

        static void Conditions2() //menu 2
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Print list of specialists");
            Console.WriteLine("2. Print list of secretaries of state");
            Console.WriteLine("3. Print list of heads of court");
            Console.WriteLine("4. Sort specialists by rank");
            Console.WriteLine("5. Recount salary by rank for specialists");
            Console.WriteLine("6. Find heads of court with the same salary");
            Console.WriteLine("7. Find secretaries of state with the same salary\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("0. Exit\n");
            Console.WriteLine();
            
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        static void Conditions3() //menu 3
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Add member to list");
            Console.WriteLine("2. Sort by rank and print");
            Console.WriteLine("3. Edit specialists salary");
            Console.WriteLine("4. Print list of specialists\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("0. Exit\n");
            Console.WriteLine();
            
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void MainMenu()
        {
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine("Enter menu option: ");
                int answ = AskIntValue();
                Console.WriteLine();
                switch (answ)
                {
                    case 1:
                        Conditions1();
                        Menu1();
                        break;
                    
                    case 2:
                        Conditions2();
                        Menu2();
                        break;
                    
                    case 3:
                        Conditions3();
                        Menu3();
                        break;
                    
                    case 0:
                        isWorking = false;
                        break;
                    
                    default:
                        Console.WriteLine("No such option...");
                        break;
                } 
            }
        }

        static void Menu1()
        {
            bool isWorking = true;

            List<Queue<string>> listOfDepartments = new List<Queue<string>>();
            List<HeadOfCourt.BudgetOption> budgetList = new List<HeadOfCourt.BudgetOption>();
            List<string> criminalResponsibilities = new List<string>();
            FillCriminalResponsibilities(criminalResponsibilities);

            CivilServant civilServant = new CivilServant();
            StateSecretary stateSecretary = new StateSecretary();
            HeadOfCourt headOfCourt = new HeadOfCourt();
            Specialist specialist = new Specialist();

            while (isWorking)
            {
                Console.WriteLine("Enter menu option: ");
                int answ = AskIntValue();
                Console.WriteLine();
                switch (answ)
                {
                    case 1:
                        Console.WriteLine(civilServant.ToString());
                        break;
                    
                    case 2:
                        civilServant.Input();
                        break;
                    
                    case 3:
                        Console.WriteLine(stateSecretary.ToString());
                        break;
                    
                    case 4:
                        stateSecretary.Input();
                        break;
                    
                    case 5:
                        stateSecretary.PrepareWorkPlan(listOfDepartments);
                        break;
                    
                    case 6:
                        stateSecretary.WorkPayment();
                        break;
                    
                    case 7:
                        stateSecretary.Payment();
                        break;
                    
                    case 8:
                        stateSecretary.CriminalResponsibility(criminalResponsibilities);
                        break;
                    
                    case 9:
                        Console.WriteLine(headOfCourt.ToString());
                        break;
                    
                    case 10: 
                        headOfCourt.Input();
                        break;
                    
                    case 11:
                        headOfCourt.DevelopBudget(budgetList);
                        break;
                    
                    case 12:
                        headOfCourt.WorkPayment();
                        break;
                    
                    case 13:
                        headOfCourt.Payment();
                        break;
                    
                    case 14:
                        headOfCourt.CriminalResponsibility(criminalResponsibilities);
                        break;
                    
                    case 15:
                        Console.WriteLine(specialist.ToString());
                        break;
                    
                    case 16:
                        specialist.Input();
                        break;
                    
                    case 17:
                        specialist.WorkPayment();
                        break;       
                    
                    case 18:
                        specialist.Payment();
                        break;
                    
                    case 19:
                        specialist.CriminalResponsibility(criminalResponsibilities);
                        break;
                    
                    case 0:
                        isWorking = false;
                        break;
                    
                    default:
                        Console.WriteLine("No such option...");
                        break;
                }
            }
        }

        static void Menu2()
        {
            bool isWorking = true;
            
            List<Specialist> specialists = new List<Specialist>();
            List<HeadOfCourt> headOfCourts = new List<HeadOfCourt>();
            List<StateSecretary> stateSecretaries = new List<StateSecretary>();
            
            specialists.Add(new Specialist("John", 35, "Manager", 8000, "Software Development", 91));
            specialists.Add(new Specialist("Tom", 24, "Junior Analyst", 4000, "Data Analysis", 67));
            specialists.Add(new Specialist("Sara", 29, "Marketing Manager", 6000, "Marketing Strategy", 65));
            
            headOfCourts.Add(new HeadOfCourt("Emily", 48, "Chief Justice", 16000, 27, "Supreme Court", "Integrity, Leadership, and Communication Skills"));
            headOfCourts.Add(new HeadOfCourt("Ryan", 40, "Circuit Judge", 8500, 18, "District Court", "Fairness, Analytical Skills, and Attention to Detail"));
            headOfCourts.Add(new HeadOfCourt("Jessica", 32, "Associate Judge", 5500, 3, "Municipal Court", "Punctuality, Adaptability, and Teamwork"));
            
            stateSecretaries.Add(new StateSecretary("Alice", 52, "Secretary of State", 17000, 30, "Department of State", "Leadership, Strategic Thinking, and Negotiation Skills"));
            stateSecretaries.Add(new StateSecretary("Ben", 45, "Deputy Secretary of State", 17000, 15, "Department of Treasury", "Analytical Skills, Attention to Detail, and Decision-making Abilities"));
            stateSecretaries.Add(new StateSecretary("Carla", 37, "Assistant Secretary of State", 60000, 5, "Department of Education", "Organizational Skills, Time Management, and Interpersonal Abilities"));
            
            while (isWorking)
            {
                Console.WriteLine("Enter menu option: ");
                int answ = AskIntValue();
                Console.WriteLine();
                switch (answ)
                {
                    case 1:
                        using (StreamWriter streamWriter = new StreamWriter("Specialist_second.txt"))
                        {
                            foreach (var specialist in specialists)
                            {
                                Console.WriteLine(specialist.ToString());
                                Console.WriteLine("-----------");
                                streamWriter.WriteLine(specialist.ToString());
                                streamWriter.WriteLine("-----------");
                            }
                        }
                        break;
                    
                    case 2:
                        using (StreamWriter streamWriter = new StreamWriter("Secretaries.txt"))
                        {
                            foreach (var secretary in stateSecretaries)
                            {
                                Console.WriteLine(secretary.ToString());
                                Console.WriteLine("-----------");
                                streamWriter.WriteLine(secretary.ToString());
                                streamWriter.WriteLine("-----------");
                            }
                        }
                        break;
                    
                    case 3:
                        using (StreamWriter streamWriter = new StreamWriter("HeadsOfCourt.txt"))
                        {
                            foreach (var headOfCourt in headOfCourts)
                            {
                                Console.WriteLine(headOfCourt.ToString());
                                Console.WriteLine("-----------");
                                streamWriter.WriteLine(headOfCourt.ToString());
                                streamWriter.WriteLine("-----------");
                            }
                        }
                        break;
                    
                    case 4:
                        try
                        {
                            if (specialists.Count > 0)
                            {
                                specialists.Sort();
                                Console.WriteLine("Sorting by rank was successful!");
                                Console.WriteLine("Sorted order: \n");
                                using (StreamWriter streamWriter = new StreamWriter("SortedByRank.txt"))
                                {
                                    foreach (var specialist in specialists)
                                    {
                                        Console.WriteLine($"{specialist.Name} has rank {specialist.QualificationLevel}");
                                        streamWriter.WriteLine(specialist.ToString());
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("List is empty...");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        Console.WriteLine();
                        break;
                    
                    case 5:
                        try
                        {
                            if (specialists.Count > 0)
                            {
                                RecountSalary(specialists);
                                Console.WriteLine("Salaries was updated");
                            }
                            else
                            {
                                Console.WriteLine("List is empty...");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    
                    case 6:
                        try
                        {
                            bool answer = SameSalaryHeadOfCourt(headOfCourts);
                            if (!answer) Console.WriteLine("There is no heads of court with the same salary....");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    
                    case 7:
                        try
                        {
                            bool answer_ = SameSalaryStateSecretary(stateSecretaries);
                            if (!answer_) Console.WriteLine("There is no secretaries of state with the same salary....");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    
                    case 0:
                        isWorking = false;
                        break;
                    
                    default:
                        Console.WriteLine("No such option...");
                        break;
                }
            }
        }

        static void Menu3()
        {
            bool isWorking = true;
            int i = 0;
            
            Specialists specialists = new Specialists();

            while (isWorking)
            {
                Console.WriteLine("Enter menu option: ");
                int answ = AskIntValue();
                Console.WriteLine();

                switch (answ)
                {
                    case 1:
                        try
                        {
                            Specialist specialist = new Specialist();
                            specialist.Input();
                            specialists[i] = specialist;
                            Console.WriteLine("Specialist was successfully added!");
                            i++;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    
                    case 2:
                        try
                        {
                            if (specialists.Count() != 0)
                            {
                                specialists.SortByRank();
                                Console.WriteLine("List was sorted by rank!");   
                            }
                            else
                            {
                                Console.WriteLine("list is empty...");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    
                    case 3:
                        try
                        {
                            int ind = 0;
                            bool inRange = true;
                            Console.WriteLine("Enter index of specialist, whose salary you wanna edit: ");
                            while (true)
                            {
                                ind = AskIntValue();
                                if (ind >= 0 && ind < specialists.Count())break;
                                else
                                {
                                    Console.WriteLine("Index out of range...");
                                    inRange = false;
                                    break;
                                }
                            }
                            if (inRange)
                            {
                                Console.WriteLine("Enter sum: ");
                                int sum = AskIntValueAny();
                                specialists[ind] = specialists[ind] + sum;
                        
                                Console.WriteLine($"New salary is: {specialists[ind].Salary}");
                                specialists.WriteToFile();
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    
                    case 4:
                        try
                        {
                            Console.WriteLine("List of specialists:\n");
                            specialists.Print();
                            specialists.WriteToFile();
                            Console.WriteLine();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    
                    case 0:
                        isWorking = false;
                        break;
                    
                    default:
                        Console.WriteLine("No such option...");
                        break;
                }
            }
        }

        //additional methods

        private static bool SameSalaryStateSecretary(List<StateSecretary> stateSecretaries)
        {
            bool isHere = false;
                        
            if (stateSecretaries.Count > 0)
            {
                for (int i = 0; i < stateSecretaries.Count; i++)
                {
                    for (int j = 0; j < stateSecretaries.Count; j++)
                    {
                        if (stateSecretaries[i] == stateSecretaries[j] && stateSecretaries[i].Name != stateSecretaries[j].Name)
                        {
                            isHere = true;
                            Console.WriteLine($"{stateSecretaries[i].Name} has the same salary as {stateSecretaries[j].Name}, which is {stateSecretaries[i].Salary}");
                        }
                    }
                }
            }

            return isHere;
        }
        
        private static bool SameSalaryHeadOfCourt(List<HeadOfCourt> headOfCourts)
        {
            bool isHere = false;
                        
            if (headOfCourts.Count > 0)
            {
                for (int i = 0; i < headOfCourts.Count; i++)
                {
                    for (int j = 0; j < headOfCourts.Count; j++)
                    {
                        if (headOfCourts[i] == headOfCourts[j] && headOfCourts[i].Name != headOfCourts[j].Name)
                        {
                            isHere = true;
                            Console.WriteLine($"{headOfCourts[i].Name} has the same salary as {headOfCourts[j].Name}, which is {headOfCourts[i].Salary}");
                        }
                    }
                }
            }

            return isHere;
        }
        private static void RecountSalary(List<Specialist> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].QualificationLevel > 50 && list[i].QualificationLevel < 85)
                {
                    list[i]++;
                }
                else if (list[i].QualificationLevel >= 85)
                {
                    list[i] += 1500;
                }
            }

        }
        
        
        private static void FillCriminalResponsibilities(List<string> responses)
        {
            responses.Add("Misuse of public funds");
            responses.Add("Abuse of power");
            responses.Add("Fraudulent activities");
            responses.Add("Negligence or dereliction of duty");
            responses.Add("Obstruction of justice");
            responses.Add("Failure to uphold the law");
            responses.Add("Misconduct outside the courtroom");
            responses.Add("Abuse of power or authority");
            responses.Add("Making false statements or perjury");
            responses.Add("Prejudice or bias in decision-making");
        }
        
        private static int AskIntValue(){
            int a;
            while (true)
            {
                string answ = Console.ReadLine();
                if (!int.TryParse(answ, out a))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong type of data, try again...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if(a < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Must be positive...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else break;
            }

            return a;
        }
        
        private static int AskIntValueAny(){
            int a;
            while (true)
            {
                string answ = Console.ReadLine();
                if (!int.TryParse(answ, out a))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong type of data, try again...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else break;
            }

            return a;
        }
    }
}