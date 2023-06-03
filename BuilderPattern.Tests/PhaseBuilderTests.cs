namespace BuilderPattern.Tests;
public class PhaseSeederTests
{
    [Fact]
    public void Test1()
    {
        var seeder = new PhaseSeederBuilder();

        var phases = seeder
            .AddPhase("10", "Phase 10 Description")
            .AddPhase("20", "Phase 20 Description")
            .AddPhase("30", "Phase 30 Description")
            .AddPhase("40", "Phase 40 Description")
            .Build();
        ;

        Assert.Equal(4, phases.Count());
        Assert.Empty(phases.SelectMany(p => p.Stages));
        Assert.Empty(phases.SelectMany(p => p.Stages.SelectMany(s => s.Milestones)));
        Assert.Empty(phases.SelectMany(p => p.Stages.SelectMany(s => s.Milestones.SelectMany(m => m.Activities))));
    }

    [Fact]
    public void Test2()
    {
        var seeder = new PhaseSeederBuilder();

        var phases = seeder
            .AddPhase("10", "Phase 10 Description")
            .AddPhase("20", "Phase 20 Description")
                .AddStage("2.1", "Stage 2.1 Description", StageTypeEnum.International)
                .AddStage("2.2", "Stage 2.2 Description", StageTypeEnum.International)
            .AddPhase("30", "Phase 30 Description")
            .AddPhase("40", "Phase 40 Description")
            .Build();
        ;

        Assert.Equal(4, phases.Count());
        Assert.Equal(2, phases.SelectMany(p => p.Stages).Count());
        Assert.Empty(phases.SelectMany(p => p.Stages.SelectMany(s => s.Milestones)));
        Assert.Empty(phases.SelectMany(p => p.Stages.SelectMany(s => s.Milestones.SelectMany(m => m.Activities))));
    }

    [Fact]
    public void Test3()
    {
        var seeder = new PhaseSeederBuilder();

        var phases = seeder
            .AddPhase("10", "Phase 10 Description")
            .AddPhase("20", "Phase 20 Description")
                .AddStage("2.1", "Stage 2.1 Description", StageTypeEnum.International)
                .AddStage("2.2", "Stage 2.2 Description", StageTypeEnum.International)
                    .AddMilestone("2.2.1", "Milestone 2.2.1 Description", MilestoneTypeEnum.National)
                        .AddActivity("2.2.1.1", "Activity 2.2.1.1 Description", MilestoneActivityTypeEnum.A)
                        .AddActivity("2.2.1.2", "Activity 2.2.1.2 Description", MilestoneActivityTypeEnum.A)
            .AddPhase("30", "Phase 30 Description")
                .AddStage("3.1", "Stage 3.1 Description", StageTypeEnum.International)
                    .AddMilestone("3.1.1", "Milestone 3.1.1 Description", MilestoneTypeEnum.National)
                    .AddMilestone("3.1.2", "Milestone 3.1.2 Description", MilestoneTypeEnum.National)
                .AddStage("3.2", "Stage 3.2 Description", StageTypeEnum.International)
            .AddPhase("40", "Phase 40 Description")
                .AddStage("4.1", "Stage 4.1 Description", StageTypeEnum.International)
                    .AddMilestone("4.1.1", "Milestone 4.1.1 Description", MilestoneTypeEnum.National)
                        .AddActivity("4.1.1.1", "Activity 4.1.1.1", MilestoneActivityTypeEnum.A)
                        .AddActivity("4.1.1.2", "Activity 4.1.1.2", MilestoneActivityTypeEnum.A)
                    .AddMilestone("4.1.2", "Milestone 4.1.2 Description", MilestoneTypeEnum.National)
                .AddStage("4.2", "Stage 4.2 Description", StageTypeEnum.International)
            .Build();
        ;

        Assert.Equal(4, phases.Count());
        Assert.Equal(6, phases.SelectMany(p => p.Stages).Count());
        Assert.Equal(5, phases.SelectMany(p => p.Stages.SelectMany(s => s.Milestones)).Count());
        Assert.Equal(4, phases.SelectMany(p => p.Stages.SelectMany(s => s.Milestones.SelectMany(m => m.Activities))).Count());
    }

    [Fact]
    public void Test4()
    {
        var seeder = new PhaseSeederBuilder();

        var phases = seeder
            .AddPhase("10", "Phase 10 Description")
            .AddPhase("20", "Phase 20 Description")
                .AddStage("2.1", "Stage 2.1 Description", StageTypeEnum.International)
                .AddStage("2.2", "Stage 2.2 Description", StageTypeEnum.International)
                    .AddMilestone("2.2.1", "Milestone 2.2.1 Description", MilestoneTypeEnum.National)
            .Build();
        ;

        Assert.Equal(2, phases.Count());
        Assert.Equal(2, phases.SelectMany(p => p.Stages).Count());
        Assert.Equal(1, phases.SelectMany(p => p.Stages.SelectMany(s => s.Milestones)).Count());
        Assert.Equal(0, phases.SelectMany(p => p.Stages.SelectMany(s => s.Milestones.SelectMany(m => m.Activities))).Count());
    }

        [Fact]
    public void Test5()
    {
        var seeder = new PhaseSeederBuilder();

        var phases = seeder
            .AddPhase("10", "Phase 10 Description")
            .AddPhase("20", "Phase 20 Description")
                .AddStage("2.1", "Stage 2.1 Description", StageTypeEnum.International)
                .AddStage("2.2", "Stage 2.2 Description", StageTypeEnum.International)
                    .AddMilestone("2.2.1", "Milestone 2.2.1 Description", MilestoneTypeEnum.National)
                        .AddActivity("2.2.1.1", "Activity 2.2.1.1 Description", MilestoneActivityTypeEnum.A)
                        .AddActivity("2.2.1.2", "Activity 2.2.1.2 Description", MilestoneActivityTypeEnum.A)
            .Build();
        ;

        Assert.Equal(2, phases.Count());
        Assert.Equal(2, phases.SelectMany(p => p.Stages).Count());
        Assert.Equal(1, phases.SelectMany(p => p.Stages.SelectMany(s => s.Milestones)).Count());
        Assert.Equal(2, phases.SelectMany(p => p.Stages.SelectMany(s => s.Milestones.SelectMany(m => m.Activities))).Count());
    }
}
