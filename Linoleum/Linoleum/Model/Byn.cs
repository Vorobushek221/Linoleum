using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Linoleum.Model
{
    public class Byn
    {
        public long Rubbles
        {
            get
            {
                return (long)Math.Truncate(sum);
            }
            set
            {
                sum = value;
            }
        }

        public short Kopeck
        {
            get
            {
                var integralPart = Math.Truncate((sum - Math.Truncate(sum)) *100);
                return (short)integralPart;
            }
            set
            {
                sum += (decimal)value / 100;
            }
        }

        private decimal sum;

        public static Byn GetInstance(string sumString)
        {
            if (Regex.IsMatch(sumString, @"^\d+((\.|,)\d+)?$"))
            {
                return new Byn(sumString);
            }
            else
            {
                return null;
            }
        }

        public static Byn GetInstance(decimal sumDecimal)
        {
            if(sumDecimal >= 0m)
            {
                return new Byn(sumDecimal);
            }
            else
            {
                return null;
            }
        }

        private Byn(decimal sum)
        {
            this.sum = Math.Round(sum, 2);
        }

        private Byn(string stringSum)
        {
            decimal parsedSum = 0m;
            parsedSum = decimal.Parse(stringSum
                .Replace(".", CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator)
                .Replace(",", CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator), 
                CultureInfo.InvariantCulture);
            sum = parsedSum;
        }

        public string ToString(BynStringFormat format = BynStringFormat.dot)
        {
            string rubbles = Rubbles.ToString();
            string kopeck = (Kopeck.ToString().Length > 1) ? Kopeck.ToString() : (Kopeck.ToString() + "0");
            switch (format)
            {
                case BynStringFormat.dot:
                    return rubbles + "." + kopeck;

                case BynStringFormat.comma:
                    return rubbles + "," + kopeck;

                default:
                    return rubbles + "." + kopeck;
            }
        }

        public override string ToString()
        {
            string rubbles = Rubbles.ToString();
            string kopeck = (Kopeck.ToString().Length > 1) ? Kopeck.ToString() : (Kopeck.ToString() + "0");
            return rubbles + "." + kopeck;
        }

    }
}
