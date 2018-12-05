using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantasymanager
{
    /// <summary>
    /// Handles general info about your calendar
    /// </summary>
    class CalendarSettings
    {
        public string CalendarName { get; private set; }
        public string HourName { get; private set; }
        public string[] MonthNames { get; private set; }

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

            HourName = "Hour";
            for (int n = 0; n < DaysInMonth; n++)
                MonthNames[n] = "Month " + n.ToString();
        }

        /// <summary>
        /// Creates a setting for your calendar to be generated around.
        /// </summary>
        /// <param name="m">Months in a year</param>
        /// <param name="d">Days in a month</param>
        /// <param name="h">Hours in day</param>
        /// <param name="customHourName">A custom name for an hour</param>
        public CalendarSettings(string Name, int m, int d, int h, string customHourName)
        {
            MonthsInYear = m;
            DaysInMonth = d;
            HoursInDay = h;
            CalendarName = Name;

            HourName = customHourName;
            for (int n = 0; n < DaysInMonth; n++)
                MonthNames[n] = "Month " + n.ToString();
        }
        /// <summary>
        /// Creates a setting for your calendar to be generated around.
        /// </summary>
        /// <param name="m">Months in a year</param>
        /// <param name="d">Days in a month</param>
        /// <param name="h">Hours in day</param>
        /// <param name="customHourName">A custom name for an hour</param>
        /// <param name="customMonthNames">A string[] of names for months</param>
        public CalendarSettings(string Name, int m, int d, int h, string customHourName, string[] customMonthNames)
        {
            MonthsInYear = m;
            DaysInMonth = d;
            HoursInDay = h;
            CalendarName = Name;

            HourName = customHourName;
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
        /*
        public CalendarObjects(CustomDate date, string nameOfHours)
        {
            HourName = nameOfHours;

            MonthsInYear = date.m;
            DaysInMonth = date.d;
            HoursInDay = date.h;
        }*/
    }

    class CalendarYear : CalendarEntity
    {
        private List<CalendarEntity> YearsMonths;
        private List<CalendarEvent> YearsEvents;
        public string YearName { get; private set; }

        public CalendarYear(CalendarSettings calendarInfo)
        {
            YearsMonths = new List<CalendarEntity>(calendarInfo.DaysInMonth-1);
            YearsEvents = new List<CalendarEvent>();

            CalendarMonth tempMonth;
            for (int i = 0; i < YearsMonths.Count; i++)
            {
                tempMonth = new CalendarMonth(calendarInfo);
                YearsMonths[i] = tempMonth;
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

    class CalendarMonth : CalendarEntity
    {
        private List<CalendarEntity> MonthsDays;
        private List<CalendarEvent> MonthsEvents;

        public CalendarMonth(CalendarSettings calendarInfo)
        {
            MonthsDays = new List<CalendarEntity>(calendarInfo.DaysInMonth-1);
            MonthsEvents = new List<CalendarEvent>();

            CalendarDay tempDay;
            for (int i = 0; i < calendarInfo.DaysInMonth; i++)
            {
                tempDay = new CalendarDay();
                MonthsDays[i] = tempDay;
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

    class CalendarDay : CalendarEntity
    {
        List<CalendarEvent> DayEvents;
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

    class CalendarEvent 
    {
        private string EventDetails;
        private string EventID;

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
