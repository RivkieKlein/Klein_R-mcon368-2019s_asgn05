using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class ComparableStudent : Student, IComparable
    {
        public ComparableStudent(Student s)
        {
            Name = s.Name;
            IDNum = s.IDNum;
        } 
        public int CompareTo(Object obj)
        {
            if (obj.GetType().Equals(this.GetType()))
                return IDNum.CompareTo(((Student)obj).IDNum);
            else
                throw new Exception();
        }
    }
}
