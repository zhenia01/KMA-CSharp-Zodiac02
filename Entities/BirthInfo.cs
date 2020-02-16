using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BorodaikevychZodiac.Entities
{
  public class BirthInfo
  {
    public DateTime? BirthDate { get; private set; }

    public string BirthDateString
    {
      set
      {
        DateTime.TryParseExact(value, "dd-MM-yyyy", CultureInfo.InvariantCulture,
          DateTimeStyles.None, out var date);

        BirthDate = date;
      }

      get
      {
        if (BirthDate == null)
        {
          return null;
        }

        var date = BirthDate.Value.Date;

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
        if (string.IsNullOrEmpty(BirthDateString) || BirthDate == null) return -1;
        var today = DateTime.Now;
        var age = today.Year - BirthDate.Value.Year;
        if (BirthDate.Value.Date > today.AddYears(-age)) age--;
        return age;
      }
    }

    public bool IsBornToday
    {
      get
      {
        if (BirthDate == null) return false;
        var date = BirthDate.Value.Date;
        var today = DateTime.Today;
        return date.Day == today.Day && date.Month == today.Month;
      }
    }
  }
}
