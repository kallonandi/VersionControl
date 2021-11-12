using Fejlesztesi_minta.Abstraction;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fejlesztesi_minta.Entities
{
    public class Toy : Abstraction.Toy
    {
       
    protected override void DrawImage(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Blue), 0, 0, Width, Height);
        }
    }
}

