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
    public string BirthDateInput
    {
      get => BirthInfo.BirthDateString;
      set
      {
        BirthInfo.BirthDateString = value;
        IsFirstAttempt = false;
      }
    }

    public bool IsFirstAttempt { get; private set; } = true;

    public BirthInfo BirthInfo { get; } = new BirthInfo();

    public (string name, string emoji) ChineseZodiacSign => ZodiacSigns.ChineseSign(BirthInfo.BirthDate);
    public (string name, string emoji) WesternZodiacSign => ZodiacSigns.WesternSign(BirthInfo.BirthDate);
  }
}