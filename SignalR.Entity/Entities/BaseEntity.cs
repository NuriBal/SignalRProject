namespace SignalR.Entity.Entities;

public class BaseEntity
{
    public string Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public bool Status { get; set; }
}
