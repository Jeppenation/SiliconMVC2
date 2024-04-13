using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class AddressEntity
{
    [Key]
    public int Id { get; set; }
    public string AddressLine1 { get; set; } = null!;
    public string? AddressLine2 { get; set; }
    public string City { get; set; } = null!;
    public string PostalCode { get; set; } = null!;


    //public string? UserId { get; set; }
    //public UserEntity? User { get; set; }
}
