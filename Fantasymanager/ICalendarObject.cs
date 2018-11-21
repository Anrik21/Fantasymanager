using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantasymanager
{
    public struct CustomDate
    {
        public int y, m, d, h;
        string date;

        public CustomDate(int year, int month, int day, int hour)
        {
            y = year;
            m = month;
            d = day;
            h = hour;

            date = y.ToString() + "-" + m.ToString() + "-" + d.ToString();
        }

        public override string ToString()
        { 
            return date;
        }
    }

    interface ICalendarObject<T>
    {
        List<T> GetCollectionOfDates();
        //CalendarEvent GetCalendarEvent();
    }

    abstract class CalendarEntity : ICalendarObject<CalendarEntity>
    {
        abstract public List<CalendarEvent> GetObjectEvents();
        //abstract public CustomDates GetDate();
        public abstract List<CalendarEntity> GetCollectionOfDates();
        //public abstract CalendarEvent GetCalendarEvent();
    }
}