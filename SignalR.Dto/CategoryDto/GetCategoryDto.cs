namespace SignalR.Dto.CategoryDto;

public class GetCategoryDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public bool IsActive { get; set; }
    public bool Status { get; set; }
}
