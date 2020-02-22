using System;

namespace BorodaikevychZodiac.Entities
{
  public class BirthInfo
  {
    private DateTime _birthDate;

    public DateTime BirthDate
    {
      get => _birthDate;
      set
      {
        var today = DateTime.Now;
        var age = today.Year - value.Year;
        if (BirthDate > today.AddYears(-age)) age--;

        if (age >= 0 && age <= 135)
        {
          _birthDate = value;
          IsBornToday = _birthDate.Day == today.Day && _birthDate.Month == today.Month;
          Age = age;
        }
      }
    }

    public int Age { get; private set; } = -1;

    public bool IsBornToday { get; private set; }
  }
}