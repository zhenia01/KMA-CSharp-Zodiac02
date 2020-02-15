using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

    [BindProperty]
    public DateTime? BirthDate { get; private set; }

    public IActionResult OnPost(string birthDate)
    {
      DateTime.TryParseExact(birthDate, "dd-MM-yyyy", CultureInfo.InvariantCulture,
        DateTimeStyles.None, out var date);

      BirthDate = date;

      return Page();
    }

    public IActionResult DisplayResult()
    {
      return Partial("_BirthDayGrats");
    }
  }
}