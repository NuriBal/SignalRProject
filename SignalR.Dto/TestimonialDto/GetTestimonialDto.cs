namespace SignalR.Dto.TestimonialDto;

public class GetTestimonialDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string Comment { get; set; }
    public string ImageUrl { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public bool Status { get; set; }
}
