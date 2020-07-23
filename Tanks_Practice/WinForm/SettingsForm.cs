using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm
{
    public partial class SettingsForm : Form
    {
        public int FieldWidth
        {
            get { return widthTB.Value; }
        }

        public int FieldHeight
        {
            get { return heightTB.Value; }
        }

        public int TanksCount
        {
            get { return tanksCountTB.Value; }
        }

        public int AppleCount
        {
            get { return appleCountTB.Value; }
        }

        public int SpeedEntities
        {
            get { return speedTB.Value; }
        }

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
