using SignalR.Entity.Abstract;

namespace SignalR.Entity.Entities;

public class Feature : BaseEntity
{
    public string TitleOne { get; set; }
    public string DescriptionOne { get; set; }
    public string TitleTwo { get; set; }
    public string DescriptionTwo { get; set; }
    public string TitleTree { get; set; }
    public string DescriptionTree { get; set; }
}
