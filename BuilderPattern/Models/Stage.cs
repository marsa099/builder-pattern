public class Stage
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string CodeName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public StageTypeEnum Type { get; set; }
    public ICollection<Milestone> Milestones { get; set; }
}