using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace interLink
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Employee> employeesList = new List<Employee>(); // Information from the file will be written here
            List<string> uniqueDate = new List<string>();        // For unique dates
            List<string> uniqueEmployees = new List<string>();   // For unique employees

            readFromFile(employeesList, uniqueDate);
            writeToFile(employeesList, uniqueDate, uniqueEmployees);
        }

        public static void readFromFile (List<Employee> employeesList, List<string> uniqueDate)
        {
            using (var reader = new StreamReader("acme_worksheet.csv"))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    // filling the list of employees
                    Employee obj = new Employee(values[0], values[1], Convert.ToSingle(values[2]));
                    employeesList.Add(obj);

                    // filling the list of unique date
                    if (!uniqueDate.Contains(obj.date))
                    {
                        uniqueDate.Add(obj.date);
                    }
                }
            }
        }

        public static void writeToFile(List<Employee> employeesList, List<string> uniqueDate, List<string> uniqueEmployees)
        {
            using (var writer = new StreamWriter("newSheet.csv", false))
            {
                //First row
                writer.Write("Name/Date");
                for (int i = 0; i < uniqueDate.Count; i++)
                {
                    writer.Write("," + uniqueDate[i]);
                }

                //Next rows
                for (int i = 0; i < employeesList.Count; i++)
                {
                    if (!uniqueEmployees.Contains(employeesList[i].name))  // checking if the employee not registered yet
                    {
                        writer.Write("\n" + employeesList[i].name);
                        uniqueEmployees.Add(employeesList[i].name);  //filling the list of unique employees

                        for (int j = 0; j < uniqueDate.Count; j++)
                        {
                            //checking, when employee worked, if he didn`t work write '0'
                            if (employeesList.Exists(x => x.name == employeesList[i].name && x.date == uniqueDate[j]))
                            {
                                // serch index of object where there`s a match by name and date 
                                // to record the workHours on the corresponding day
                                int indexOfMatch = employeesList.FindIndex(x => x.name == employeesList[i].name && x.date == uniqueDate[j]);
                                writer.Write("," + employeesList[indexOfMatch].workHours);
                            } else { writer.Write("," + 0); }
                        }
                    }
                }
            }
        }
    }
}
