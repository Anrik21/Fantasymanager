using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantasymanager
{
    /// <summary>
    /// This is the class for custom names of your calendarobjects
    /// Shouldn't handle more than naming of the objects.
    /// </summary>
    class CalendarObjects
    {
        public string YearName { get; private set; }
        public string HourName { get; private set; }

        public int MonthsInYear { get; private set; }
        public int DaysInMonth { get; private set; }
        public int HoursInDay { get; private set; }
        /// <summary>
        /// For the creation of the dates. 
        /// </summary>
        /// <param name="date">Always send a date with atleast amount of months in a year, days in a month and hours in day.</param>
        public CalendarObjects(CustomDate date)
        {
            YearName = "Year";
            HourName = "Hour";

            MonthsInYear = date.m;
            DaysInMonth = date.d;
            HoursInDay = date.h;
        }

        public CalendarObjects(CustomDate date, string nameOfYear)
        {
            YearName = nameOfYear;
            HourName = "Hour";

            MonthsInYear = date.m;
            DaysInMonth = date.d;
            HoursInDay = date.h;
        }

        public CalendarObjects(CustomDate date,string nameOfYear, string nameOfHours)
        {
            YearName = nameOfYear;
            HourName = nameOfHours;

            MonthsInYear = date.m;
            DaysInMonth = date.d;
            HoursInDay = date.h;
        }
    }

    class CalendarYear : CalendarEntity
    {
        private List<CalendarEntity> YearsMonths;
        private List<CalendarEvent> YearsEvents;

        public CalendarYear()
        {
            YearsMonths = new List<CalendarEntity>();
            YearsEvents = new List<CalendarEvent>();
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
        private List<CalendarEntity> monthsDays;
        private List<CalendarEvent> monthsEvents;

        public CalendarMonth()
        {
            monthsDays = new List<CalendarEntity>();
            monthsEvents = new List<CalendarEvent>();
        }

        public override List<CalendarEntity> GetCollectionOfDates()
        {
            throw new NotImplementedException();
        }

        public override List<CalendarEvent> GetObjectEvents()
        {
            throw new NotImplementedException();
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
