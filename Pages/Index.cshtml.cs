using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.Extensions.Logging;

namespace BorodaikevychZodiac.Pages
{
  public class IndexModel : PageModel
  {
    private DateTime? _birthDate;

    [BindProperty]
    [Required]
    [DisplayFormat(NullDisplayText = "", DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    public string BirthDateString
    {
      set
      {
        DateTime.TryParseExact(value, "dd-MM-yyyy", CultureInfo.InvariantCulture,
          DateTimeStyles.None, out var date);

        _birthDate = date;
      }

      get
      {
        if (_birthDate == null)
        {
          return null;
        }

        var date = _birthDate.Value.Date;

        if (date == DateTime.MinValue)
        {
          return "";
        }

        return date.ToString("dd-MM-yyyy");
      }
    }

    public int Age
    {
      get
      {
        if (string.IsNullOrEmpty(BirthDateString)) return -1;
        var today = DateTime.Now;
        var age = today.Year - _birthDate.Value.Year;
        if (_birthDate.Value.Date > today.AddYears(-age)) age--;
        return age;
      }
    }

    public bool IsBornToday
    {
      get
      {
        if (_birthDate == null) return false;
        var date = _birthDate.Value.Date;
        var today = DateTime.Today;
        return date.Day == today.Day && date.Month == today.Month;
      }
    }
  }
}