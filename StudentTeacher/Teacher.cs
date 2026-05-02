using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTeacher
{
    internal class Teacher : Person
    {
        public Teacher(string name) : base(name)
        {
        }

        public override string ToString()
        {
            return $"{this.name} is teaching\n";
        }
    }
}
