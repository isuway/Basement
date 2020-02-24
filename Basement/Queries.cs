using Basement.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basement
{
    class Queries : IProceed
    {
        class Student
        {
            public int ClassId { get; set; }
            public int StudentId { get; set; }
            public string StudentName { get; set; }
        }

        class Subject
        {
            public int ClassId { get; set; }
            public string ClassName { get; set; }
        }
        public void Act()
        {
            Do1();
        }

        public void Do1()
        {
            var students = new List<Student>
            {
                new Student{ClassId=111, StudentId= 1, StudentName = "one"},
                new Student{ClassId=222, StudentId= 2, StudentName = "two"},
                new Student{ClassId=333, StudentId= 3, StudentName = "three"},
                new Student{ClassId=111, StudentId= 4, StudentName = "four"},
            };
            var subjects = new List<Subject>
            {
                new Subject{ClassId=111, ClassName = "main"},
                new Subject{ClassId=222, ClassName = "master"},
                new Subject{ClassId=333, ClassName = "slave"}
            };

            var result = from student in students
                         join subject in subjects on student.ClassId equals subject.ClassId
                         select new { Std = student.StudentName, Sbj = subject.ClassName };
            foreach (var item in result)
            {
                Console.WriteLine(item.Std + " " + item.Sbj);
            }

            var makeGroup = from student in students
                            group student by student.ClassId;
            foreach (var group in makeGroup)
            {
                Console.WriteLine(group.Key);
                foreach (var item in group)
                {
                    Console.WriteLine(item.StudentName);
                }
            }

        }
    }
}
