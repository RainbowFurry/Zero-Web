using System;

namespace Zero_Web.Content.csharp.Zero
{
    public class SaleTimer
    {

        //DateTime date1 = new DateTime(2011, 7, 1, 6, 3, 15);//1.1.2011 04.00.15

        public static TimeSpan test(DateTime start, DateTime end)
        {
            return start.Subtract(end);
        }

    }
}