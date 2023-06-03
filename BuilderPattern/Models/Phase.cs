public class Phase
{
    public int Id { get; set; }
    public int Code { get; set; }
    public string CodeName { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public ICollection<Stage> Stages { get; set; }
}