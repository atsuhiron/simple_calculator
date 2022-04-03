using WpfApp4.Constants;

namespace WpfApp4.Models
{
    public class NumberWithError
    {
        private double? value_;
        public double? Value { 
            get { return value_ ?? 0; } 
            set { value_ = value; }
        }

        private double error_;
        public double Error { 
            get { return error_ ; }
            set { error_ = value; } 
        }

        public NumberWithError(double? value, double error)
        {
            Value = value;
            Error = error;
        }

        public bool IsValid()
        {
            return Value != null && Error >= 0;
        }

        public override string ToString()
        {
            var valStr = Value.ToString();
            return $"{valStr} {Constants.Constants.PM} {Error}";
        }

        public static NumberWithError Add(NumberWithError val1, NumberWithError val2)
        {
            return new NumberWithError(
                val1.Value + val2.Value,
                System.Math.Sqrt(val1.Error * val1.Error + val2.Error * val2.Error)
            );
        }

        public static NumberWithError Sub(NumberWithError val1, NumberWithError val2)
        {
            return new NumberWithError(
                val1.Value - val2.Value,
                System.Math.Sqrt(val1.Error * val1.Error + val2.Error * val2.Error)
            );
        }

        public static NumberWithError Mul(NumberWithError val1, NumberWithError val2)
        {
            return new NumberWithError(
                val1.Value * val2.Value,
                System.Math.Sqrt(System.Math.Pow(val1.Error * (val2.Value ?? 0), 2) + System.Math.Pow(val2.Error * (val1.Value ?? 0), 2))
            );
        }

        public static NumberWithError Div(NumberWithError val1, NumberWithError val2)
        {
            if ((val2.Value ?? 0) == 0)
            {
                return GetNaN();
            }

            var term1 = (val1.Error / val2.Value) ?? 0;
            var term2 = (val2.Error * val1.Value / (val2.Value * val2.Value)) ?? 0;

            return new NumberWithError(
                val1.Value / val2.Value,
                System.Math.Sqrt(System.Math.Pow(term1, 2) + System.Math.Pow(term2, 2))
            );
        }

        public static NumberWithError GetNaN()
        {
            return new NumberWithError(double.NaN, double.NaN);
        }
    }
}
