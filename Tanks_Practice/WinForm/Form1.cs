using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;

namespace WinForm
{
    public partial class MainForm : Form
    {
        readonly SettingsForm _settingsForm;
        Field _field;

        public MainForm()
        {
            InitializeComponent();
            _settingsForm = new SettingsForm();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            NewGame();
        }

        private void UpdateSettings()
        {
            _settingsForm.ShowDialog();
            this.Size = new Size(_settingsForm.FieldWidth + 16, _settingsForm.FieldHeight + 63);
        }

        private void NewGame()
        {
            _field = new Field(_settingsForm.FieldWidth, _settingsForm.FieldHeight, _settingsForm.TanksCount,
                _settingsForm.AppleCount, _settingsForm.SpeedEntities, GameOver);
        }

        private void GameOver(object sender, EventArgs e)
        {
            MessageBox.Show($"Game Over!");
            NewGame();
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            _field.Draw(g);
        }

        private void fieldUpdateTimer_Tick(object sender, EventArgs e)
        {
            pictureBox.Refresh();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            _field.KeyDown(e.KeyCode);
        }

        private void settingsTSMI_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to continue? Progress will be lost!", "Change game settings",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                UpdateSettings();
                NewGame();
            }
        }

        private void newGameTSMI_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to continue? Progress will be lost!", "New Game",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                NewGame();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to continue? Progress will be lost!", "Game closure.",
                MessageBoxButtons.YesNo) == DialogResult.No)
                e.Cancel = true;
        }

        private void exitTSMI_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
