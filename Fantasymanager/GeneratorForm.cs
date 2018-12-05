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
    public partial class GeneratorForm : Form
    {
        List<CalendarSettings> calendars;

        public GeneratorForm()
        {
            InitializeComponent();
            //List<string> forgottenRealmsMonths = new List<string>(string[] { "abc"})
            string[] forgottenRealmsMonths = { "Hammer", "Alturiak", "Ches", "Tarsahk", "Mirtul", "Kythorn",
                                                "Flamerule", "Eleasis", "Elient","Marpenoth","Uktar", "Nightal" };
            CalendarSettings ForgottenRealms = new CalendarSettings("Forgotten realms",12, 30, 24, "Bell", forgottenRealmsMonths);
            calendars = new List<CalendarSettings>
            {
                ForgottenRealms
            };

            // Är det här jag borde testa att använda subscriber pattern för att lära mig lite om det?
            foreach (CalendarSettings settings in calendars)
                GeneratorChoicebox.Items.Add(settings.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
