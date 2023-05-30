internal class Program
{
    private static void Main(string[] args)
    {
        Dictionary<int,int> weekDaySkipPerMonth = new Dictionary<int,int>
        {
            {1 , 3},
            {2 , 3},
            {3 , 0},
            {4 , 3},
            {5 , 2},
            {6 , 3},
            {7 , 2},
            {8 , 3},
            {9 , 3},
            {10 , 2},
            {11 , 3},
            {12 , 2}
        };

        Dictionary<int, int> weekDaySkipPerMonthLeapYear = new Dictionary<int, int>(weekDaySkipPerMonth);
        weekDaySkipPerMonthLeapYear[3]++;

        int currentWeekDay = 6; //December 01, 1900 was a Saturday.
        int totalSundays = 0;

        for (int year = 1901; year < 2001; year++)
        {
            bool isLeapYear = year % 400 == 0 || (!(year % 100 == 0) && year % 4 == 0);
            for (int month = 1; month < 13; month++)
            {
                if (isLeapYear)
                {
                    currentWeekDay = (currentWeekDay + weekDaySkipPerMonthLeapYear[month]) % 7;
                }
                else
                {
                    currentWeekDay = (currentWeekDay + weekDaySkipPerMonth[month]) % 7;
                }
                
                if (currentWeekDay == 0)
                {
                    totalSundays++;
                }
            }
        }
        Console.WriteLine(totalSundays);

    }
}