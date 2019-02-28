using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FinalProject.Infrastructure.Validator
{
    public class ColorValidatorRule : ValidationRule
    {
        
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            foreach (PropertyInfo property in typeof(Colors).GetProperties())
                if (property.PropertyType == typeof(Color))
                    if (property.Name.ToLower() == value.ToString().ToLower())
                        return new ValidationResult(true, null);

            return new ValidationResult(false, "Unknown color");
        }
    }
}
