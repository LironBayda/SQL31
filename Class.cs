using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL31
{
    class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public int NumberOfStudents { get; set; }
        public int NumberOfVIP { get; set; }
        public int AgeAverge { get; set; }
        public string MostPopularCity { get; set; }
        public int OldestVIP { get; set; }
        public int YoungestVIP { get; set; }

        public override string ToString()
        {
            return base.ToString() + JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public Class()
        {

        }


        public static bool operator ==(Class class1, Class class2)
        {


            if (object.ReferenceEquals(class1, null) && object.ReferenceEquals(class2, null))
                return true;
            if (object.ReferenceEquals(class1, null) || object.ReferenceEquals(class2, null))
                return false;

            return class1.Id == class2.Id;
        }

        public static bool operator !=(Class class1, Class class2)
        {
            return !(class1 == class2);
        }

        public override bool Equals(object obj)
        {
            Class @class = obj as Class;
            if (@class != null)
                return this.Id == @class.Id;

            return false;
        }

        public override int GetHashCode()
        {
            return this.Id;
        }
        
    }
}
