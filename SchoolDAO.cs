using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL31
{
      
    class SchoolDAO : ISchoolDAO
    {

        SqliteConnection connection;

        public SchoolDAO()
        {
            connection = new SqliteConnection($"Data Source = C:\\Users\\liron\\Downloads\\SQL31.db");

        }
        /*       CREATE TABLE "CUSTOMER" (
       "ID"	INTEGER NOT NULL,
       "FRIST_NAME"	TEXT NOT NULL ,
       "LAST_NAME"	TEXT NOT NULL ,
       "AGE"	INT NOT NULL,
       "ADDRESS_CITY"	CHAR(50),
       "ADDRESS_STREET"	CHAR(50),
       "PH_NUMBER" CHAR(50) UNIQUE,
       PRIMARY KEY("ID"))*/

        public Dictionary<Class, List<Students>> GetMapClassToStudentsDictionary()
        {
            Dictionary<Class, List<Students>> StudentInClass = new Dictionary<Class, List<Students>>();

                // creating conenction to the Sqlite database

                connection.Open();
                using (SqliteCommand cmd = new SqliteCommand("SELECT *,c.Name AS Class_Name, c.Id AS Class_Id ," +
                    "s.Name AS Students_Name, s.Id AS Students_Id FROM Class c JOIN Students s ON s.classId=c.Id", connection))
                {

                using (SqliteDataReader reader = cmd.ExecuteReader())
                {


                    while (reader.Read() == true)
                    {
                    
           
                            Class c = new Class
                            {


                                Id = Convert.ToInt32(reader["Class_Id"]),
                                Name = (string)reader["Class_Name"],
                                Code = Convert.ToInt32(reader["Code"]),
                                NumberOfStudents = Convert.ToInt32(reader["Number_Of_Students"]),
                                NumberOfVIP = Convert.ToInt32(reader["Nunmber_Of_VIP"]),
                                AgeAverge = Convert.ToInt32(reader["Age_Average"]),
                                MostPopularCity = (string)reader["Most_Popular_City"],
                                OldestVIP = Convert.ToInt32(reader["Oldest_ViP"]),
                                YoungestVIP = Convert.ToInt32(reader["Youngest_VIP"]),



                            };

                        Students s = new Students
                        {


                            Id = Convert.ToInt32(reader["Students_Id"]),
                            Name = (string)reader["Students_Name"],
                            Age = Convert.ToInt32(reader["Age"]),
                            AddressCity = (string)reader["Address_city"],
                            VIP = (string)reader["VIP"],



                        };


                        if (StudentInClass.ContainsKey(c))
                        {
                            StudentInClass[c].Add(s);

                        }
                        else
                        {
                            List<Students> students = new List<Students>();
                             students.Add(s);
                            StudentInClass.Add(c, students);

                        }

                    }
                }

                connection.Close();

                return StudentInClass;

            }
        }



        public List<Students> GetStudentsFromClass(int id)
        {
            // creating conenction to the Sqlite database
            List<Students> students1 = new List<Students>();


            connection.Open();
            using (SqliteCommand cmd = new SqliteCommand("SELECT *,c.Name AS Class_Name, c.Id AS Class_Id ," +
                "s.Name AS Students_Name, s.Id AS Students_Id FROM Class c JOIN Students s ON s.classId=c.Id", connection))
            {

                using (SqliteDataReader reader = cmd.ExecuteReader())
                {


                    while (reader.Read() == true)
                    {
                        if (Convert.ToInt32(reader["Class_Id"]) == id)
                        {
                            



                            Students s = new Students
                            {


                                Id = Convert.ToInt32(reader["Students_Id"]),
                                Name = (string)reader["Students_Name"],
                                Age = Convert.ToInt32(reader["Age"]),
                                AddressCity = (string)reader["Address_city"],
                                VIP = (string)reader["VIP"],



                            };

                            students1.Add(s);
                        }
                    

                    }
                }

                connection.Close();

                return students1;

            }
        }

        public object Etger(List<Students> students)
        {

           int NumVIP= students.Count(x => x.VIP == "yes");

            double ave = students.Average(x => x.Age);

            Dictionary<int,string> popularCIty=new Dictionary<int, string>();

           students.GroupBy(x => x.AddressCity).ToList().ForEach(x => 
                {       
                    popularCIty.Add(students.Count(y => y.AddressCity == x.Key),x.Key);   
                }
            );
            string city = popularCIty[popularCIty.Keys.Max()];



            int maxAge= students.Select(s => s.Age).OrderBy(x=>x).First();
        
            int minAge = students.Select(s => s.Age).OrderBy(x => x).Last();

            var result = new
            {
                NumVIP,
                ave,
               city,
                maxAge,
                minAge
            
            };

            return result;
            
        }

        
    

    }
}
