using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Fantasymanager
{
    /// <summary>
    /// Handles general info about your calendar
    /// </summary>
    public class CalendarSettings
    {
        public string CalendarName { get; private set; }
        public const string HourName = "hour";
        public List<string> MonthNames { get; private set; }

        public int MonthsInYear { get; private set; }
        public int DaysInMonth { get; private set; }
        public int HoursInDay { get; private set; }
       
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
            MonthNames = new List<string>();

            for (int n = 0; n < MonthsInYear; n++)
                MonthNames.Add("Month " + n.ToString());
        }

        /// <summary>
        /// Creates a setting for your calendar to be generated around.
        /// </summary>
        /// <param name="m">Months in a year</param>
        /// <param name="d">Days in a month</param>
        /// <param name="h">Hours in day</param>
        /// <param name="customHourName">A custom name for an hour</param>
        /// <param name="customMonthNames">A string[] of names for months - Changed to list cuz is better.</param>
        public CalendarSettings(string Name, int m, int d, int h, List<string> customMonthNames) : this (Name,m,d,h)
        {
            MonthNames = customMonthNames;
        }

        public void SetMonthName(int nrInList, string monthName)
        {
            MonthNames[nrInList] = monthName;
        }

        public override string ToString()
        {
            return CalendarName;
        }
    }

    public class CalendarYear : CalendarEntity
    {
        [XmlArray(ElementName = "Months", IsNullable = false)]
        public List<CalendarEntity> YearsMonths;

        [XmlArray(ElementName = "Events", IsNullable = false)]
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
