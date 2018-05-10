using System;
using System.Xml.Serialization;

namespace Lib
{
    [XmlInclude(typeof(Manager))]
    [XmlInclude(typeof(Programmer))]
    [Serializable]
    public class Employee
    {
        public string Surname;
    }
}