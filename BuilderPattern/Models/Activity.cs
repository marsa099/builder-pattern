public class MilestoneActivity
{
    public int Id { get; set; }
    public int Code { get; set; }
    public string Description { get; set; }
    public MilestoneActivityTypeEnum Type { get; set; }
    public int MilestoneId { get; set; }
    public Milestone Milestone { get; set; }
}