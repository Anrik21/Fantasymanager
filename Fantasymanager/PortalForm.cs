using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fantasymanager
{
    public partial class Dungeonportal : Form
    {
        Filepeon PortalsPeon;

        public Dungeonportal()
        {
            InitializeComponent();
            PortalsPeon = new Filepeon();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SettingsListUpdate();
        }

        private void Button_refresh_list_Click(object sender, EventArgs e)
        {
            SettingsListUpdate();
        }

        private void Button_goto_generator_click(object sender, EventArgs e)
        {
            // Vore smutt att ha nån sorts "om generator öppen lås detta fönster"
            // Fattar inte events nog atm för att implementera
            // ^^ Bara för skoj: fixade, show dialog gör "exakt" detta. ^^
            GeneratorForm generator = new GeneratorForm();

            generator.ShowDialog();
        }

        /// <summary>
        /// Does what it says!
        /// </summary>
        private void SettingsListUpdate()
        {
            listbox_containsSettings.Items.Clear();

            List<string> tempList = PortalsPeon.GetSavedSettingsNames();

            var itemsWithSettings = tempList.Where(x => x.Contains("settings"));

            string tempstring = itemsWithSettings.ToString();

            foreach (object item in itemsWithSettings)
            {
                tempstring = item.ToString();
                tempstring = System.IO.Path.GetFileName(tempstring);

                listbox_containsSettings.Items.Add(tempstring);
            }
        }

        private void Exit_picture_lol_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
