using BL;
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
    public partial class ReportForm : Form
    {
        Field _field;

        public ReportForm(Field field)
        {
            InitializeComponent();

            _field = field;
            _field.OnReportCreate += UpdateReport;
        }

        public void UpdateReport(object sender, ReportEventArgs e)
        {
            dataGridView.Rows.Clear();
            dataGridView.Rows.Add("Kolobok", e.Kolobok.X, e.Kolobok.Y);

            for (int i = 0; i < e.Tanks.Count; i++)
            {
                dataGridView.Rows.Add($"Tank-{i}", e.Tanks[i].X, e.Tanks[i].Y);
            }

            for (int i = 0; i < e.Apples.Count; i++)
            {
                dataGridView.Rows.Add($"Apple-{i}", e.Apples[i].X, e.Apples[i].Y);
            }
        }

        private void ReportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _field.OnReportCreate -= UpdateReport;
        }
    }
}
