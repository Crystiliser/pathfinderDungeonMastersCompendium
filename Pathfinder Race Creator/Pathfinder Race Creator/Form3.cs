using System;
using System.Xml;
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
    public partial class Form3 : Form
    {
        RaceInfo raceInfo;
        RacialTrait[] racialTraits;

        XmlTextReader xmlReader = new XmlTextReader("C:/Users/Assan Bryant/Documents/Visual Studio 2015/Projects/Pathfinder Race Creator/Pathfinder Race Creator/Racial Traits.xml");
            
        public Form3(Point pos, RaceInfo info)
        {
            InitializeComponent();
            this.Location = pos;

            raceInfo = info;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string currentValue = "";
            int currentTrait = 0;
            while (xmlReader.Read())
            {
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (xmlReader.HasAttributes) //gets name of trait
                        {
                            currentValue = xmlReader.GetAttribute(0);
                        }
                        break;
                    case XmlNodeType.Text:
                        switch (currentValue)
                        {
                            case "count":
                                racialTraits = new RacialTrait[int.Parse(xmlReader.Value)];
                                break;
                            case "names":
                                racialTraits[currentTrait] = new RacialTrait();
                                racialTraits[currentTrait].name = xmlReader.Value;
                                break;
                            case "rpValues":
                                racialTraits[currentTrait].rpValue = int.Parse(xmlReader.Value);
                                break;
                            case "descriptions":
                                racialTraits[currentTrait].description = xmlReader.Value;
                                currentTrait++;
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;  
                }
            }
            for (int i = 0; i < racialTraits.Length; i++)
            {
                racialTraitsNameBox.Items.Add((racialTraits[i].name + " " + racialTraits[i].rpValue.ToString()), false);
            }
        }

        private void racialTraitsNameBox_Click(object sender, EventArgs e)
        {
            //gets name of selected item
            //racialTraitsDescriptionBox.Text = racialTraitsNameBox.SelectedItem.ToString().TrimEnd('1', '2', '3', '4', '5', '6', '7', '8', '9', '0');
            //gets description of selected item
            racialTraitsDescriptionBox.Text = racialTraits[racialTraitsNameBox.SelectedIndex].description;
        }
    }
}
