using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FlingorWebShop.Shared;

public class Order
{
    //DoD : En Order.cs som innehåller props för Id, CustId, List<Product>
    public int Id { get; set; }

    public DateTime OrderDate { get; set; }

    public int? UserId { get; set; }

    //[Required(ErrorMessage = "First Name is required")]
    //[DisplayName("First Name")]
    //[StringLength(20)]
    public string FirstName { get; set; }

    //[Required(ErrorMessage = "Last Name is required")]
    //[DisplayName("Last Name")]
    //[StringLength(160)]
    public string LastName { get; set; }

    //[Required(ErrorMessage = "Address is required")]
    //[StringLength(70)]
    public string StreetName { get; set; }
    public string StreetNumber { get; set; }

    //[Required(ErrorMessage = "City is required")]
    //[StringLength(40)]
    public string City { get; set; }

    //[Required(ErrorMessage = "State is required")] //Do we want this as required?
    //[StringLength(40)]
    public string? State { get; set; }

    //[Required(ErrorMessage = "Postal Code is required")]
    //[DisplayName("Postal Code")]
    //[StringLength(10)]
    public string PostalCode { get; set; }

    //[Required(ErrorMessage = "Country is required")]
    //[StringLength(40)]
    public string Country { get; set; }

    //[StringLength(24)]
    public string Phone { get; set; }

    //[Required(ErrorMessage = "Email Address is required")]
    //[DisplayName("Email Address")]
    //[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
    //    ErrorMessage = "Email is is not valid.")]
    //[DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    //[ScaffoldColumn(false)]
    public decimal Total { get; set; }

    //[ScaffoldColumn(false)]
    public string PaymentTransactionId { get; set; }

    //[ScaffoldColumn(false)]
    public bool HasBeenShipped { get; set; }

    public List<OrderDetail> OrderDetails { get; set; }
}