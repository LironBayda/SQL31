using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL31
{
    interface ISchoolDAO
    {

        Dictionary<Class, List <Students> >  GetMapClassToStudentsDictionary();
        List<Students> GetStudentsFromClass(int id);
    }
}
