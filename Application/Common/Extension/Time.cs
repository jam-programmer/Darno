using System;
using System.Collections.Generic;
using System.Globalization;
using Application.Common.Extension;

namespace Application.Common.Extension;

public static class Time
{
    public static DateTime ConvertToGregorian(this string persianDate)
    {
       
        var parts = persianDate.ConvertPersianToEnglish().Split('/');
        if (parts.Length != 3)
        {
            throw new FormatException("فرمت تاریخ ورودی نادرست است. فرمت صحیح: yyyy/MM/dd");
        }

        int year = int.Parse(parts[0].ConvertPersianToEnglish());
        int month = int.Parse(parts[1].ConvertPersianToEnglish());
        int day = int.Parse(parts[2].ConvertPersianToEnglish());

        PersianCalendar persianCalendar = new PersianCalendar();
        DateTime gregorianDate = persianCalendar.ToDateTime(year, month, day, 0, 0, 0, 0);

        return gregorianDate;
    }

    public static DateTime ConvertToGregorianWithTime(this string persianDateTimeString)
    {
        
        var parts = persianDateTimeString.Split(new[] { " - " }, StringSplitOptions.None);
        if (parts.Length != 2)
        {
            throw new FormatException("فرمت تاریخ معتبر نیست.");
        }

       
        string persianDate = parts[0].Trim();
        string time = parts[1].Trim();

      
        var dateParts = persianDate.Split('/');
        if (dateParts.Length != 3)
        {
            throw new FormatException("فرمت تاریخ شمسی معتبر نیست.");
        }

        int year = int.Parse(dateParts[0].ConvertPersianToEnglish());
        int month = int.Parse(dateParts[1].ConvertPersianToEnglish());
        int day = int.Parse(dateParts[2].ConvertPersianToEnglish());

        PersianCalendar persianCalendar = new PersianCalendar();
        DateTime dateTime = new DateTime(year, month, day,
                                          int.Parse(time.Split(':')[0].ConvertPersianToEnglish()),
                                          int.Parse(time.Split(':')[1].ConvertPersianToEnglish()),
                                          int.Parse(time.Split(':')[2].ConvertPersianToEnglish()),
                                          persianCalendar);

        return dateTime;
    }


    public static string GregorianDate(this DateOnly date)
    {
        DateTime dateTime = date.ToDateTime(TimeOnly.MinValue);
  
        return $"{dateTime.Year}-{dateTime.Month}-{dateTime.Day}";
    }


     public static string GregorianDate(this DateTime dateTime)
    {
      
  
        return $"{dateTime.Year}-{dateTime.Month}-{dateTime.Day}  {dateTime.Hour}:{dateTime.Minute}:{dateTime.Second}";
    }




    public static string PersianDate(this DateOnly date)
    {
        PersianCalendar persianCalendar = new PersianCalendar();
        DateTime dateTime = date.ToDateTime(TimeOnly.MinValue);
        int year = persianCalendar.GetYear(dateTime);
        int month = persianCalendar.GetMonth(dateTime);
        int day = persianCalendar.GetDayOfMonth(dateTime);
        return $"{year}/{month}/{day}";
    }




    public static string PersianTime(this DateTime time)
    {
        PersianCalendar persianCalendar = new PersianCalendar();
      
        int hour = persianCalendar.GetHour(time);
        int minute = persianCalendar.GetMinute(time);
        int second = persianCalendar.GetSecond(time);
        var timeConverted = $"{hour}:{minute}:{second}";
        return timeConverted;
    }
    public static string PersianDateWithTime(this DateTime time)
    {
        PersianCalendar persianCalendar = new PersianCalendar();
        int year = persianCalendar.GetYear(time);
        int month = persianCalendar.GetMonth(time);
        int day = persianCalendar.GetDayOfMonth(time);
        int hour = persianCalendar.GetHour(time);
        int minute = persianCalendar.GetMinute(time);
        int second = persianCalendar.GetSecond(time);
        var timeConverted = $"{year}/{month}/{day} - {hour}:{minute}:{second}";
        return timeConverted;
    }
    public static string PersianDateWithOutTime(this DateTime time)
    {
        PersianCalendar persianCalendar = new PersianCalendar();
        int year = persianCalendar.GetYear(time);
        int month = persianCalendar.GetMonth(time);
        int day = persianCalendar.GetDayOfMonth(time);
        var timeConverted = $"{year}/{month}/{day}";
        return timeConverted;
    }
}