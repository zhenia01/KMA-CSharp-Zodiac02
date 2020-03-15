using System;
using System.Threading.Tasks;

namespace BorodaikevychZodiac.Entities
{
  internal class BirthInfo
  {
    private DateTime _birthDate;

    public DateTime BirthDate
    {
      get => _birthDate;
      set { Task.Run(() => CalculateBirthInfo(value)); }
    }

    private async Task CalculateBirthInfo(DateTime value)
    {
      await Task.Run(() =>
      {
        var today = DateTime.Now;
        var age = today.Year - value.Year;
        if (value > today.AddYears(-age)) age--;

        if (age >= 0 && age <= 135)
        {
          _birthDate = value;
          IsBornToday = _birthDate.Day == today.Day && _birthDate.Month == today.Month;
          Age = age;
        }
      });
    }

    public int Age { get; private set; } = -1;

    public bool IsBornToday { get; private set; }
  }
}