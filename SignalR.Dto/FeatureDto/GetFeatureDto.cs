namespace SignalR.Dto.FeatureDto;

public class GetFeatureDto
{
    public string Id { get; set; }
    public string TitleOne { get; set; }
    public string DescriptionOne { get; set; }
    public string TitleTwo { get; set; }
    public string DescriptionTwo { get; set; }
    public string TitleTree { get; set; }
    public string DescriptionTree { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public bool IsActive { get; set; }
}
