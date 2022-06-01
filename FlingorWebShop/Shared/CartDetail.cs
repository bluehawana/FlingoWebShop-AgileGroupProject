using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FlingorWebShop.Shared
{
    public class CartDetail
    {
        [Key]
        public int CartDetailId { get; set; }
        
        public int UserId { get; set; }

        public int ProductId { get; set; }

        public int Amount { get; set; }

        //These DataAnnotations makes it so that the property "Id" is
        //linked as a foreign key to the principal (primary) key of the Cart class.

        //Behövs denna? ja
        [JsonIgnore]
        [ForeignKey("UserId")]
        public virtual User? User { get; set; }

        [JsonIgnore]
        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; }
    }
}
