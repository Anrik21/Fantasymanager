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
        Filepeon GeneratorsFilePeon;

        public GeneratorForm()
        {
            InitializeComponent();
            //List<string> forgottenRealmsMonths = new List<string>(string[] { "abc"})
            List<string> forgottenRealmsMonths = new List<string>()
            {
                "Hammer", "Alturiak", "Ches", "Tarsahk",
                "Mirtul", "Kythorn","Flamerule", "Eleasis",
                "Elient","Marpenoth","Uktar", "Nightal"
            };
            CalendarSettings ForgottenRealms = new CalendarSettings("Forgotten realms",12, 30, 24, forgottenRealmsMonths);
            calendars = new List<CalendarSettings>
            {
                ForgottenRealms
            };

            GeneratorsFilePeon = new Filepeon();
            

            // Är det här jag borde testa att använda subscriber pattern för att lära mig lite om det?
            foreach (CalendarSettings settings in calendars)
                GeneratorChoicebox.Items.Add(settings.ToString());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CalendarAdded()
        {
            GeneratorChoicebox.Items.Clear();

            foreach (CalendarSettings settings in calendars)
                GeneratorChoicebox.Items.Add(settings.ToString());
        }

        private void TryAddCalendar_Click(object sender, EventArgs e)
        {
            if (SettingsValidation(MonthInput.Text))
            {
                if (SettingsValidation(DayInput.Text))
                    if (SettingsValidation(HourInput.Text))
                        if (nameInput.Text != null)
                        {
                            CalendarSettings newCalendar = new CalendarSettings(nameInput.Text, Convert.ToInt32(MonthInput.Text),
                                Convert.ToInt32(DayInput.Text), Convert.ToInt32(HourInput.Text));

                            var checkIfDuplicate = calendars.Any(x => x.CalendarName == newCalendar.CalendarName);

                            if (checkIfDuplicate)
                            {
                                MessageBox.Show("This calendar is already added!", "Duplicate found");
                                return;
                            }
                            else
                                calendars.Add(newCalendar);

                            CalendarAdded();
                            nameInput.ResetText();
                            MonthInput.ResetText();
                            DayInput.ResetText();
                            HourInput.ResetText();
                        }
            }
            else
                System.Media.SystemSounds.Asterisk.Play();
        }

        private bool SettingsValidation(string input)
        {
            if (input != null && input != "")
            {
                try
                {
                    int tester = Convert.ToInt32(input);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Everything in the boxes for Y/D/H needs to be numbers!", "Format exception");
                    return false;
                }

                return true;
            }
            else
                MessageBox.Show("Input can't be nothing!", "Input error");

            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (SettingsValidation(genYear1.Text))
                if(SettingsValidation(genYear2.Text))
                    if(GeneratorChoicebox.SelectedItem != null)
                    {
                        string selectedCalendarsName = GeneratorChoicebox.SelectedItem.ToString();
                        var correctyear = calendars.First(x => x.CalendarName == selectedCalendarsName);

                        int j, n;
                        j = Convert.ToInt32(genYear1.Text);
                        n = Convert.ToInt32(genYear2.Text);

                        List<CalendarEntity> GeneratedCalendar = new List<CalendarEntity>();

                        if (j < n)
                        {
                            for (int k = j; j <= n; j++)
                            {
                                GeneratedCalendar.Add(new CalendarYear(correctyear, k));
                            }
                        }
                        else
                            MessageBox.Show("Dates go from small to big!", "Woops!");

                        MessageBox.Show("Generation worked! Attempting save", "Woops?");

                        GeneratorsFilePeon.SaveToXML(GeneratedCalendar, selectedCalendarsName);
                    }
        }
    }
}
