using System;

namespace SABI
{
    public static class DecimalExtensions
    {
        public static decimal TruncateTo(this decimal n, uint digits)
        {
            var wholePart = decimal.Truncate(n);

            var decimalPart = n - wholePart;
            var factor = checked(Math.Pow(10, digits));
            var decimalPartTruncated =
                Math.Truncate(decimalPart * (decimal)factor) / (decimal)factor;

            return wholePart + decimalPartTruncated;
        }
    }
}
