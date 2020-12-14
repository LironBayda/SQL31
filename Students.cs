using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL31
{
    class Students
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string AddressCity { get; set; }
        public string VIP { get; set; }

        public override string ToString()
        {
            return base.ToString() + JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public Students()
        {

        }

        public static bool operator ==(Students students1, Students students2)
        {
            if (object.ReferenceEquals(students1, null) && object.ReferenceEquals(students2, null))
                return true;
            if (object.ReferenceEquals(students1, null) || object.ReferenceEquals(students2, null))
                return false;

            return students1.Id == students2.Id;
        }

        public static bool operator !=(Students students1, Students students2)
        {
            return !(students1 == students2);
        }

        public override bool Equals(object obj)
        {
            Students students = obj as Students;
            if (students != null)
                return this.Id == students.Id;

            return false;
        }

        public override int GetHashCode()
        {
            return this.Id;
        }
    }
}
