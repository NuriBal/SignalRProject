using SignalR.Entity.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace SignalR.Entity.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public bool Status { get; set; }
    public string FkCategoryId { get; set; }

    [ForeignKey(nameof(FkCategoryId))]
    public Category Category { get; set; }
}
