using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantasymanager
{
    public struct CustomDates
    {
        public int y, m, d;

        public CustomDates(int year, int month, int day)
        {
            y = year;
            m = month;
            d = day;
        }
    }

    interface ICalendarObject<T>
    {
        CustomDates GetDates { get; set; }
        List<T> CollectionOfDates { get; set;}
        string DateName { get; set; }
        List<T> CollectionOfEvents { get; set; }
    }
}