
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL31
{
    class Program
    {
        static void Main(string[] args)
        {
            SchoolDAO schoolDAO = new SchoolDAO();
            Dictionary<Class, List<Students>> students = new Dictionary<Class, List<Students>>(); 
           students= schoolDAO.GetMapClassToStudentsDictionary();
           List<KeyValuePair<Class, List<Students>>> studentsArray = students.ToList();
         /*   studentsArray.ForEach(x =>
            {
               Console.WriteLine("class");
               Console.WriteLine(x.Key.ToString());
                Console.WriteLine("Student");

                x.Value.ForEach(y => Console.WriteLine(y.ToString()));

            }
                );*/

            List<Students> studentList=schoolDAO.GetStudentsFromClass(1);
            Console.WriteLine("StudentList:");
            studentList.ForEach(s => Console.WriteLine(s.ToString()));

            var e = schoolDAO.Etger(studentList);

            
                var NumVIP = ((dynamic)e).NumVIP;
                var ave = ((dynamic)e).ave;
                var city = ((dynamic)e).city;
                var maxAge = ((dynamic)e).maxAge;
                var minAge = ((dynamic)e).minAge;


                Console.WriteLine($"{NumVIP} {ave} {city} {maxAge} {minAge}");
            

            Console.ReadLine();
        }
    }
}
