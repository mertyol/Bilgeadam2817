using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListEx2
{
    class Student
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Class { get; set; }
        public int Age { get; set; }

        public Student(string name, string lastname, string cls, int age)
        {
            Name = name;
            Lastname = lastname;
            Class = cls;
            Age = age;
        }

        public override string ToString()
        {
            return Name + " " + Lastname + "-" + Class + "-" + Age;
        }
    }
}
