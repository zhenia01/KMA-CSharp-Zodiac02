using System;
using System.Threading.Tasks;

namespace BorodaikevychZodiac.Entities
{
  internal class Person
  {
    public Person(string firstName, string lastName, string email, DateTime birthDate = default)
    {
      FirstName = firstName;
      LastName = lastName;
      Email = email;
      BirthDate = birthDate;
    }

    public Person(string firstName, string lastName, DateTime birthDate) : this(firstName, lastName, "", birthDate)
    {
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    private readonly BirthInfo _birthInfo = new BirthInfo();

    public DateTime BirthDate
    {
      get => _birthInfo.BirthDate;
      set
      {
        _birthInfo.BirthDate = value;
        IsAdult = _birthInfo.Age >= 18;
        Task.Run(CalculateZodiacSigns);
      }
    }

    private async Task CalculateZodiacSigns()
    {
      var chineseTask = CalculateChineseSignAsync();
      var westernTask = CalculateWesternSignAsync(); 
      await Task.WhenAll(chineseTask, westernTask);
    }

    private async Task CalculateChineseSignAsync()
    {
      ChineseZodiacSign = await ZodiacSigns.ChineseSignAsync(_birthInfo.BirthDate);
    } 
    
    private async Task CalculateWesternSignAsync()
    {
      WesternZodiacSign = await ZodiacSigns.WesternSignAsync(_birthInfo.BirthDate);
    }

    public bool IsAdult { get; private set; }
    public (string name, string emoji) ChineseZodiacSign { get; private set; }
    public (string name, string emoji) WesternZodiacSign { get; private set; }
    public bool IsBornToday => _birthInfo.IsBornToday;
  }
}