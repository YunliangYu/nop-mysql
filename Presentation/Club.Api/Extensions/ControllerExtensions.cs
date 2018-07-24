using System;
using System.Text.RegularExpressions;

namespace Club.Web.Extensions
{
    //here we have some methods shared between controllers
    public static class ControllerExtensions
    {
        public static string ConvertToString(this string value)
        {
            return String.IsNullOrWhiteSpace(value) ? string.Empty : value;
        }

        public static int ConvertToInt(this int value)
        {
            return value < 0 ? 0 : value;
        }

        public static string ConvertToDate(this DateTime? value)
        {
            if (value.HasValue)
            {
                var datetime = Convert.ToDateTime(value);
                return datetime.ToString("yyyy/MM/dd");
            }
            return string.Empty;
        }
        public static string ConvertToDateTime(this DateTime? value)
        {
            if (value.HasValue)
            {
                var datetime = Convert.ToDateTime(value);
                return datetime.ToString("yyyy/MM/dd HH:mm:dd");
            }
            return string.Empty;

        }

        public static string ConvertToHHWithDate(int year, int month, int day, int hour, int minutes, int second)
        {
            DateTime dtBeginTime = new DateTime(year, month, day, hour, minutes, second);
            return dtBeginTime.ToString("HH");
        }

        public static string MinutesToHourFormat(this int value)
        {
            return string.Format("{0}小时{1}分", value / 60, value % 60);
        }
        public static string ToHourOrMinuteFormat(this int value)
        {

            if (value < 10)
            {
                return string.Format("0{0}", value);
            }
            else
            {
                return value.ToString();
            }
        }

        public static string GetLongitude(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return "0";
            }
            else
            {
                var longitude = value.Split(',')[0];
                return longitude;
            }
        }

        public static string GetLatitude(this string value)
        {

            if (string.IsNullOrWhiteSpace(value))
            {
                return "0";
            }
            else
            {
                var latitude = value.Split(',')[1];
                return latitude;
            }
        }

        public static string ConvertImageTakeHost(this string value, string hostUrl)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;
            Regex r = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);
            string replaceStr = string.Empty;
            MatchCollection col = r.Matches(value);
            foreach (Match item in col)
            {
                replaceStr = item.Groups["imgUrl"].Value;
                if (replaceStr.ToLower().Contains("http"))
                    continue;
                var newUrl = hostUrl + replaceStr;
                value = value.Replace(replaceStr, newUrl);
            }
            return value;
        }
    }
}