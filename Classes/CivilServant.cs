using System;
using System.Collections.Generic;
using OOP_Lab5.Properties;

namespace OOP_Lab5.Properties
{
    public class CivilServant 
    {
        //fields
        //======================================================================================================================================
        private string name;
        private int age;
        private string position;
        private int salary;
        //======================================================================================================================================

        //dict to count payment for work
        //======================================================================================================================================
        private Dictionary<string, int> paymentForWork = new Dictionary<string, int>();
        //======================================================================================================================================

        //constructors
        //======================================================================================================================================
        public CivilServant()
        {
            Name = "none";
            Age = 0;
            Position = "none";
            Salary = 0;
        }
        
        public CivilServant(string name, int age, string position, int salary)
        {
            Name = name;
            Age = age;
            Position = position;
            Salary = salary;
        }

        public CivilServant(CivilServant servant)
        {
            Name = servant.Name;
            Age = servant.Age;
            Position = servant.Position;
            Salary = servant.Salary;
        }
        //======================================================================================================================================
        
        //properties
        //======================================================================================================================================
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public string Position { get => position; set => position = value; }
        public int Salary { get => salary; set => salary = value; }
        //======================================================================================================================================

        //methods
        //======================================================================================================================================
        public virtual void Input()
        {
            try
            {
                Console.WriteLine("Enter name: ");
                Name = InputNames();
                Console.WriteLine("Enter age: ");
                Age = AskIntValue();
                Console.WriteLine("Enter position: ");
                Position = Console.ReadLine();
                Console.WriteLine("Enter salary: ");
                Salary = AskIntValue();
            }
            catch{ Console.WriteLine("ERROR, try again...");}
        }
        
        public virtual void Output()
        {
            try
            {
                Console.WriteLine($"Name: {Name}");
                Console.WriteLine($"Age: {Age}");
                Console.WriteLine($"Position: {Position}");
                Console.WriteLine($"Salary: {Salary}");
            }
            catch { Console.WriteLine("ERROR, try again..."); }
        }
        //======================================================================================================================================
        
        //work 
        //======================================================================================================================================
        public virtual void WorkPayment()
        {
            Console.WriteLine("\tPayment for civil servant");
            Console.WriteLine("Enter 0 to exit: ");
            while (true)
            {
                Console.WriteLine("Enter work: ");
                string work = Console.ReadLine();
                Console.WriteLine("Enter payment: ");
                int payment = AskIntValue();
                paymentForWork.Add(work, payment);
            }
        }
        public virtual void Payment()
        {
            int payment = 0;
            Console.WriteLine("\tPayment for civil servant");
            Console.WriteLine("Work:");
            foreach (var pair in paymentForWork)
            {
                Console.WriteLine(pair.Key + " : " + pair.Value);
                payment += pair.Value;
            }

            Console.WriteLine($"Total payment: {payment}");
        }
        //======================================================================================================================================

        //criminal responsibilities
        //======================================================================================================================================
        public virtual void CriminalResponsibility(List<string> criminals)
        {
            Random random = new Random();

            int response = random.Next(-criminals.Count, criminals.Count);

            if (response < 0)
            {
                Console.WriteLine($"There is no criminal responsibilities for civil servant {Name}");
            }
            else
            {
                Console.WriteLine($"There is criminal responsibility {criminals[response]} for civil servant {Name}, term for this is {random.Next(1, 15)}");   
            }
        }
        //======================================================================================================================================


        //overriding operators
        //======================================================================================================================================
        public static bool operator ==(CivilServant servant1, CivilServant servant2)
        {
            return servant1.Salary == servant2.Salary;
        }
        public static bool operator !=(CivilServant servant1, CivilServant servant2)
        {
            return !(servant1 == servant2);
        }
        
        public static bool operator >(CivilServant servant1, CivilServant servant2)
        {
            return servant1.Salary > servant2.Salary;
        }
        public static bool operator <(CivilServant servant1, CivilServant servant2)
        {
            return servant1.Salary < servant2.Salary;
        }
        
        public static CivilServant operator +(CivilServant servant, int value)
        {
            servant.Salary += value;
            return servant;
        }
        
        public static CivilServant operator -(CivilServant servant, int value)
        {
            servant.Salary -= value;
            return servant;
        }

        public static CivilServant operator ++(CivilServant servant)
        {
            servant.Salary =+500;
            return servant;
        }
        public static CivilServant operator --(CivilServant servant)
        {
            servant.Salary =-500;
            return servant;
        }
        
        public override string ToString()
        {
            try
            {
                return ($"Name: {Name}\n" +
                        $"Age: {Age}\n" +
                        $"Position: {Position}\n" +
                        $"Salary: {Salary}\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return "";
        }
        //======================================================================================================================================
        
        
        //additional methods
        //======================================================================================================================================
        protected int AskIntValue(){
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

        protected string InputNames()
        {
            string word = Console.ReadLine();
            word.ToLower();
            
            if (string.IsNullOrEmpty(word))
            {
                return word;
            }

            char[] letters = word.ToCharArray();
            letters[0] = char.ToUpper(letters[0]);
            return new string(letters);
        }
        //======================================================================================================================================
    }
}