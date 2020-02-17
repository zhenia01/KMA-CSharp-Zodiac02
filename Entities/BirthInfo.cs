using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BorodaikevychZodiac.Entities
{
  public class BirthInfo
  {
    public DateTime BirthDate { get; set; }

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
