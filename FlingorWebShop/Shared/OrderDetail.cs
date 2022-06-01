using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FlingorWebShop.Shared;

public class OrderDetail
{
    [Key]
    public int OrderDetailId { get; set; }
        
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    //These DataAnnotations makes it so that the property "Id" is
    //linked as a foreign key to the principal (primary) key of the Product class.
    [JsonIgnore]
    [ForeignKey("ProductId")]
    public virtual Product? Product { get; set; }
    [JsonIgnore]
    [ForeignKey("UserId")]
    public virtual User? User { get; set; }

    [JsonIgnore]
    [ForeignKey("OrderId")]
    public virtual Order? Order { get; set; }

}