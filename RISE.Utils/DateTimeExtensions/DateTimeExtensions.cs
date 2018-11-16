namespace RISE.Utils.DateTimeExtensions
{
    using System;

    public static class DateTimeExtensions
    {
        public static DateTime EndOfTheDay(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
        }
    }
}