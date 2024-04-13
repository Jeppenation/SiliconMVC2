using System.ComponentModel.DataAnnotations;

namespace SiliconMVC2.ViewModels;

public class SignInViewModel
{

    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email address", Prompt = "Enter your email address", Order = 0)]
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; } = null!;

    [Display(Name = "Password", Prompt = "Enter your password", Order = 1)]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } = null!;
    public bool IsPersistent { get; set; } = false;

    public string Title { get; set; } = "Sign In";
    //public SignInModel Form { get; set; } = new SignInModel();
    public string? ErrorMessage { get; set; }

    [Display(Name = "Remember me", Order = 2)]
    public bool RememberMe { get; set; }
}
