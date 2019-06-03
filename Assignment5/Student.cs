using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class Student
    {
        public String Name { get; set; }
        public int IDNum { get; set; }

        public int SumDigits()
        {
           String num= IDNum.ToString();
            int total=0;
            foreach(char c in num)
            {
                total += c;
            }
            return total;
        }

        override
        public String ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(Name);
            output.AppendLine($" ID: {IDNum}");
            return output.ToString();
        }
    }
}
