using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Lib
{
    [XmlInclude(typeof(Employee))]
    [XmlInclude(typeof(Manager))]
    [XmlInclude(typeof(Programmer))]
    [Serializable]
    public class Office
    {
        public List<Employee> Employees;
        public string Name;

        public Office() { }

        public Office(List<Employee> employees, string name)
        {
            Employees = employees;
            Name = name;
        }
    }
}