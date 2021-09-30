namespace Digbyswift.Patterns.Pipelines
{
    public enum PipelineStatus
    {
        None,
        Running,
        Complete,
        Aborted = 10,
        Errored = 11
    }
}