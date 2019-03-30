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
        CalendarSettings ourCalendar;
        Filepeon GeneratorsFilePeon;
        private int guiState;

        public GeneratorForm()
        {
            InitializeComponent();

            GeneratorsFilePeon = new Filepeon();
            guiState = 0; // I dunno if this is a good way of using UI, but its the way I thought of while working
        }

        #region Our 3 main buttons
        private void NextInput_Click(object sender, EventArgs e)
        {
            if (guiState == 0)
            {// This large if only checks validation, there's 4 inputs making it large.
                if (Validation_NameInput(nameInput) && Validation_NumberInput(MonthInput) && Validation_NumberInput(DayInput) && Validation_NumberInput(HourInput) 
                    && Validation_SensibleCalendarSizes(MonthInput) && Validation_SensibleCalendarSizes(DayInput) && Validation_SensibleCalendarSizes(HourInput))
                {
                    ourCalendar = new CalendarSettings(nameInput.Text, Convert.ToInt32(MonthInput.Text), 
                                                        Convert.ToInt32(DayInput.Text), Convert.ToInt32(HourInput.Text));
                    if (Validation_Debug())
                    {
                        ourCalendar.SetHourName("Bell", "Bells");
                        ourCalendar.SetMonthName("Hammer", 0); ourCalendar.SetMonthName("Alturiak", 1); ourCalendar.SetMonthName("Ches", 2);
                        ourCalendar.SetMonthName("Tarsakh", 3); ourCalendar.SetMonthName("Mirtul", 4); ourCalendar.SetMonthName("Kythorn", 5);
                        ourCalendar.SetMonthName("Flamerule", 6); ourCalendar.SetMonthName("Eleasis", 7); ourCalendar.SetMonthName("Eleint", 8);
                        ourCalendar.SetMonthName("Marpenoth", 9); ourCalendar.SetMonthName("Uktar", 10); ourCalendar.SetMonthName("Nightal", 11);

                        ourCalendar.LeapYearDayName = "Shieldmeet";
                    }

                    PanelSwapping(Progress_Calendar_Creation);
                    guiState = 1;

                    return;
                }
                else
                {
                    MessageBox.Show("Input error!", "Retry or quit, I'm not your boss.");
                }
            }
            if (guiState == 1)
            {

                if (Validation_NumberInput(hDaysinput) && Validation_NameInput(HourNameInput))
                {
                    ourCalendar.SetHolidays(Convert.ToInt32(hDaysinput.Text));
                    ourCalendar.SetHourName(HourNameInput.Text, HourNameInput.Text + "s");

                    PanelSwapping(Progress_Calendar_Creation);
                    guiState = 2;

                    return;
                }
                else
                {
                    MessageBox.Show("Input error!", "Retry or quit, I'm not your boss.");
                }
            }
            if (guiState == 2)
            {
                if (Validation_NumberInput(leapYearInput1))
                {
                    int monthWhereLeapOccurs = ourCalendar.GetMonthNr(leapYearMonth1.SelectedItem.ToString());

                    monthWhereLeapOccurs++;

                    int leapDay = (monthWhereLeapOccurs * ourCalendar.DaysInMonth) +1;

                    ourCalendar.SetLeapYears(Convert.ToInt32(leapYearInput1.Text), leapDay);

                    PanelSwapping(Progress_Calendar_Creation);
                    guiState = 3;

                    Progress_Calendar_Creation.Text = "Save and quit";

                    return;
                }
                else
                    MessageBox.Show("Input error!", "Retry or quit, I'm not your boss.");
            }
            if (guiState == 3)
            {
                //FINALLYYYYY GET TO SAVING & QUITT.
                const string saveAndExitMessage = "Are you sure you want to save and exit the generator?";
                const string saveAndQuit = "You're saving & Quitting!";

                var result = MessageBox.Show(saveAndExitMessage, saveAndQuit, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                    System.Media.SystemSounds.Exclamation.Play();
                else if (result == DialogResult.Yes)
                {
                    this.Enabled = false;

                    string filename = ourCalendar.CalendarName + " Calendar settings.xml";

                    GeneratorsFilePeon.SerializeAndSaveCalendarSettings(ourCalendar, filename);

                    this.Dispose();
                }

            }
        }

        private void PanelSwapping(Button button)
        {
            if (button.Name == "Progress_Calendar_Creation")
            {
                if (guiState == 0)
                {
                    panel1.Visible = false;
                    panel1_tutorial.Visible = false;

                    panel2_tutorial.Visible = true;
                    panel2.Visible = true;

                    if (checkbox_monthsNamesToBeSet.Checked)
                    {
                        comboBoxMonthNaming.Enabled = true;
                        MonthNameInput.Enabled = true;
                    }
                    else
                    {
                        comboBoxMonthNaming.Enabled = false;
                        MonthNameInput.Enabled = false;
                    }
                    if (checkbox_setCustomHourName.Checked)
                        HourNameInput.Enabled = true;
                    else
                        HourNameInput.Enabled = false;
                    if (checkbox_hdays.Checked)
                        hDaysinput.Enabled = true;
                    else
                        hDaysinput.Enabled = false;

                    Panel2enabled_true(this, EventArgs.Empty);
                    Regress_Calendar_Creation.Enabled = true;
                }
                if (guiState == 1)
                {
                    panel2.Visible = false;
                    panel2_tutorial.Visible = false;

                    panel3_tutorial.Visible = true;
                    panel3.Visible = true;

                    if (checkbox_leapyears.Checked && checkbox_hdays.Checked)
                    {
                        panel3.Enabled = true;
                    }
                    else
                        panel3.Enabled = false;

                    if(checkbox_leapyears.Checked)
                    {
                        leapYearInput1.Enabled = true;
                        leapYearMonth1.Enabled = true;
                        leapYearMonth2.Enabled = true;
                    }
                    else
                    {
                        leapYearInput1.Enabled = false;
                        leapYearMonth1.Enabled = false;
                        leapYearMonth2.Enabled = false;
                    }

                    if (checkbox_hdays.Checked)
                    {
                        HdaySelectorBox.Enabled = true;
                        hdayMonthSelector1.Enabled = true;
                        hdaySelector2.Enabled = true;
                        hDayNameInput.Enabled = true;
                    }
                    else
                    {
                        HdaySelectorBox.Enabled = false;
                        hdayMonthSelector1.Enabled = false;
                        hdaySelector2.Enabled = false;
                        hDayNameInput.Enabled = false;
                    }
                }
                if (guiState == 2)
                {
                    panel3.Visible = false;
                    panel3_tutorial.Visible = false;

                    panel4_tutorial.Visible = true;
                }
            }
            if (button.Name == "Regress_Calendar_Creation")
            {
                if (guiState == 0)
                {
                    panel2_tutorial.Visible = false;
                    panel2.Visible = false;

                    panel1.Visible = true;
                    panel1_tutorial.Visible = true;

                    Regress_Calendar_Creation.Enabled = false;
                }
                if (guiState == 1)
                {
                    panel3_tutorial.Visible = false;
                    panel3.Visible = false;

                    panel2.Visible = true;
                    panel2_tutorial.Visible = true;
                }
                if (guiState == 2)
                {
                    panel4_tutorial.Visible = false;

                    panel3.Visible = true;
                    panel3_tutorial.Visible = true;
                }
            }
        }

        private void Regress_Calendar_Creation_Click(object sender, EventArgs e)
        {
            if (guiState == 1)
            {
                guiState--;
                PanelSwapping(Regress_Calendar_Creation);
            }
            if (guiState == 2)
            {
                guiState--;
                PanelSwapping(Regress_Calendar_Creation);
            }
            if (guiState == 3)
            {
                guiState--;
                PanelSwapping(Regress_Calendar_Creation);
                Progress_Calendar_Creation.Text = "Next";
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        #endregion

        #region Panel2
        private void Panel2enabled_true(object sender, EventArgs e)
        {
            comboBoxMonthNaming.Items.Clear();

            for (int i = 1; i <= ourCalendar.MonthsInYear; i++)
                comboBoxMonthNaming.Items.Add(i);

            comboBoxMonthNaming.SelectedIndex = 0;

            if (guiState != 0)
                Regress_Calendar_Creation.Enabled = true;
            else
                Regress_Calendar_Creation.Enabled = false;
        }

        private void Panel2Combobox_changed(object sender, EventArgs e)
        { 
            MonthNameInput.Clear();
            if (Convert.ToInt32(comboBoxMonthNaming.SelectedItem) -1 >= 0)
                MonthNameInput.Text = ourCalendar.MonthNames[Convert.ToInt32(comboBoxMonthNaming.SelectedItem)-1];
            else
                MonthNameInput.Text = ourCalendar.MonthNames[Convert.ToInt32(comboBoxMonthNaming.SelectedItem)];
        }

        private void Panel2Combobox_listselected(object sender, EventArgs e)
        {
            ourCalendar.SetMonthName(MonthNameInput.Text, Convert.ToInt32(comboBoxMonthNaming.SelectedItem));
        }
        #endregion

        //Everything in this region are eventhandlers. Everything in panel3 is invoked by corresponding events.
        #region Panel3

        /// <summary>
        /// "Startup" refresh and setup of already set data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Panel3OnVisibleChange(object sender, EventArgs e)
        {
            leapYearMonth1.Items.Clear();
            leapYearMonth2.Clear();

            hdayMonthSelector1.Items.Clear();
            hdaySelector2.Clear();
            HdaySelectorBox.Items.Clear();

            hdaySelector2.Enabled = false;

            foreach (string name in ourCalendar.MonthNames)
            {
                leapYearMonth1.Items.Add(name);
                hdayMonthSelector1.Items.Add(name);
            }

            leapYearMonth1.SelectedIndex = 0;
            hdayMonthSelector1.SelectedIndex = 0;

            for (int i = 1; i <= ourCalendar.HolidaysAmount; i++)
                HdaySelectorBox.Items.Add(i);

            HdaySelectorBox.SelectedIndex = 0;

            OnLeapYearSelectorCommit(this, EventArgs.Empty);
        }

        private void OnLeapYearSelectorCommit(object sender, EventArgs e)
        {
            leapYearMonth2.Clear();

            int selectedMonth = ourCalendar.GetMonthNr(leapYearMonth1.SelectedItem.ToString());

            selectedMonth++;

            if (selectedMonth < 1000 && selectedMonth != 12)
            {
                leapYearMonth2.Text = ourCalendar.MonthNames[selectedMonth];
            }
            if (selectedMonth == 12)
            {
                leapYearMonth2.Text = ourCalendar.MonthNames[0];
            }

        }

        private void OnHdaySelectorCommit(object sender, EventArgs e)
        {
            hdaySelector2.Clear();

            int selectedMonth = ourCalendar.GetMonthNr(hdayMonthSelector1.SelectedItem.ToString());

            selectedMonth++;

            if (selectedMonth < 1000 && selectedMonth != 12)
            {   
                hdaySelector2.Text = ourCalendar.MonthNames[selectedMonth];
            }
            if (selectedMonth == 12)
            {
                hdaySelector2.Text = ourCalendar.MonthNames[0];
            }

        }

        private void OnHolidayNRSelectorCommit(object sender, EventArgs e)
        {
            hDayNameInput.Clear();
        }

        private void OnHolidayNRSelectorChange(object sender, EventArgs e)
        {
            hDayNameInput.Text = ourCalendar.GetAHolidayName(Convert.ToInt32(HdaySelectorBox.SelectedItem));
        }

        private void OnNeedToSaveHoliday(object sender, EventArgs e)
        {
            ourCalendar.SaveAHoliday(Convert.ToInt32(HdaySelectorBox.SelectedItem), hDayNameInput.Text);

            int selectedMonth = ourCalendar.GetMonthNr(hdayMonthSelector1.SelectedItem.ToString());

            selectedMonth++;

            selectedMonth = (selectedMonth * ourCalendar.DaysInMonth) + 1;

            ourCalendar.SetHolidayDate(Convert.ToInt32(HdaySelectorBox.SelectedItem), selectedMonth);
        }

        #endregion

        #region Panel4

        private void OnPanel4VisibilityChange(object sender, EventArgs e)
        {
            infoDumpBeforeSave.Text = ourCalendar.ToString();
        }

        #endregion

        #region Input validation
        /// <summary>
        /// Validates that the text isn't too short
        /// </summary>
        /// <returns>True if input complies with constraints & no exceptions are thrown converting fields wich expect numbers</returns>
        private bool Validation_NameInput(TextBox item)
        {
            if (item.Text.Length <= 0 && item.Text.Length < 4)
                return false;

            return true;
        }

        /// <summary>
        /// Checks if a textbox has a convertible number in it
        /// </summary>
        /// <param name="item">Textbox with text in it</param>
        /// <returns>False if it doesn't convert, true if it do</returns>
        private bool Validation_NumberInput(TextBox item)
        {
            try
            {
                Convert.ToInt32(item.Text);
            }
            catch (FormatException)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if the calendar being setup isn't too crazy.
        /// </summary>
        /// <param name="item">1 of 3 textboxes, monthinput, dayinput or hourinput</param>
        /// <returns>True if values are not 0 & within a range</returns>
        private bool Validation_SensibleCalendarSizes(TextBox item)
        {
            if (item.Name == "MonthInput" || item.Name == "DayInput" || item.Name == "HourInput")
            {
                if (item.Name == "MonthInput")
                {
                    if (Convert.ToInt32(item.Text) == 0 && Convert.ToInt32(MonthInput.Text) > 300)
                        return false;
                }
                if (item.Name == "DayInput")
                {
                    if (Convert.ToInt32(DayInput.Text) == 0 && Convert.ToInt32(DayInput.Text) > 3000)
                        return false;
                }
                if (item.Name == "HourInput")
                {
                    if (Convert.ToInt32(HourInput.Text) == 0 && Convert.ToInt32(HourInput.Text) > 100)
                        return false;
                }
            }
            else
                return false;

            return true;
        }

        /// <summary>
        /// Validation to please the big CW
        /// </summary>
        /// <returns></returns>
        private bool Validation_Debug()
        {
            if (ourCalendar.CalendarName == "Forgotten realms")
                if (ourCalendar.MonthsInYear == 12)
                    if (ourCalendar.DaysInMonth == 30)
                        if (ourCalendar.HoursInDay == 24)
                            return true;

            return false;
        }

        #endregion
        
    }
}
