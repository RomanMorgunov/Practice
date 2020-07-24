using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class TanksEventArgs : EventArgs
    {
        public Bitmap Image { get; private set; }
        public int Score { get; private set; }

        public TanksEventArgs(Bitmap image, int score)
        {
            Image = image;
            Score = score;
        }
    }
}
