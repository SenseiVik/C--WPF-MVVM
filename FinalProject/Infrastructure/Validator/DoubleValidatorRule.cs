using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FinalProject.Infrastructure.Validator
{
    public class DoubleValidatorRule : ValidationRule
    {
        private double max = Double.MaxValue;
        private double min = Double.MinValue;

        public double Max
        {
            get => max;
            set => max = value;
        }

        public double Min
        {
            get => min;
            set => min = value;
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double _value;

            try
            {
                _value = Double.Parse(value.ToString(), NumberStyles.Any, cultureInfo.NumberFormat);
            }
            catch
            {
                return new ValidationResult(false, @"Incorrect input. Try '2.4' or '3'");
            }

            if  (_value >= Min && _value <= Max)
                return new ValidationResult(true, null);
            else
                return new ValidationResult(false, $"Need number between {Min} and {Max}");
        }
    }
}
