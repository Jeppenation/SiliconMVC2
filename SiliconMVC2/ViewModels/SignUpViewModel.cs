using Infrastructure.Helpers;
using System.ComponentModel.DataAnnotations;

namespace SiliconMVC2.ViewModels;

public class SignUpViewModel
{
    public string Title { get; set; } = "Sign Up";
    //public SignUpModel Form { get; set; } = new SignUpModel();

    [Display(Name = "First Name", Prompt = "Enter your first name", Order = 0)]
    [Required(ErrorMessage = "First name is required")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "Last Name", Prompt = "Enter your last name", Order = 1)]
    [Required(ErrorMessage = "Last name is required")]
    public string LastName { get; set; } = null!;

    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email address", Prompt = "Enter your email address", Order = 2)]
    [Required(ErrorMessage = "Invalid email address")]
    //[RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email address")]
    public string Email { get; set; } = null!;

    [Display(Name = "Password", Prompt = "Enter your password", Order = 3)]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password is required")]
    [RegularExpression(@"^(?=.*[^\w\d]).{8,15}$", ErrorMessage = "Password must be 8-15 characters and contain at least one special character")]

    public string Password { get; set; } = null!;

    [Display(Name = "Confirm Password", Prompt = "Re-enter your password", Order = 4)]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password must be confirmed")]
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    public string ConfirmPassword { get; set; } = null!;

    [Display(Name = "I agree to the terms and conditions", Order = 5)]
    [CheckboxRequired(ErrorMessage = "You must agree to the terms and conditions")]
    public bool TermsAndConditions { get; set; } = false;

    }
