using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using BorodaikevychZodiac.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BorodaikevychZodiac.Pages
{
  public class IndexModel : PageModel
  {
    private readonly UserModel _user = new UserModel();

    [Required]
    [BindProperty]
    [ValidBirthDate]
    public string BirthDate
    {
      get => _user.BirthDate;
      set => _user.BirthDate = value;
    }

    [Required]
    [BindProperty]
    public string FirstName
    {
      get => _user.FirstName;
      set => _user.FirstName = value;
    }

    [Required]
    [BindProperty]
    public string LastName
    {
      get => _user.LastName;
      set => _user.LastName = value;
    }

    [Required]
    [BindProperty]
    [DataType(DataType.EmailAddress)]
    public string Email
    {
      get => _user.Email;
      set => _user.Email = value;
    }

    public bool IsAdult => _user.IsAdult;
    public bool IsBornToday => _user.IsBornToday;
    public (string name, string emoji) ChineseZodiacSign => _user.ChineseZodiacSign;
    public (string name, string emoji) WesternZodiacSign => _user.WesternZodiacSign;

    public bool IsTried { get; private set; }

    public async Task<IActionResult> OnPost()
    {
      IsTried = true;
      await Task.Delay(100);
      return Page();
    }
  }
}