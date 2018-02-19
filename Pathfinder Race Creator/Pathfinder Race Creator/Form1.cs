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
    public partial class Form1 : Form
    {

        RaceInfo raceInfo;

        public Form1()
        {
            InitializeComponent();

            raceInfo = new RaceInfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            raceInfo.location = locationBox.Text;
            raceInfo.appearance = appearanceBox.Text;
            raceInfo.history = historyBox.Text;
            raceInfo.relationships = relationshipsBox.Text;
            raceInfo.classFavor = classFavorBox.Text;

            this.Hide();
            Form2 form = new Pathfinder_Race_Creator.Form2(this.Location, raceInfo);


            DialogResult result = form.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                this.Close();
            }
            else
            {
                this.Location = form.Location;
                this.Show();
                locationBox.Text = raceInfo.location;
                appearanceBox.Text = raceInfo.appearance;
                historyBox.Text = raceInfo.history;
                relationshipsBox.Text = raceInfo.relationships;
                classFavorBox.Text = raceInfo.classFavor;
            }
        }
    }
}
