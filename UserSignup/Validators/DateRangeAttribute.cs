using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserSignup.Validators
{
    public class DateRangeAttribute:ValidationAttribute
    {
        private readonly DateTime _minDate;
        private readonly DateTime _maxDate;

        public DateRangeAttribute(string minDate, string maxDate)
        {
            _minDate = DateTime.Parse(minDate);
            _maxDate = DateTime.Parse(maxDate);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime date)
            {
                if (date < _minDate || date > _maxDate)
                {
                    return new ValidationResult($"Date must be between {_minDate:d} and {_maxDate:d}");
                }
            }
            return ValidationResult.Success;
        }
    }
}