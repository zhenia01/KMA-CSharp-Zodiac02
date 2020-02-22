using System;
using System.Globalization;
using BorodaikevychZodiac.Entities;

namespace BorodaikevychZodiac.Models.User
{
  public class UserModel
  {
    private readonly BirthInfo _birthInfo = new BirthInfo();

    public string BirthDate
    {
      set
      {
        if (DateTime.TryParseExact(value, "dd-MM-yyyy", CultureInfo.InvariantCulture,
          DateTimeStyles.None, out var birthDate))
        {
          _birthInfo.BirthDate = birthDate;
        }

        ChineseZodiacSign = ZodiacSigns.ChineseSign(_birthInfo.BirthDate);
        WesternZodiacSign = ZodiacSigns.WesternSign(_birthInfo.BirthDate);
      }

      get => _birthInfo != default ? _birthInfo.BirthDate.ToString("dd-MM-yyyy") : "";
    }

    public int Age => _birthInfo.Age;

    public bool IsBornToday => _birthInfo.IsBornToday;

    public (string name, string emoji) ChineseZodiacSign { get; private set; }
    public (string name, string emoji) WesternZodiacSign { get; private set; }
  }
}