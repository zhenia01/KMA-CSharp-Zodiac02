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
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
      _logger = logger;
    }

    private DateTime? _birthDate;

    [BindProperty]
    [DisplayFormat(NullDisplayText = "")]
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
  }
}