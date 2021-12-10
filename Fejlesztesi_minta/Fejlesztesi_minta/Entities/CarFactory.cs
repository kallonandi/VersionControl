using Fejlesztesi_minta.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fejlesztesi_minta.Entities
{
    class CarFactory : Abstraction.Toy
    {
        public Abstraction.Ball CreateNew()
        {
            return new Car();
        }
    }
}
