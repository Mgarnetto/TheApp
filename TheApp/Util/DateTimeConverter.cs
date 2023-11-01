namespace TheApp.Util
{
    public static class DateTimeConverter
    {
        public static string ToDateTimeString(DateTime dateTime)
        {
            return dateTime.ToString("MM-dd-yyyy h:mmtt");
        }
    }
}
