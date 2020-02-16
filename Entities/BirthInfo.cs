using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BorodaikevychZodiac.Entities
{
  public class BirthInfo
  {
    public DateTime BirthDate { get; private set; }

    public string BirthDateString
    {
      set
      {
        DateTime.TryParseExact(value, "dd-MM-yyyy", CultureInfo.InvariantCulture,
          DateTimeStyles.None, out var date);

        
        BirthDate = date <= DateTime.Today ? date : default;
      }

      get => BirthDate == DateTime.MinValue ? "" : BirthDate.ToString("dd-MM-yyyy");
    }

    public int Age
    {
      get
      {
        if (BirthDate == default) return -1;
        var today = DateTime.Now;
        var age = today.Year - BirthDate.Year;
        if (BirthDate > today.AddYears(-age)) age--;
        return age;
      }
    }

    public bool IsBornToday
    {
      get
      {
        var today = DateTime.Today;
        return BirthDate.Day == today.Day && BirthDate.Month == today.Month;
      }
    }
  }
}
