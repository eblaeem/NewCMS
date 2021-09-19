using System;
using System.Globalization;

namespace CMS
{
    public static class PersianCalendarDate
    {
        public static string ToShamsi(this DateTime value)
        {
            PersianCalendar pc = new();
            return pc.GetYear(value) + "/"
                    + pc.GetMonth(value).ToString("00") + "/"
                    + pc.GetDayOfMonth(value).ToString("00")
                    + pc.GetHour(value).ToString("00") + ":"
                    + pc.GetMinute(value).ToString("00") + ":"
                    + pc.GetSecond(value).ToString("00");
        }
    }
}
