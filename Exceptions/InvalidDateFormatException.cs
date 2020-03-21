using System;

namespace BorodaikevychZodiac.Exceptions
{
  public class InvalidDateFormatException: FormatException
  {
    public InvalidDateFormatException(string message) : base(message)
    {
    }

    public InvalidDateFormatException() : base("Invalid date format")
    {
    }
  }
}
