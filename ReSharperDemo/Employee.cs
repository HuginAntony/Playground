using System;
using System.Collections.Generic;
using System.Text;

namespace ReSharperDemo
{
    public abstract class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public virtual int Age { get; set; }
        public decimal Salary { get; set; }

        public abstract decimal CalculateSalary { get; set; }
    }

    class Developer : Employee
    {
        public override decimal CalculateSalary { get; set; }
    }
}
