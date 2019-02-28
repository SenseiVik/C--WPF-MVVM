using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FinalProject.Infrastructure.Validator
{
    public class IntegerValidatorRule : ValidationRule
    {
        private int max = Int32.MaxValue;
        private int min = Int32.MinValue;

        public int Max
        {
            get => max;
            set => max = value;
        }

        public int Min
        {
            get => min;
            set => min = value;
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int _value;
            try
            {
                _value = Int32.Parse(value.ToString(), NumberStyles.Any, cultureInfo.NumberFormat);
            }
            catch
            {
                return new ValidationResult(false, $"Incorrect input. Need number between {Min} and {Max}");
            }

            if (_value >= Min && _value <= Max)
                return new ValidationResult(true, null);
            else
                return new ValidationResult(false, $"Need number between {Min} and {Max}");
        }
    }
}
