using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FlingorWebShop.Shared;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    [NotMapped]
    public string Password { get; set; }
    public byte[]? PasswordHash { get; set; }
    public byte[]? PasswordSalt { get; set; }
    public string Phone { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string StreetName { get; set; }
    public string StreetNumber { get; set; }
    public string City { get; set; }
    public string? State { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public bool IsAdmin { get; set; }

    // Is it necessary that a customer has a cart?
    //public Cart Cart { get; set; }
}
