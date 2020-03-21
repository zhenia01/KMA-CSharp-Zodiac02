using System;
using System.Globalization;
using System.Threading.Tasks;
using BorodaikevychZodiac.Entities;
using BorodaikevychZodiac.Exceptions;

namespace BorodaikevychZodiac.Models.User
{
  internal class UserModel
  {
    private readonly Person _person = new Person();

    public string BirthDate { get; private set; }

    public async Task SetBirthDateStringAsync(string birthDateString)
    {
      var birthDate = await ParseBirthDateAsync(birthDateString);
      if (birthDate != default)
      {
        BirthDate = birthDateString;
        await _person.SetBirthDateAsync(birthDate);
      }
      else
      {
        throw new InvalidDateFormatException();
      }
    }

    private static Task<DateTime> ParseBirthDateAsync(string birthDate)
    {
      return Task.Run(() =>
      {
        DateTime.TryParseExact(birthDate, "dd-MM-yyyy", CultureInfo.InvariantCulture,
          DateTimeStyles.None, out var result);
        return result;
      });
    }

    public string FirstName
    {
      get => _person.FirstName;
      set => _person.FirstName = value;
    }

    public string LastName
    {
      get => _person.LastName;
      set => _person.LastName = value;
    }

    public string Email
    {
      get => _person.Email;
      set => _person.Email = value;
    }

    public bool IsBornToday => _person.IsBornToday;
    public bool IsAdult => _person.IsAdult;

    public (string name, string emoji) ChineseZodiacSign => _person.ChineseZodiacSign;
    public (string name, string emoji) WesternZodiacSign => _person.WesternZodiacSign;
  }
}