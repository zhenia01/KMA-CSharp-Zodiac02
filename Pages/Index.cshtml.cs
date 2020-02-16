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
    [Required]
    [DisplayFormat(NullDisplayText = "", DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    public string BirthDateInput
    {
      get => BirthInfo.BirthDateString;
      set => BirthInfo.BirthDateString = value;
    }

    public BirthInfo BirthInfo { get; } = new BirthInfo();

    public (string name, string emoji) ChineseZodiacSign => ZodiacSigns.ChineseSign(BirthInfo.BirthDate ?? DateTime.MinValue);
    public (string name, string emoji) WesternZodiacSign => ZodiacSigns.WesternSign(BirthInfo.BirthDate ?? DateTime.MinValue);
  }
}