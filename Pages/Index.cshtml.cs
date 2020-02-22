using System.ComponentModel.DataAnnotations;
using BorodaikevychZodiac.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BorodaikevychZodiac.Pages
{
  public class IndexModel : PageModel
  {
    [BindProperty]
    [Required]
    [ValidBirthDate]
    public new UserModel User { get; set; }
  }
}