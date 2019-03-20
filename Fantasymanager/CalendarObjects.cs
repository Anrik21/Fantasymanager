using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Fantasymanager
{
    /// <summary>
    /// Handles all relevant info about your calendar & is the backbone of the GUI
    /// </summary>
    public class CalendarSettings
    {
        public string CalendarName { get; private set; }
        public string HourName { get; private set; }
        public List<string> MonthNames { get; private set; }

        public int MonthsInYear { get; private set; }
        public int DaysInMonth { get; private set; }
        public int HoursInDay { get; private set; }

        public int LeapYearOccurence { get; private set; }
        public int LeapYearDay { get; private set; }

        public int HolidaysAmount { get; private set; }
        public List<int> HolidaysDates { get; private set; }
        public List<string> HolidaysNames { get; private set; }

        public int DaysInYear { get; private set; }

        /// <summary>
        /// Creates a setting for your calendar to be generated around.
        /// </summary>
        /// <param name="Name">Your calendars name. Example: "Forgotten realms"</param>
        /// <param name="m">Months in a year</param>
        /// <param name="d">Days in a month</param>
        /// <param name="h">Hours in day</param>
        public CalendarSettings(string Name, int m, int d, int h)
        {
            MonthsInYear = m;
            DaysInMonth = d;
            HoursInDay = h;
            CalendarName = Name;

            DaysInYear = DaysInMonth * MonthsInYear;
            MonthNames = new List<string>(new string[m]);
        }

        public void SetHolidays (int holidays)
        {
            HolidaysAmount = holidays;
            HolidaysDates = new List<int>(holidays);
        }

        public void SetHolidayName(string holidayName, int holidayNR)
        {
            HolidaysNames[holidayNR] = holidayName;
        }

        public void SetMonthName(string monthName, int monthNR)
        {
            MonthNames[monthNR] = monthName;
        }

        /// <summary>
        /// Does what it says on the tin. Might throw Argumentoutofrange exception!
        /// </summary>
        /// <param name="leapOccurence">How often a leap year occurs. Must be greater than 0</param>
        /// <param name="leapDay">On which day of the year the leapday occurs</param>
        public void SetLeapYears(int leapOccurence, int leapDay)
        {
            if (leapOccurence <= 0)
                throw new ArgumentOutOfRangeException($"{nameof(leapOccurence)} must be greater than 0");
            if (leapDay < 1 && leapDay > DaysInYear)
                throw new ArgumentOutOfRangeException($"{nameof(leapOccurence)} must be greater than 0");

            LeapYearOccurence = leapOccurence;
        }

        public override string ToString()
        {
            return "Settings for " + CalendarName;
        }
    }

    public class CalendarYear : CalendarEntity
    {
        public List<CalendarEntity> YearsMonths;
        public List<CalendarEvent> YearsEvents;
        public int YearNumeral;
        public string YearName { get; set; }

        public CalendarYear()
        {
            
        }

        public CalendarYear(CalendarSettings calendarInfo, int ThisYear)
        {
            YearsMonths = new List<CalendarEntity>(calendarInfo.MonthsInYear);
            YearsEvents = new List<CalendarEvent>();
            YearNumeral = ThisYear;

            CalendarMonth tempMonth;
            for (int i = 0; i < YearsMonths.Capacity; i++)
            {
                tempMonth = new CalendarMonth(calendarInfo, i);
                YearsMonths.Add(tempMonth);// = tempMonth;
            }
        }

        public void ChangeYearName(string NewName)
        {
            if (NewName != null)
                YearName = NewName;
            else
                throw new ArgumentNullException();
        }

        public override List<CalendarEntity> GetCollectionOfDates()
        {
            return YearsMonths;
        }

        public override List<CalendarEvent> GetObjectEvents()
        {
            return YearsEvents;
        }
    }

    public class CalendarMonth : CalendarEntity
    {
        public List<CalendarEntity> MonthsDays;
        public List<CalendarEvent> MonthsEvents;
        public string monthName { set; get; }

        public CalendarMonth(){}

        public CalendarMonth(CalendarSettings calendarInfo, int nameNr)
        {
            MonthsDays = new List<CalendarEntity>(calendarInfo.DaysInMonth);
            MonthsEvents = new List<CalendarEvent>();
            monthName = calendarInfo.MonthNames[nameNr];

            CalendarDay tempDay;
            // this is an attempted change
            for (int i = 0; i < calendarInfo.DaysInMonth; i++)
            {
                tempDay = new CalendarDay();
                MonthsDays.Add(tempDay);//= tempDay;
            }
        }

        public void AddEvent(CalendarEvent calendarEvent)
        {
            MonthsEvents.Add(calendarEvent);
        }

        public override List<CalendarEntity> GetCollectionOfDates()
        {
            return MonthsDays;
        }

        public override List<CalendarEvent> GetObjectEvents()
        {
            return MonthsEvents;
        }
    }

    public class CalendarDay : CalendarEntity
    {
        public List<CalendarEvent> DayEvents;
        //private string ObjectID;
        //List<CalendarEntity> CalendarHours;

        public CalendarDay()
        {
            DayEvents = new List<CalendarEvent>();
        }

        public void AddEvent(CalendarEvent calendarEvent)
        {
            DayEvents.Add(calendarEvent);
        }
        
        public override List<CalendarEntity> GetCollectionOfDates()
        {
            throw new NotImplementedException();
        }

        public override List<CalendarEvent> GetObjectEvents()
        {
            return DayEvents;
        }
    }

    public class CalendarEvent 
    {
        public string EventDetails;
        public string EventID;

        public CalendarEvent()
        {

        }

        public CalendarEvent(string eventInfo, string eventName)
        {
            EventDetails = eventInfo;
            EventID = eventName;
        }
    }
    /*
    class CalendarHour : CalendarEntity
    {
        private string ObjectID;
        List<CalendarEntity> HourEvents;
        CalendarEvent HourEvent;
        
        public CalendarHour(CustomDate customDate,int hour)
        {
            customDate.h = hour; // This feels unsafe, but the hour should be assigned here?
            ObjectID = customDate.ToString() + customDate.h.ToString();
            HourEvents = new List<CalendarEntity>();
        }

        public override CalendarEvent GetCalendarEvent()
        {
            return HourEvent;
        }

        public override List<CalendarEntity> GetCollectionOfDates()
        {
            return HourEvents;
        }

        public override string GetObjectIdentifier()
        {
            return ObjectID;
        }
    }
    */

}
