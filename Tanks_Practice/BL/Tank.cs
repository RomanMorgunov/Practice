using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    class Tank : Entity
    {
        internal Tank(int x, int y, int width, int height, int speed)
            : base(x, y, width, height, speed) { }

        internal Subject Act()
        {

            throw new NotImplementedException();
        }

        void Move()
        {
        }
    }
}
