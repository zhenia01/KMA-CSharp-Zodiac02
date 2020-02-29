using System;
using System.Globalization;
using BorodaikevychZodiac.Entities;

namespace BorodaikevychZodiac.Models.User
{
  public class UserModel
  {
    private readonly Person _person = new Person(default, default, default,default);

    private string _birthDate;

    public string BirthDate
    {
      set
      {
        if (DateTime.TryParseExact(value, "dd-MM-yyyy", CultureInfo.InvariantCulture,
          DateTimeStyles.None, out var birthDate))
        {
          _birthDate = value;   
          _person.BirthDate = birthDate;
        }
      }

      get => _birthDate;
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