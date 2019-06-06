using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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

        public static int[,] GenerateMatrix(List<SchoolEntry> list, String[] rows, float[] columns)
        {
            int[,] matrix = new int[rows.Length,columns.Length];
            for(int index = 0; index < list.Count; index++)
            {
                for (int i = 0; i < rows.Length; i++)
                {
                    if (list[index].GetRegion() == rows[i])
                    {
                        for (int k = 1; k < columns.Length; k++)
                        {
                            if(columns[k] >= list[index].GetTuition() && columns[k -1] < list[index].GetTuition())
                            {
                                matrix[i,k]++;
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            return matrix;
        }

        public static int[,] PrintMatrix(int[,] matrix, String filePath)
        {
            StreamWriter writer = new StreamWriter(filePath);
            StringBuilder stringBuilder = new StringBuilder();
            int width = matrix.GetLength(1);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int k = 1; k < matrix.GetLength(1); k++)
                {
                    stringBuilder.Append(matrix[i, k]);
                    if(k < matrix.GetLength(1) - 1)
                    {
                        stringBuilder.Append(",");
                    }
                    else
                    {
                        stringBuilder.Append("\n");
                    }
                }
            }
            String myString = stringBuilder.ToString();
            writer.Write(stringBuilder.ToString());
            writer.Flush();

            return matrix;
        }

        static void Main(string[] args)
        {
            List<SchoolEntry> list = ParseSchoolEntriesCSV("Assets/CollegeData.csv");
            String[] rows = new String[] {
                "Far West AK CA HI NV OR WA",
                "Great Lakes IL IN MI OH WI",
                "Mid East DE DC MD NJ NY PA",
                "New England CT ME MA NH RI VT",
                "Plains IA KS MN MO NE ND SD",
                "Rocky Mountains CO ID MT UT WY",
                "Southeast AL AR FL GA KY LA MS NC SC TN VA WV",
                "Southwest AZ NM OK TX" };
            float[] columns = new float[] {0, 10000.0f, 20000.0f, 30000.0f, 40000.0f, 50000.0f };
            int[,] matrix = GenerateMatrix(list, rows, columns);
            PrintMatrix(matrix, "Assets/MatrixOutput.csv");
            Console.WriteLine("Hello World!");
        }
    }
}
