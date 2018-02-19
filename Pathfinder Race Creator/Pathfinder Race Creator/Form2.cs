using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pathfinder_Race_Creator
{
    public partial class Form2 : Form
    {
        RaceInfo raceInfo;
        public Form2(Point pos, RaceInfo info)
        {
            InitializeComponent();
            this.Location = pos;
            raceInfo = info;

            if (raceInfo.type != "")
            {
                typeBox.Text = raceInfo.type;
                sizeBox.Text = raceInfo.size;
                abilityScoreModBox.Text = raceInfo.abilityScoreMod;
                languageBox.Text = raceInfo.language;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            raceInfo.type = typeBox.Text;
            raceInfo.size = sizeBox.Text;
            raceInfo.abilityScoreMod = abilityScoreModBox.Text;
            raceInfo.language = languageBox.Text;

            Form3 form = new Form3(this.Location, raceInfo);
            this.Hide();

            DialogResult result = form.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                this.Close();
            }
            else
            {
                this.Location = form.Location;
                this.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            typeBox.Text = raceInfo.type;
            sizeBox.Text = raceInfo.size;
            abilityScoreModBox.Text = raceInfo.abilityScoreMod;
            languageBox.Text = raceInfo.language;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
