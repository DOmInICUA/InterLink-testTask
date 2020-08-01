using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interLink
{
    class Employee
    {
        public string name;
        public string date;
        public float workHours;

        public Employee(string name, string date, float workHours)
        {
            this.name = name;
            this.date = convertDate(date);
            this.workHours = workHours;
        }

        public static string convertDate(string date)
        {
            return Convert.ToDateTime(date).Date.ToString("dd-MM-yyyy");
        }
    }


}
