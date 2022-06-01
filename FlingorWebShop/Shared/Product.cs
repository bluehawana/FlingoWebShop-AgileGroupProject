using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FlingorWebShop.Shared;

//A DataAnnotation for the class, here we specify that the
//ArticleNumber property is Unique (two rows can't have the same value).
[Index(nameof(ArticleNumber), IsUnique = true)]
public class Product
{
    public int Id { get; set; }
    //TODO Validate ArticleNumber format.
    public string ArticleNumber { get; set; }
    public string Title { get; set; }
    public DateTime ReleaseDate { get; set; }
    public AgeRating AgeRating { get; set; }
    public decimal Price { get; set; }
    public int AmountInStock { get; set; }
    public string Publisher { get; set; }
    public Genre Genre { get; set; }
    public Types Type { get; set; }
}