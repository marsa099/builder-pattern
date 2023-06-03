public class Milestone
{
    public int Id { get; set; }
    public int Code { get; set; }
    public string CodeName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public MilestoneTypeEnum Type { get; set; }
    public ICollection<MilestoneActivity> Activities { get; set; }
}