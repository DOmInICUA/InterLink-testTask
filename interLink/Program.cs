using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace interLink {
    class Program {

        class Employee  {
            string name;
            string date;
            float workHours;

            public Employee(string name, string date, float workHours) {
                this.name = name;
                this.date = convertDate(date);
                this.workHours = workHours;
            }
        }
        static void Main(string[] args) {
            List<Employee> employeesList = new List<Employee>();

            using (var reader = new StreamReader("acme_worksheet.csv")) { 
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    Employee obj = new Employee(values[0], values[1], Convert.ToSingle(values[2]));
                    employeesList.Add(obj);
                }
            }
            


            Console.ReadKey();

        }

        public static string convertDate(string date) {
            return Convert.ToDateTime(date).Date.ToString("dd-MM-yyyy");
        }
    }
}
