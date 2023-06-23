using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;

namespace OOP_Lab5.Properties
{
    public class StateSecretary : CivilServant, IComparable<StateSecretary>
    {
        //fields
        //======================================================================================================================================
        private int workExperience;
        private string ministry;
        private string personalQualities;
        //======================================================================================================================================
        
        //dict to count payment for work
        //======================================================================================================================================
        private Dictionary<string, int> paymentForWork = new Dictionary<string, int>();
        //======================================================================================================================================

        //constructors
        //======================================================================================================================================
        public StateSecretary()
        {
            WorkExperience = 0;
            Ministry = "none";
            PersonalQualities = "none";
        }

        public StateSecretary(string name, int age, string position, int salary, int workExperience, string ministry, string personalQualities) : 
            base(name, age, position, salary)
        {
            WorkExperience = workExperience;
            Ministry = ministry;
            PersonalQualities = personalQualities;
        }

        public StateSecretary(StateSecretary stateSecretary) : base(stateSecretary)
        {
            WorkExperience = stateSecretary.WorkExperience;
            Ministry = stateSecretary.Ministry;
            PersonalQualities = stateSecretary.PersonalQualities;
        }
        //======================================================================================================================================

        
        //properties
        //======================================================================================================================================
        public int WorkExperience { get => workExperience; set => workExperience = value; }
        public string Ministry { get => ministry; set => ministry = value; }
        public string PersonalQualities { get => personalQualities; set => personalQualities = value; }
        //======================================================================================================================================


        //methods
        //======================================================================================================================================
        public override void Input()
        {
            try
            {
                base.Input();
                Console.WriteLine("Enter years of experience: ");
                WorkExperience = AskIntValue();
                Console.WriteLine("Enter place of work(ministry): ");
                Ministry = Console.ReadLine();
                Console.WriteLine("Enter personal qualities: ");
                PersonalQualities = Console.ReadLine();
            }
            catch { Console.WriteLine("ERROR, try again..."); }
        }
        public override void Output()
        {
            try
            {
                base.Output();
                Console.WriteLine($"Years of experience: {WorkExperience}");
                Console.WriteLine($"Place of work (ministry): {Ministry}");
                Console.WriteLine($"Personal qualities: {PersonalQualities}");
                Console.WriteLine();
            }
            catch {Console.WriteLine("ERROR, try again...");}
        }
        //======================================================================================================================================

        //IComparable implementation
        //======================================================================================================================================
        public int CompareTo(StateSecretary other)
        {
            return WorkExperience.CompareTo(other.WorkExperience);
        }
        //======================================================================================================================================

