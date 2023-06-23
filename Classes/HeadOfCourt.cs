using System;
using System.Collections.Generic;
using System.IO;

namespace OOP_Lab5.Properties
{
    public class HeadOfCourt : CivilServant, IComparable<HeadOfCourt>
    {
        //fields
        //======================================================================================================================================
        private int workExperience;
        private string court;
        private string personalQualities;
        //======================================================================================================================================
        
        //dict to count payment for work
        //======================================================================================================================================
        private Dictionary<string, int> paymentForWork = new Dictionary<string, int>();
        //======================================================================================================================================

        //constructors
        //======================================================================================================================================
        public HeadOfCourt()
        {
            WorkExperience = 0;
            Court = "none";
            PersonalQualities = "none";
        }
        
        public HeadOfCourt(string name, int age, string position, int salary, int workExperience, string court, string personalQualities) :
            base(name, age, position, salary)
        {
            WorkExperience = workExperience;
            Court = court;
            PersonalQualities = personalQualities;
        }

        public HeadOfCourt(HeadOfCourt headOfCourt) : base(headOfCourt)
        {
            WorkExperience = headOfCourt.WorkExperience;
            Court = headOfCourt.Court;
            PersonalQualities = headOfCourt.personalQualities;
        }
        //======================================================================================================================================

        //properties
        //======================================================================================================================================
        public int WorkExperience { get => workExperience; set => workExperience = value; }
        public string Court { get => court; set => court = value; }
        public string PersonalQualities { get => personalQualities; set => personalQualities = value; }
        //======================================================================================================================================

        //input/output methods
        //======================================================================================================================================
        public override void Input()
        {
            try
            {
                base.Input();
                Console.WriteLine("Enter years of experience: ");
                WorkExperience = AskIntValue();
                Console.WriteLine("Enter place of work(court): ");
                Court = Console.ReadLine();
                Console.WriteLine("Enter personal qualities: ");
                PersonalQualities = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
            }
        }
        
        public override void Output()
        {
            base.Output();
            Console.WriteLine($"Years of experience: {WorkExperience}");
            Console.WriteLine($"Place of work (court): {Court}");
            Console.WriteLine($"Personal qualities: {PersonalQualities}");
        }
        //======================================================================================================================================
        
        //payment for work methods
        //======================================================================================================================================
        public override void WorkPayment()
        {
            try
            {
                Console.WriteLine("\tPayment for head of court");
                Console.WriteLine("Enter 'q' to exit: ");
                while (true)
                {
                    Console.WriteLine("Enter work: ");
                    string work = Console.ReadLine();
                    if (work == "q")
                    {
                        break;
                    }
                    Console.WriteLine("Enter payment: ");
                    int payment = AskIntValue();
                    paymentForWork.Add(work, payment);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public override void Payment()
        {
            try
            {
                int payment = 0;
                Console.WriteLine("\tPayment for head of court");
                Console.WriteLine("Work:");
                foreach (var pair in paymentForWork)
                {
                    Console.WriteLine("\n" + pair.Key + " : " + pair.Value);
                    payment += pair.Value;
                }

                Console.WriteLine($"\nTotal payment: {payment}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //======================================================================================================================================
        
        //criminal responsibilities
        //======================================================================================================================================
        public override void CriminalResponsibility(List<string> criminals)
        {
            try
            {
                Random random = new Random();

                int response = random.Next(-criminals.Count, criminals.Count);

                if (response < 0)
                {
                    Console.WriteLine($"There is no criminal responsibilities for head of court {Name}");
                }
                else
                {
                    Console.WriteLine($"There is criminal responsibility '{criminals[response]}' for head of court {Name}, term for this is {random.Next(2, 15)} years");   
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //======================================================================================================================================
        
        
        //budget
        //======================================================================================================================================
        public void DevelopBudget(List<BudgetOption> budgetList)
        {
            bool isWorking = true;
            string loadPath = "Budget_report.txt";

            while (isWorking)
            {
                Console.WriteLine("If you wanna add item in menu, enter 1, else if wanna make report - enter 2, wanna exit - enter 0: ");
                int answ = AskIntValue();

                switch (answ)
                {
                    case 0:
                        isWorking = false;
                        break;

                    case 1:
                        Console.WriteLine("enter option: ");
                        string option = Console.ReadLine();
                        Console.WriteLine("\nEnter price: ");
                        int price = AskIntValue();

                        BudgetOption budgetOption = new BudgetOption();
                        budgetOption.nameOfOption = option;
                        budgetOption.price = price;

                        budgetList.Add(budgetOption);
                        break;

                    case 2:
                        int total = 0;
                        using (StreamWriter writer = new StreamWriter(loadPath))
                        {
                            Console.WriteLine("Budget report:");
                            writer.WriteLine("Budget report:");
                            try
                            {
                                foreach (BudgetOption item in budgetList)
                                {
                                    total += item.price;
                                    Console.WriteLine($"\t| {item.nameOfOption}" + " | " + $"{item.price} uah|");
                                    writer.WriteLine($"\t| {item.nameOfOption}" + " | " + $"{item.price} uah|");
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"ERROR: {e.Message}");
                                throw;
                            }

                            Console.WriteLine($"\nTotal cost: {total}");
                            writer.WriteLine($"\nTotal cost: {total}");
                        }

                        break;
                }
            }
        }
        //======================================================================================================================================

        //structure
        //======================================================================================================================================
        public struct BudgetOption
        {
            public string nameOfOption;
            public int price;
        }
        //======================================================================================================================================
        
        //IComparable implementation
        //======================================================================================================================================
        public int CompareTo(HeadOfCourt other)
        {
            return WorkExperience.CompareTo(other.WorkExperience);
        }
        //======================================================================================================================================
        
        //overriding operators
        //======================================================================================================================================
        public static bool operator ==(HeadOfCourt headOfCourt1, HeadOfCourt headOfCourt2)
        {
            return headOfCourt1.Salary == headOfCourt2.Salary;
        }
        public static bool operator !=(HeadOfCourt headOfCourt1, HeadOfCourt headOfCourt2)
        {
            return !(headOfCourt1 == headOfCourt2);
        }
        
        public static bool operator >(HeadOfCourt headOfCourt1, HeadOfCourt headOfCourt2)
        {
            return headOfCourt1.Salary > headOfCourt2.Salary;
        }
        public static bool operator <(HeadOfCourt headOfCourt1, HeadOfCourt headOfCourt2)
        {
            return headOfCourt1.Salary < headOfCourt2.Salary;
        }
        
        public static HeadOfCourt operator +(HeadOfCourt headOfCourt, int value)
        {
            headOfCourt.Salary += value;
            return headOfCourt;
        }
        
        public static HeadOfCourt operator -(HeadOfCourt headOfCourt, int value)
        {
            headOfCourt.Salary -= value;
            return headOfCourt;
        }
        
        public static HeadOfCourt operator ++(HeadOfCourt headOfCourt)
        {
            headOfCourt.Salary += 500;
            return headOfCourt;
        }
        public static HeadOfCourt operator --(HeadOfCourt headOfCourt)
        {
            headOfCourt.Salary -= 500;
            return headOfCourt;
        }
        
        public override string ToString()
        {
            try
            {
                return base.ToString() + $"Years of experience: {WorkExperience}\n" +
                       $"Place of work(court): {Court}\n" +
                       $"Personal qualities: {PersonalQualities}\n";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return "";
        }
        //======================================================================================================================================
    }
}