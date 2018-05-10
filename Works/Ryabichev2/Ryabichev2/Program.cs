using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Lib;

/*
 * Ученик:  Рябичев Алексей Михайлович
 * Ггруппа: БПИ176 (11)
 * Дата:    2018.04.26
 * Задача:  
 */

namespace Ryabichev2
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                try
                {
                    Random random = new Random(DateTime.Now.Millisecond);
                    bool flag = false;
                    int n = 0;

                    while (!flag)
                    {
                        Console.Write("Enter n: ");
                        if (int.TryParse(Console.ReadLine(), out n) && n >= 1)
                            flag = true;
                        else
                            Console.WriteLine("N must be >= 1");
                    }

                    List<Employee> employees = new List<Employee>(n);
                    for (int i = 0; i < n; i++)
                    {
                        employees.Add(random.Next(0, 2) % 2 == 0 ? (Employee) new Manager{numberOfWorkers =  random.Next(0, 10)} : new Programmer{ProjectName = $"Project #{random.Next(0, 10)}"});
                    }

                    Office office1 = new Office(employees, "First Office");
                    Office office2 = office1;
                    

                    XmlSerializer officeSerializer =  new XmlSerializer(typeof(List<Office>));
                    string fileName = "text.txt";

                    if (File.Exists(fileName))
                        File.Delete(fileName);

                    FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate);
                    try
                    {
                        List<Office> sOffices= new List<Office> {office1, office2};
                        officeSerializer.Serialize(fileStream, sOffices);

                        List<Office> offices = (List<Office>)officeSerializer.Deserialize(fileStream);

                        foreach (Office office in offices)
                        {
                            Console.WriteLine(office.Name);
                            foreach (Employee employee in office.Employees)
                            {
                                Console.WriteLine($"{employee.Surname} " + (employee is Manager ? ((Manager)employee).numberOfWorkers.ToString() : ((Programmer)employee).ProjectName));
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine("Press Esc to exit or another button to continue");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}