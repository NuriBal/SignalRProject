using SignalR.Entity.Abstract;

namespace SignalR.Entity.Entities;

public class Discount : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public string Amount { get; set; }
}
