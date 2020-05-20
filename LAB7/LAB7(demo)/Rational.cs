using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Numerics;
using System.Text.RegularExpressions;


namespace LAB7_demo_
{
    public class Rational : IEquatable<Rational>, IComparable<Rational>, IFormattable
    {
        protected long n, m;

        public long N
        {
            get
            {
                return n;
            } 
            private set
            {
                n = value;
            }
        }

        public long M 
        {
            get
            {
                return m;
            }
            private set
            {
                m = value;
            }
        }

        public Rational(long n)
        {
            N = n;
            M = 1;
        }

        public Rational(double value)
        {
            Rational r = value;
            N = r.N;
            M = r.M;
        }

        public Rational(string str)
        {
            Rational r = Parse(str);
            N = r.N;
            M = r.M;
        }

        public Rational(long n, long m)
        {
            N = n;
            M = m;
            CutBack();
        }

        public static long Nod(long n, long m)
        {
            long p = 0;
            n = Math.Abs(n);
            m = Math.Abs(m);
            if (m > n)
            {
                p = n;
                n = m;
                m = p;
            }
            if (m == 0)
            {
                return (n);
            }
            do
            {
                p = n % m;
                n = m;
                m = p;
            } while (m != 0);
            return (n);
        }

        void CutBack()
        {
            long d = Math.Abs(Nod(N, M)) * Math.Sign(M);
            N /= d;
            M /= d;
        }

        public static long Nok(long first, long second)
        {
            long result = first / Nod(first, second) * second;
            return (result);
        }

        public static Rational operator -(Rational first)
        {
            return new Rational(-first.N, first.M);
        }

        public static Rational operator +(Rational first, Rational second)
        {
            long nok = Nok(first.M, second.M);
            return new Rational(nok / first.M * first.N + nok / second.M * second.N, nok);
        }

        public static Rational operator -(Rational first, Rational second)
        {
            return first + (-second);
        }

        public static Rational operator *(Rational first, Rational second)
        {
            Rational r1 = new Rational(first.N, second.M);
            Rational r2 = new Rational(second.N, first.M);
            return new Rational(r1.N * r2.N, r1.M * r2.M);
        }

        public Rational Reverse()
        {
            return new Rational(M, N);
        }

        public static Rational operator /(Rational first, Rational second)
        {
            return first * second.Reverse();
        }

        public static Rational Pow(Rational first, int pow)
        {
            if (pow < 0)
            {
                return Pow(first.Reverse(), -pow);
            }
            else if (pow == 0)
            {
                return 1;
            }
            else if (pow % 2 == 1)
            {
                return Pow(first, pow - 1) * first;
            }
            else
            {
                Rational temp = Pow(first, pow / 2);
                return temp * temp;
            }
        }

        public static Rational Modul(Rational first)
        {
            return new Rational(Math.Abs(first.N), first.M);
        }

        override public int GetHashCode()
        {
            return HashCode.Combine(N, M);
        }

        int CompareModul(Rational first, Rational second)
        {
            long one = first.WholePart();
            long two = second.WholePart();
            int temp = one.CompareTo(two);
            if (temp != 0)
            {
                return temp;
            }
            Rational r1 = first.FractPart();
            if (r1 > 0)
            {
                r1 = r1.Reverse();
            }
            else
            {
                return -1;
            }
            Rational r2 = second.FractPart();
            if (r2 > 0)
            {
                r2 = r2.Reverse();
            }
            else
            {
                return 1;
            }
            return CompareModul(r2, r1);
        }

        public int CompareTo(Rational other)
        {
            if (Equals(other))
            {
                return 0;
            }
            int temp = Sign().CompareTo(other.Sign());
            if (temp != 0)
            {
                return temp;
            }
            if (Sign() == 1)
            {
                return CompareModul(Modul(this), Modul(other));
            }
            return CompareModul(Modul(other), Modul(this));
        }

        public long WholePart()
        {
            return N / M;
        }

        public Rational FractPart()
        {
            return new Rational(N % M, M);
        }

        public int Sign()
        {
            return Math.Sign(N);
        }

        public bool Equals(Rational other)
        {
            return N == other.N && M == other.M;
        }

        public override bool Equals(object obj)
        {
            return obj is Rational && Equals((Rational)obj);
        }

