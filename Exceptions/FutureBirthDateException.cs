using System;

namespace BorodaikevychZodiac.Exceptions
{
  public class FutureBirthDateException : ArgumentOutOfRangeException
  {
    public FutureBirthDateException(string message) : base(message)
    { 
    }

    public FutureBirthDateException() : base("Too early birth date")
    {
    }
  }
}
