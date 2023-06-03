public class PhaseSeederBuilder
{
    private List<Phase> Phases = new();

    public PhaseBuilder AddPhase(string codeName, string title)
    {
        var phase = new Phase { Code = int.Parse(codeName), CodeName = codeName, Title = title, Stages = new List<Stage>() };
        Phases.Add(phase);
        return new PhaseBuilder(this, phase);
    }

    public List<Phase> Build() => Phases;
}

public class PhaseBuilder
{
    private PhaseSeederBuilder BuilderBase { get; }
    private Phase Phase { get; }

    public PhaseBuilder(PhaseSeederBuilder builderBase, Phase phase)
    {
        BuilderBase = builderBase;
        Phase = phase;
    }

    public PhaseBuilder AddPhase(string codeName, string title) => BuilderBase.AddPhase(codeName, title);

    public StageBuilder AddStage(string codeName, string description, StageTypeEnum type)
    {
        var stage = new Stage { Code = codeName.Replace(".", string.Empty), CodeName = codeName, Description = description, Type = type, Milestones = new List<Milestone>() };
        Phase.Stages.Add(stage);
        return new StageBuilder(this, stage);
    }

    public List<Phase> Build() => BuilderBase.Build();
}

public class StageBuilder
{
    private PhaseBuilder PhaseBuilder { get; }
    private Stage Stage { get; }

    public StageBuilder(PhaseBuilder phaseBuilder, Stage stage)
    {
        PhaseBuilder = phaseBuilder;
        Stage = stage;
    }

    public PhaseBuilder AddPhase(string codeName, string title) => PhaseBuilder.AddPhase(codeName, title);
    public StageBuilder AddStage(string codeName, string description, StageTypeEnum type) => PhaseBuilder.AddStage(codeName, description, type);

    public MilestoneBuilder AddMilestone(string codeName, string description, MilestoneTypeEnum type)
    {
        var milestone = new Milestone { Code = int.Parse(codeName.Replace(".", string.Empty)), CodeName = codeName, Description = description, Type = type, Activities = new List<MilestoneActivity>() };
        Stage.Milestones.Add(milestone);
        return new MilestoneBuilder(this, milestone);
    }

    public List<Phase> Build() => PhaseBuilder.Build();
}

public class MilestoneBuilder
{
    private StageBuilder StageBuilder { get; }
    private Milestone Milestone { get; }

    public MilestoneBuilder(StageBuilder stageBuilder, Milestone milestone)
    {
        StageBuilder = stageBuilder;
        Milestone = milestone;
    }

    public PhaseBuilder AddPhase(string codeName, string title) => StageBuilder.AddPhase(codeName, title);
    public StageBuilder AddStage(string codeName, string description, StageTypeEnum type) => StageBuilder.AddStage(codeName, description, type);
    public MilestoneBuilder AddMilestone(string codeName, string description, MilestoneTypeEnum type) => StageBuilder.AddMilestone(codeName, description, type);

    public MilestoneBuilder AddActivity(string codeName, string description, MilestoneActivityTypeEnum type)
    {
        Milestone.Activities.Add(new MilestoneActivity { Code = int.Parse(codeName.Replace(".", string.Empty)), Description = description, Type = type });
        return this;
    }
    public List<Phase> Build() => StageBuilder.Build();
}