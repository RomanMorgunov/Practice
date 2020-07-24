using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ReportEventArgs : EventArgs
    {
        public Kolobok Kolobok { get; private set; }
        public List<Tank> Tanks { get; private set; }
        public List<Subject> Apples { get; private set; }

        public ReportEventArgs(Kolobok kolobok, List<Tank> tanks, List<Subject> apples)
        {
            this.Kolobok = kolobok;
            this.Tanks = tanks;
            this.Apples = apples;
        }
    }
}
