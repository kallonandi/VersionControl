using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mikrosimulation.Entities
{
    public class Person
    {
        public int BirthYear { get; set; }
        public Gender Gener { get; set; }
        public int NbrofChildren { get; set; }
        public bool IsAlive { get; set; }

        public Person()
        {
            IsAlive = true;
        }
    }
}
