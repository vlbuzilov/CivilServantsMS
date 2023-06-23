using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace OOP_Lab5.Properties
{
    public class Specialist : CivilServant, IComparable<Specialist>
    {
        //fields
        //======================================================================================================================================
        private string speciality;
        private int qualificationLevel;
        //======================================================================================================================================
        
        //dict to count payment for work
        //======================================================================================================================================
        private Dictionary<string, int> paymentForWork = new Dictionary<string, int>();
        //======================================================================================================================================

        //properties
        //======================================================================================================================================
        public string Speciality { get => speciality; set => speciality = value; }
        public int QualificationLevel { get => qualificationLevel; set => qualificationLevel = value; }
        //======================================================================================================================================

        //constructors
        //======================================================================================================================================
        public Specialist()
        {
            Speciality = "none";
            QualificationLevel = 0;
        }
        
        public Specialist(string name, int age, string position, int salary, string speciality, int qualificationLevel) : base(name, age, position, salary)
        {
            Speciality = speciality;
            QualificationLevel = qualificationLevel;
        }

        public Specialist(Specialist specialist) : base (specialist)
        {
            Speciality = specialist.Speciality;
            QualificationLevel = specialist.QualificationLevel;
        }
        //======================================================================================================================================
        
        //input/output methods
        //======================================================================================================================================
        public virtual void Input()
        {
            try
            {
                base.Input();
                Console.WriteLine("Enter speciality: ");
                Speciality = Console.ReadLine();
                Console.WriteLine("Enter qualification level: ");
                QualificationLevel = AskIntValue();
            }
            catch{ Console.WriteLine("ERROR, try again...");}
        }
        
        //IComparable implementation
        public int CompareTo(Specialist other)
        {
            return QualificationLevel.CompareTo(other.QualificationLevel);
        }
        //======================================================================================================================================

        //payment for work methods
        //======================================================================================================================================
        public override void WorkPayment()
        {
            try
            {
                Console.WriteLine("\tPayment for specialist");
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
                Console.WriteLine("\tPayment for specialist");
                Console.WriteLine("Work:");
                foreach (var pair in paymentForWork)
                {
                    Console.WriteLine("\t"+pair.Key + " : " + pair.Value);
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
                    Console.WriteLine($"There is no criminal responsibilities for specialist {Name}");
                }
                else
                {
                    Console.WriteLine($"There is criminal responsibility '{criminals[response]}' for specialist {Name}, term for this is {random.Next(2, 15)} years");   
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //======================================================================================================================================
        
        //overriding operators
        //======================================================================================================================================
        public static bool operator ==(Specialist specialist1, Specialist specialist2)
        {
            return specialist1.Salary == specialist2.Salary;
        }
        public static bool operator !=(Specialist specialist1, Specialist specialist2)
        {
            return !(specialist1 == specialist2);
        }
        
        public static bool operator >(Specialist specialist1, Specialist specialist2)
        {
            return specialist1.Salary > specialist2.Salary;
        }
        public static bool operator <(Specialist specialist1, Specialist specialist2)
        {
            return specialist1.Salary < specialist2.Salary;
        }
        
        public static Specialist operator +(Specialist specialist, int value)
        {
            specialist.Salary += value;
            return specialist;
        }
        
        public static Specialist operator -(Specialist specialist, int value)
        {
            specialist.Salary -= value;
            return specialist;
        }

        public static Specialist operator ++(Specialist specialist)
        {
            specialist.Salary += 500;
            return specialist;
        }
        
        public static Specialist operator --(Specialist specialist)
        {
            specialist.Salary -= 500;
            return specialist;
        }
        
        public override string ToString()
        {
            try
            {
                return base.ToString() + $"Speciality: {Speciality}\n" + 
                       $"Qualification level: {QualificationLevel}\n";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "";
            }
        }
        //======================================================================================================================================
        
    }
}