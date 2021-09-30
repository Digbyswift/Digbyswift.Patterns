namespace Digbyswift.Patterns.Pipelines
{
    public abstract class PipelineContextBase
    {
        public PipelineStatus PipelineStatus { get; internal set; } = PipelineStatus.None;
        public bool IsFurtherExecutionPrevented { get; private set; }
        
        public void PreventFurtherExecution(PipelineStatus status = PipelineStatus.Complete)
        {
            PipelineStatus = status;
            IsFurtherExecutionPrevented = true;
        }
    }
}