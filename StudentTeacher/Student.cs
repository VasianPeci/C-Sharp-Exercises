using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace StudentTeacher
{
    internal class Student : Person
    {
        public Student(string name) : base(name)
        {
        }

        public override string ToString()
        {
            return $"{this.name} is studying\n";
        }
    }
}
