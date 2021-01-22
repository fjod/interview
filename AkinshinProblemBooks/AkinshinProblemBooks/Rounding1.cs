using System;
using System.Globalization;

namespace AkinshinProblemBooks
{
    public class Rounding1
    {
        //     Math.Round по умолчанию округляет к ближайшему чётному целому.
        //     Math.Floor округляет вниз по направлению к отрицательной бесконечности.
        //     Math.Ceiling округляет вверх по направлению к положительной бесконечности.
        //     Math.Truncate округляет вниз или вверх по направлению к нулю.
        //     String.Format округляет к числу, которое дальше от нуля.
        public void Work()
        {
            Console.WriteLine(
                "| Number | Round | Floor | Ceiling | Truncate | Format |");
            foreach (var x in new[] { -2.9, -0.5, 0.3, 1.5, 2.5, 2.9 })
            {
                Console.WriteLine(
                    string.Format(CultureInfo.InvariantCulture, "| {0,6} | {1,5} | {2,5} | {3,7} | {4,8} | {0,6:N0} |",
                        x, Math.Round(x), Math.Floor(x), Math.Ceiling(x), Math.Truncate(x)));
            }
        }
    }
}