using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace BorodaikevychZodiac.Models.User
{
  internal class ValidBirthDateAttribute : ValidationAttribute
  {
    public string GetErrorMessage() => "Birth Date is not valid";

    public override bool IsValid(object value)
    {
      if (value is string date)
      {
        return DateTime.TryParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture,
          DateTimeStyles.None, out _);
      }
      return false;
    }
  }
}
