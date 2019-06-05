using System;
using System.Collections.Generic;
using System.IO;

namespace MatrixMaker
{
    class Program
    {
        public static List<SchoolEntry> ParseSchoolEntriesCSV(String filePath)
        {
            List<SchoolEntry> list = new List<SchoolEntry>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                while(!reader.EndOfStream)
                {
                    String[] result = reader.ReadLine().Split(',');
                    list.Add(new SchoolEntry(result[0], result[1], float.Parse(result[2])));
                }
            }
            return list;
        }

        static void Main(string[] args)
        {
            List<SchoolEntry> list = ParseSchoolEntriesCSV("Assets/CollegeData.csv");
            Console.WriteLine("Hello World!");
        }
    }
}
