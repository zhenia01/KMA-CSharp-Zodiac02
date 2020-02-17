using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BorodaikevychZodiac.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.Extensions.Logging;

namespace BorodaikevychZodiac.Pages
{
  public class IndexModel : PageModel
  {
    [BindProperty]
    public string BirthDateString
    {
      set
      {
        DateTime.TryParseExact(value, "dd-MM-yyyy", CultureInfo.InvariantCulture,
          DateTimeStyles.None, out var date);


        BirthInfo.BirthDate = date <= DateTime.Today ? date : default;

        IsFirstAttempt = false;
      }

      get => BirthInfo.BirthDate == DateTime.MinValue ? "" : BirthInfo.BirthDate.ToString("dd-MM-yyyy");
    }

    public bool IsFirstAttempt { get; private set; } = true;

    public BirthInfo BirthInfo { get; } = new BirthInfo();

    public (string name, string emoji) ChineseZodiacSign => ZodiacSigns.ChineseSign(BirthInfo.BirthDate);
    public (string name, string emoji) WesternZodiacSign => ZodiacSigns.WesternSign(BirthInfo.BirthDate);
  }
}