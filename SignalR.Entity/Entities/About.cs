using SignalR.Entity.Abstract;

namespace SignalR.Entity.Entities;

public class About : BaseEntity
{
    public string ImageUrl { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
