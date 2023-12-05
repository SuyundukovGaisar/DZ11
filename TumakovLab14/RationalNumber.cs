using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TumakovLab14
{
    [DeveloperInfo("Alexandr", "05.12.2023")]
    internal class RationalNumber
    {
        private int numerator;
        private int denominator;
        public RationalNumber(int numerator, int denominator)
        {
            this.numerator = numerator;
            if (denominator == 0)
            {
                Console.WriteLine("Знаменатель не может быть равен нулю");
            }
            else
            {
                this.denominator = denominator;
            }
        }
        public static bool operator ==(RationalNumber r1, RationalNumber r2)
        {
            return (r1.numerator * r2.denominator) == (r2.numerator * r1.denominator);
        }

        public static bool operator !=(RationalNumber r1, RationalNumber r2)
        {
            return (r1.numerator * r2.denominator) != (r2.numerator * r1.denominator);
        }
        public override bool Equals(object obj)
        {
            if (obj is RationalNumber)
                return true;
            else
                return false;
        }
        public static bool operator <(RationalNumber r1, RationalNumber r2)
        {
            return (r1.numerator * r2.denominator) < (r2.numerator * r1.denominator);
        }
        public static bool operator >(RationalNumber r1, RationalNumber r2)
        {
            return (r1.numerator * r2.denominator) > (r2.numerator * r1.denominator);
        }
        public static bool operator <=(RationalNumber r1, RationalNumber r2)
        {
            return (r1.numerator * r2.denominator) <= (r2.numerator * r1.denominator);
        }
        public static bool operator >=(RationalNumber r1, RationalNumber r2)
        {
            return (r1.numerator * r2.denominator) >= (r2.numerator * r1.denominator);
        }
        public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
        {
            int num = (r1.numerator * r2.denominator) + (r2.numerator * r1.denominator);
            int den = r1.denominator * r2.denominator;
            return new RationalNumber(num, den);
        }
        public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
        {
            int num = (r1.numerator * r2.denominator) - (r2.numerator * r1.denominator);
            int den = r1.denominator * r2.denominator;
            return new RationalNumber(num, den);
        }
        public static RationalNumber operator ++(RationalNumber r)
        {
            return r + new RationalNumber(1, 1);
        }
        public static RationalNumber operator --(RationalNumber r)
        {
            return r - new RationalNumber(1, 1);
        }
        public override string ToString()
        {
            return numerator + "/" + denominator;
        }
        public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
        {
            int num = r1.numerator * r2.numerator;
            int den = r1.denominator * r2.denominator;
            return new RationalNumber(num, den);
        }
        public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
        {
            int num = r1.numerator * r2.denominator;
            int den = r1.denominator * r2.numerator;
            return new RationalNumber(num, den);
        }
        public static RationalNumber operator %(RationalNumber r1, RationalNumber r2)
        {
            int num = r1.numerator * r2.denominator;
            int den = r1.denominator * r2.numerator;
            return new RationalNumber(num % den, den);
        }
        //explicit - оператор явного преобразования
        public static explicit operator float(RationalNumber r)
        {
            return (float)r.numerator / r.denominator;
        }
        public static explicit operator int(RationalNumber r)
        {
            return r.numerator / r.denominator;
        }
    }
}
