using System.ComponentModel.DataAnnotations;

namespace SiliconMVC2.ViewModels
{
    public class AccountDetailsViewModel
    {
        public AccountBasicInfo BasicInfo { get; set; } = new AccountBasicInfo();
        public AccountAddressInfo AddressInfo { get; set; } = new AccountAddressInfo();
    }

    public class AccountBasicInfo
    {
        public string userId { get; set; } = null!;

        [DataType(DataType.ImageUrl)]
        public string? ProfileImage { get; set; }

        [Display(Name = "First Name", Prompt = "Enter your first name", Order = 0)]
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Last Name", Prompt = "Enter your last name", Order = 1)]
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; } = null!;

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address", Prompt = "Enter your email address", Order = 2)]
        [Required(ErrorMessage = "Invalid email address")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email address")]
        public string EmailAddress { get; set; } = null!;

        [Display(Name = "Phone", Prompt = "Enter your phone", Order = 3)]
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }

        [Display(Name = "Bio", Prompt = "Add a short bio..", Order = 4)]
        [DataType(DataType.MultilineText)]
        public string? Bio { get; set; }
    }


    public class AccountAddressInfo
    {
        [Display(Name = "Address line 1", Prompt = "Enter your address line", Order = 0)]
        [Required(ErrorMessage = "Address line is required")]
        public string AddressLine_1 { get; set; } = null!;

        [Display(Name = "Address line 2 (optional)", Prompt = "Enter your second address line", Order = 1)]
        public string? AddressLine_2 { get; set; }

        [Display(Name = "Postal code", Prompt = "Enter your postal code", Order = 2)]
        [DataType(DataType.PostalCode)]
        [Required(ErrorMessage = "Postal code is required")]
        public string PostalCode { get; set; } = null!;

        [Display(Name = "City", Prompt = "Enter your city", Order = 3)]
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; } = null!;
    }
}
