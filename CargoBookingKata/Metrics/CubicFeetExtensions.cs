using System;
using System.Collections.Generic;
using System.Linq;

namespace CargoBookingKata.Metrics
{
    public static class CubicFeetExtensions
    {
        public static CubicFeet Sum(this IEnumerable<CubicFeet> source)
        {
            return source.Aggregate((x, y) => x + y);
        }

        public static CubicFeet Sum<T>(this IList<T> source, Func<T, CubicFeet> selector)
        {
            return !source.Any() ? new CubicFeet(0) : source.Select(selector).Aggregate((x, y) => x + y);
        }
    }
}
