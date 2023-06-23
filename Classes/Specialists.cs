using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OOP_Lab5.Properties
{
    public class Specialists
    {
        //list of objects
        //======================================================================================================================================
        private List<Specialist> specialists = new List<Specialist>();
        //======================================================================================================================================

        //indexation
        //======================================================================================================================================
        public Specialist this[int index]
        {
            get => specialists[index];
            set => specialists.Insert(index, value);
        }
        //======================================================================================================================================

        //print list
        //======================================================================================================================================
        public void Print()
        {
            try
            {
                specialists = specialists.Distinct().ToList(); //LINQ to remove same elements
                
                for (int i = 0; i < specialists.Count; i++)
                {
                    Console.WriteLine($"Specialist {specialists[i].Name} is {specialists[i].Age}, has {specialists[i].Salary} salary and" +
                                      $" {specialists[i].QualificationLevel} level of qualification");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void WriteToFile()
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter("Specialists.txt"))
                {
                    for (int i = 0; i < specialists.Count; i++)
                    {
                        streamWriter.WriteLine($"Specialist {specialists[i].Name} is {specialists[i].Age}, has {specialists[i].Salary} salary and" +
                                               $" {specialists[i].QualificationLevel} level of qualification");
                        streamWriter.WriteLine("=========================================================");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //======================================================================================================================================

        //sort by rank
        //======================================================================================================================================
        public void SortByRank()
        {
            try
            {
                specialists.Sort((x,y) => x.QualificationLevel.CompareTo(y.QualificationLevel));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //======================================================================================================================================

        //return number of elements
        //======================================================================================================================================
        public int Count()
        {
            return specialists.Count;
        }
        //======================================================================================================================================
    }
}