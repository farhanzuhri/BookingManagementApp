namespace API.Utilities.Handler
{
    public class CalculateBookingLengthHandler
    {
        public static int CalculateLength(DateTime StartDate, DateTime EndDate)
        {
            int count = 0;
            for (var i = StartDate; i <= EndDate; i = i.AddDays(1))
            {
                if (i.DayOfWeek != DayOfWeek.Sunday && i.DayOfWeek != DayOfWeek.Saturday)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
