namespace SignalR.Entity.Abstract;

public class BaseEntity
{
    public BaseEntity()
    {
        Id = Guid.NewGuid().ToString();
        CreatedDate = DateTime.Now;
        Status = true;
    }
    public string Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public bool Status { get; set; }
}