        //payment for work methods
        //======================================================================================================================================
        public override void WorkPayment()
        {
            try
            {
                Console.WriteLine("\tPayment for state of secretary");
                Console.WriteLine("Enter 0 to exit: ");
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
                Console.WriteLine("\tPayment for state of secretary");
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
                    Console.WriteLine($"There is no criminal responsibilities for secretary of state {Name}");
                }
                else
                {
                    Console.WriteLine($"There is criminal responsibility '{criminals[response]}' for secretary of state {Name}, term for this is {random.Next(2, 15)} years");   
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //======================================================================================================================================
        
        //work plan methods
        //======================================================================================================================================
        public void PrepareWorkPlan(List<Queue<string>> listOfDepartments)
        {
            bool isWorking = true;

            try
            {
                listOfDepartments.Add(new Queue<string>());    //department 1(internal business)  
                listOfDepartments.Add(new Queue<string>());     //department 2(external business)
                listOfDepartments.Add(new Queue<string>());    //department 3(other troubles)
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
            }
            
            
            while(isWorking)
            {
                Console.WriteLine("If you wanna add tasks, enter 1, else if prepare prepare work plan - enter 2, wanna exit - enter 0: ");
                int answer = AskIntValue();
                Random random = new Random();
                
                switch (answer)
                {
                    case 0:
                        isWorking = false;
                        break;
                    
                    case 1:
                        try
                        {
                            Console.WriteLine();
                            Console.WriteLine("Enter your task: ");
                            Console.WriteLine();
                            string task = Console.ReadLine();
                            int department = CheckDepartment(task);
                            listOfDepartments[department].Enqueue(task);
                        }
                        catch { Console.WriteLine("ERROR, try again...");}
                        break;
                    
                    case 2:
                        
                        Console.WriteLine("Report: ");
                        Console.WriteLine();
                        
                        using (StreamWriter writer = new StreamWriter("Internal.txt"))
                        {
                            Console.WriteLine("Internal businesses: ");
                            writer.WriteLine("Internal businesses: ");
                            try
                            {
                                foreach (string _task in listOfDepartments[0])
                                {
                                    int days = random.Next(0, 30);
                                    Console.WriteLine("\t- " + _task + $" (will need {days} days to execute)");
                                    writer.WriteLine("\t- " + _task + $" (will need {days} days to execute)");
                                }
                            }
                            catch {Console.WriteLine("ERROR, try again..."); }
                        }
        
                        using (StreamWriter writer = new StreamWriter("External.txt"))
                        {
                            Console.WriteLine("External businesses: ");
                            writer.WriteLine("External businesses: ");
                            try
                            {
                                foreach (string _task in listOfDepartments[1])
                                {
                                    int days = random.Next(0, 100);
                                    Console.WriteLine("\t- " + _task + $" (will need {days} days to execute)");
                                    writer.WriteLine("\t- " + _task + $" (will need {days} days to execute)");
                                }
                            }
                            catch { Console.WriteLine("ERROR, try again..."); }
                        }
        
                        using (StreamWriter writer = new StreamWriter("Other.txt"))
                        {
                            Console.WriteLine("Other businesses: ");
                            writer.WriteLine("Other businesses: ");
                            try
                            {
                                foreach (string _task in listOfDepartments[2])
                                {
                                    int days = random.Next(0, 50);
                                    Console.WriteLine("\t- " + _task + $" (will need {days} days to execute)");
                                    writer.WriteLine("\t- " + _task + $" (will need {days} days to execute)");
                                }
                            }
                            catch 
                            {
                                Console.WriteLine("ERROR, try again...");
                            }
                        }
                        
                        break;
                    
                    default:
                        Console.WriteLine("no such option....");
                        break;
                }
            }
        }

        private int CheckDepartment(string task)
        {
            string pathInternal = "internal_themes.txt";
            string pathExternal = "external_themes.txt";

            int department = 2;

            string[] InternalOptions = File.ReadAllLines(pathInternal);
            string[] ExternalOptions = File.ReadAllLines(pathExternal);

            try
            {
                foreach (string option in InternalOptions)
                {
                    if (task.ToLower().Contains(option.ToLower()))
                    {
                        department = 0;
                    }
                }
            
                foreach (string option in ExternalOptions)
                {
                    if (task.ToLower().Contains(option.ToLower()))
                    {
                        department = 1;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            return department;
        }
        //======================================================================================================================================
        
        //overriding operators
        //======================================================================================================================================
        public static bool operator ==(StateSecretary stateSecretary1, StateSecretary stateSecretary2)
        {
            return stateSecretary1.Salary == stateSecretary2.Salary;
        }
        public static bool operator !=(StateSecretary stateSecretary1, StateSecretary stateSecretary2)
        {
            return !(stateSecretary1 == stateSecretary2);
        }
        
        public static bool operator >(StateSecretary stateSecretary1, StateSecretary stateSecretary2)
        {
            return stateSecretary1.Salary > stateSecretary2.Salary;
        }
        public static bool operator <(StateSecretary stateSecretary1, StateSecretary stateSecretary2)
        {
            return stateSecretary1.Salary < stateSecretary2.Salary;
        }
        
        public static StateSecretary operator +(StateSecretary stateSecretary, int value)
        {
            stateSecretary.Salary += value;
            return stateSecretary;
        }
        
        public static StateSecretary operator -(StateSecretary stateSecretary, int value)
        {
            stateSecretary.Salary -= value;
            return stateSecretary;
        }
        
        public static StateSecretary operator ++(StateSecretary stateSecretary)
        {
            stateSecretary.Salary += 500;
            return stateSecretary;
        }
        public static StateSecretary operator --(StateSecretary stateSecretary)
        {
            stateSecretary.Salary -= 500;
            return stateSecretary;
        }
        
        public override string ToString()
        {
            try
            {
                return base.ToString() + $"Years of experience: {WorkExperience}\n" +
                       $"Place of work(ministry): {Ministry}\n" +
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