using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BorodaikevychZodiac.Entities
{
  public class BirthInfo
  {
    private DateTime? _birthDate;


    public string BirthDateString
    {
      set
      {
        DateTime.TryParseExact(value, "dd-MM-yyyy", CultureInfo.InvariantCulture,
          DateTimeStyles.None, out var date);

        _birthDate = date;
      }

      get
      {
        if (_birthDate == null)
        {
          return null;
        }

        var date = _birthDate.Value.Date;

        if (date == DateTime.MinValue)
        {
          return "";
        }

        return date.ToString("dd-MM-yyyy");
      }
    }

    public int Age
    {
      get
      {
        if (string.IsNullOrEmpty(BirthDateString) || _birthDate == null) return -1;
        var today = DateTime.Now;
        var age = today.Year - _birthDate.Value.Year;
        if (_birthDate.Value.Date > today.AddYears(-age)) age--;
        return age;
      }
    }

    public bool IsBornToday
    {
      get
      {
        if (_birthDate == null) return false;
        var date = _birthDate.Value.Date;
        var today = DateTime.Today;
        return date.Day == today.Day && date.Month == today.Month;
      }
    }
  }
}
