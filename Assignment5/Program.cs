using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[5];
            Student cat = new Student();
            cat.Name = "Cat";
            cat.IDNum = 1234;
            students[0] = cat;
            Student dog = new Student();
            dog.Name = "Dog";
            dog.IDNum = 7861;
            students[1] =dog;
            Student cow = new Student();
            cow.Name = "Cow";
            cow.IDNum = 1111;
            students[2] = cow;
            Student horse= new Student();
            horse.Name = "horse";
            horse.IDNum = 7461;
            students[3] = horse;
            Student chicken = new Student();
            chicken.Name = "Chicken";
            chicken.IDNum = 1697;
            students[4] = chicken;

            //test max over previous with func
            var  valuableStudents=students.MaxOverPrevious(i => i.SumDigits());
            foreach(Student s in valuableStudents)
                 Console.WriteLine(s);
            
            //test max over previous without func
            int[] nums = { 1, 1, 4, 2, 9, 10, 7, 15, 2 };
            var numbers = nums.MaxOverPrevious();
            foreach(int n in numbers)
                Console.WriteLine(n);
            Console.WriteLine();

            //test local maxima with func
            int[] nums2 = { 1, 1, 4, 2, 9, 10, 16, 14, 11};
            var numbers2 = nums2.LocalMaxima(i=>i*(-1));
            foreach (int n in numbers2)
                Console.WriteLine(n);

            //text local maxima without func
            ComparableStudent[] students2 = new ComparableStudent[students.Length];
            for(int c =0; c < students.Length; c++)
            {
                students2[c] = new ComparableStudent(students[c]);
            }
            var bigStudents = students2.LocalMaxima();
            foreach (ComparableStudent s in bigStudents)
                Console.WriteLine(s);
            

            //at least k
            Console.WriteLine(nums2.AtLeastK(4, i => i > 10));

            //at least half
            Console.WriteLine(nums2.AtLeastHalf(i => i < 10));
            Console.Read();

        }
    }
}
