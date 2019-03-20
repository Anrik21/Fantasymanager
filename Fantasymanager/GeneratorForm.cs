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
            guiState = 0;
        }

        #region Our 3 main buttons
        private void NextInput_Click(object sender, EventArgs e)
        {
            if (guiState == 0)
            {
                if (Validation_NameInput(nameInput) && Validation_NumberInput(MonthInput) && Validation_NumberInput(DayInput) && Validation_NumberInput(HourInput) 
                    && Validation_SensibleCalendarSizes(MonthInput) && Validation_SensibleCalendarSizes(DayInput) && Validation_SensibleCalendarSizes(HourInput))
                {
                    ourCalendar = new CalendarSettings(nameInput.Text, Convert.ToInt32(MonthInput.Text), 
                                                        Convert.ToInt32(DayInput.Text), Convert.ToInt32(HourInput.Text));
                    PanelSwapping(Progress_Calendar_Creation);
                    guiState = 1;
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
                    
                    PanelSwapping(Progress_Calendar_Creation);
                    guiState = 2;
                }
                else
                {
                    MessageBox.Show("Input error!", "Retry or quit, I'm not your boss.");
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
                        hdayMonthSelector2.Enabled = true;
                        hDayNameInput.Enabled = true;
                    }
                    else
                    {
                        HdaySelectorBox.Enabled = false;
                        hdayMonthSelector1.Enabled = false;
                        hdayMonthSelector2.Enabled = false;
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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Panel2
        private void Panel2enabled_true(object sender, EventArgs e)
        {
            comboBoxMonthNaming.Items.Clear();
            for (int i = 1; i <= ourCalendar.MonthsInYear; i++)
                comboBoxMonthNaming.Items.Add(i);
        }

        private void Panel2Combobox_changed(object sender, EventArgs e)
        { 
            MonthNameInput.Clear();

            MonthNameInput.Text = ourCalendar.MonthNames[Convert.ToInt32(comboBoxMonthNaming.SelectedItem)];
        }

        private void Panel2Combobox_listselected(object sender, EventArgs e)
        {
            if (MonthNameInput.Text != "")
            {
                ourCalendar.MonthNames[Convert.ToInt32(comboBoxMonthNaming.SelectedItem)] = MonthNameInput.Text;
            }
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

        #endregion

    }
}
