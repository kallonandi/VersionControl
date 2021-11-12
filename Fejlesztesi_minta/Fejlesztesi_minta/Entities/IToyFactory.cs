using Fejlesztesi_minta.Abstraction;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fejlesztesi_minta.Entities
{
    public class BallFactory : Abstraction.Toy
    {
        public Color BallColor { get; set; }

        public Toy CreateNew()
        {
            return new Toy(BallColor);
        }

        Abstraction.Ball Toy.CreateNew()
        {
            throw new NotImplementedException();
        }
    }
}