        public static bool operator ==(Rational first, Rational second)
        {
            return Equals(first, second);
        }

        public static bool operator !=(Rational first, Rational second)
        {
            return !Equals(first, second);
        }

        public static bool operator >(Rational first, Rational second)
        {
            return first.CompareTo(second) == 1;
        }

        public static bool operator <(Rational first, Rational second)
        {
            return first.CompareTo(second) == -1;
        }

        public static bool operator >=(Rational first, Rational second)
        {
            return first.CompareTo(second) != -1;
        }

        public static bool operator <=(Rational first, Rational second)
        {
            return first.CompareTo(second) != 1;
        }

        public static Rational Min(Rational first, Rational second)
        {
            if (first < second)
            {
                return first;
            }
            else
            {
                return second;
            }
        }

        public static Rational Max(Rational first, Rational second)
        {
            if (first > second)
            {
                return first;
            }
            else
            {
                return second;
            }
        }

        static public Rational Parse(string str)
        {
            Rational result;
            if (!TryParse(str, out result))
            {
                throw new Exception("Ошибка, невозможно преобразовать");
            }
            return result;
        }

        static public Rational Parse(string format, string str)
        {
            Rational result;
            if (!TryParse(format, str, out result)) 
                throw new Exception("Ошибка, невозможно преобразовать");
            return result;
        }

        static public bool TryParse(string str, out Rational result)
        {
            return TryParse("d", str, out result) || TryParse("f", str, out result);
        }

        static public bool TryParse(string format, string str, out Rational result)
        {
            str = str.Trim();
            result = default;
            switch (format)
            {
                case "a":
                {
                    string pattern = @"^(-?\d+)\s*[/]\s*(\d+)\z";
                    if (!Regex.IsMatch(str, pattern))
                    {
                        return false;
                    }
                    Match match = Regex.Match(str, pattern);
                    long temp1, temp2;
                    if (!long.TryParse(match.Groups[1].Value, out temp1))
                    {
                        return false;
                    }
                    if (!long.TryParse(match.Groups[2].Value, out temp2))
                    {
                        return false;
                    }
                    if (temp2 == 0)
                    {
                        return false;
                    }
                    result = new Rational(temp1, temp2);
                    return true;
                }
                case "b":
                {
                    long temp1;
                    if (!long.TryParse(str, out temp1))
                    {
                        return TryParse("a", str, out result);
                    }
                    result = new Rational(temp1);
                    return true;
                }
                case "c":
                {
                    string pattern = @"^(-?)(\d+)\s+(\d+)\s*[/]\s*(\d+)\z";
                    if (!Regex.IsMatch(str, pattern))
                    {
                        return false;
                    }
                    Match match = Regex.Match(str, pattern);
                    bool isPositive = match.Groups[1].Value != "-";
                    long temp1, temp2, temp3;
                    if (!long.TryParse(match.Groups[2].Value, out temp1))
                    {
                        return false;
                    }
                    if (!long.TryParse(match.Groups[3].Value, out temp2))
                    {
                        return false;
                    }
                    if (!long.TryParse(match.Groups[4].Value, out temp3))
                    {
                        return false;
                    }
                    result = temp1 + new Rational(temp2, temp3);
                    if (!isPositive)
                    {
                        result = -result;
                    }
                    return true;
                }
                case "d":
                {
                    return TryParse("b", str, out result) || TryParse("c", str, out result);
                }
                case "e":
                {
                    return StrToSimple(str, out result);
                }
                case "f":
                {
                    return StrToRat(str, out result);
                }
                default:
                {
                    throw new FormatException("Неизвестный формат");
                }
            }
        }

        public static implicit operator Rational(long value)
        {
            return new Rational(value);
        }

        public static implicit operator Rational((long, long) value)
        {
            return new Rational(value.Item1, value.Item2);
        }

        public static implicit operator Rational(decimal value)
        {
            return Parse("e", value.ToString());
        }

        public static implicit operator Rational(double value)
        {
            return Parse("e", value.ToString());
        }

        public static implicit operator Rational(float value)
        {
            return Parse("e", value.ToString());
        }

        public static explicit operator long(Rational value)
        {
            return value.N / value.M;
        }

        public static explicit operator (long, long)(Rational value)
        {
            return (value.N, value.M);
        }

