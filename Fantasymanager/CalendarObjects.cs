using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantasymanager
{
    /// <summary>
    /// This is the class for custom names of your calendarobjects
    /// Handles general info about your calendar
    /// </summary>
    class CalendarObjects
    {
        public string HourName { get; private set; }
        public List<string> MonthNames { get; private set; }

        public int MonthsInYear { get; private set; }
        public int DaysInMonth { get; private set; }
        public int HoursInDay { get; private set; }
        /// <summary>
        /// For the creation of the dates. 
        /// </summary>
        /// <param name="date">Always send a date with atleast amount of months in a year, days in a month and hours in day.</param>
        public CalendarObjects(CustomDate date)
        {
            MonthsInYear = date.m;
            DaysInMonth = date.d;
            HoursInDay = date.h;

            HourName = "Hour";
            MonthNames = new List<string>(MonthsInYear-1);
        }

        public void SetMonthName(int nrInList, string monthName)
        {
            MonthNames[nrInList] = monthName;
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

        public CalendarYear(CalendarObjects calendarInfo)
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

        public CalendarMonth(CalendarObjects calendarInfo)
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