        public static explicit operator decimal(Rational value)
        {
            return (decimal)value.N / value.M;
        }

        public static explicit operator double(Rational value)
        {
            return (double)value.N / value.M;
        }

        public static explicit operator float(Rational value)
        {
            return (float)value.N / value.M;
        }

        static bool StrToRat(string str, out Rational result)
        {
            string pattern = @"^(-?)(\d+)[.](\d*)[(](\d+)[)]\z";
            if (Regex.IsMatch(str, pattern))
            {
                if (StrToPeriod(str, out result))
                {
                    return true;
                }
                str = str.Replace("(", "");
                str = str.Replace(")", "");
            }
            return StrToSimple(str, out result);
        }

        static bool StrToSimple(string str, out Rational result)
        {
            result = default;
            string pattern = @"^(-?)(\d+)([.](\d+))?\z";
            if (!Regex.IsMatch(str, pattern))
            {
                return false;
            }
            Match match = Regex.Match(str, pattern);
            bool isPositive = match.Groups[1].Value != "-";
            long num;
            if (!long.TryParse(match.Groups[2].Value, out num))
            {
                return false;
            }
            string fracPart = match.Groups[4].Value;
            int i = 0;
            long den = 1;
            while (i < fracPart.Length && den <= 1e17)
            {
                num *= 10;
                num += fracPart[i] - '0';
                den *= 10;
                i++;
            }
            result = (num, den);
            if (!isPositive)
            {
                result = -result;
            }
            return true;
        }

        static bool StrToPeriod(string str, out Rational result)
        {
            result = default;
            string pattern = @"^(-?)(\d+)[.](\d*)[(](\d+)[)]\z";
            if (!Regex.IsMatch(str, pattern))
            {
                return false;
            }
            Match match = Regex.Match(str, pattern);
            bool isPositive = match.Groups[1].Value != "-";
            long wholePart;
            if (!long.TryParse(match.Groups[2].Value, out wholePart))
            {
                return false;
            }
            string strOne = match.Groups[3].Value + match.Groups[4].Value;
            string strTwo = match.Groups[3].Value;
            long one, two;
            if (!long.TryParse(strOne, out one))
            {
                return false;
            }
            if (strTwo == "")
            {
                two = 0;
            }
            else if (!long.TryParse(strTwo, out two))
            {
                return false;
            }
            int n = strOne.Length;
            int k = strOne.Length - strTwo.Length;
            if (n > 18)
            {
                return false;
            }
            result = wholePart + new Rational(one - two, long.Parse(new string('9', k) + new string('0', n - k)));
            if (!isPositive)
            {
                result = -result;
            }
            return true;
        }

        override public string ToString()
        {
            return ToString("b");
        }

        public string ToString(string format, IFormatProvider provider)
        {
            return ToString(format);
        }

        public string ToString(string format)
        {
            if (format == null) format = "b";
            switch (format)
            {
                case "a":
                    return string.Concat(N, "/", M);
                case "b":
                    if (M == 1)
                    {
                        return N.ToString();
                    }
                    return ToString("a");
                case "c":
                    string res = string.Concat(Math.Abs(N / M), " ", Math.Abs(N % M), "/", M);
                    if (N < 0)
                    {
                        res = "-" + res;
                    }
                    return res;
                case "d":
                    if (N / M == 0 || N % M == 0)
                    {
                        return ToString("b");
                    }
                    else
                    {
                        return string.Concat(N / M, " ", Math.Abs(N % M), "/", M);
                    }
                case "e":
                    return ((decimal)N / M).ToString();
                case "f":
                    return RatToStr(N, M);
                default:
                    throw new FormatException("Неизвестный формат");
            }
        }

        private static string RatToStr(long n, long m)
        {
            Dictionary<long, int> d = new Dictionary<long, int>();
            string result = "";
            if (n < 0)
            {
                result = "-";
                n = -n;
            }
            for (int i = 0; i < 100; i++)
            {
                result += n / m;
                long r = n % m;
                if (r == 0)
                {
                    return result;
                }
                int ind;
                if (d.TryGetValue(r, out ind))
                {
                    return result.Insert(ind, "(") + ')';
                }
                if (i == 0)
                {
                    result += ".";
                }
                d.Add(r, result.Length);
                n = r * 10;
            }
            return result + "...";
        }
    }
}
