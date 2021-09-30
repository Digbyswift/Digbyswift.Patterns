using System.Collections.Generic;
using System.Threading.Tasks;

namespace Digbyswift.Patterns.Pipelines
{
    public abstract class PipelineBase<TContext> where TContext : PipelineContextBase
    {
        /// <summary>
        /// List of filters in the pipeline
        /// </summary>
        private readonly List<IStep<TContext>> _steps = new List<IStep<TContext>>();

        /// <summary>
        /// Register a filter (a unique step) in the pipeline
        /// </summary>
        /// <param name="step">A filter object implementing IFilter interface</param>
        public PipelineBase<TContext> Register(IStep<TContext> step)
        {
            _steps.Add(step);
            return this;
        }

        /// <summary>
        /// Start processing/executing the filters using the context provided.
        /// </summary>
        /// <param name="context">The context/input the filters will process as part of the pipeline.</param>
        public virtual async Task<TContext> ProcessAsync(TContext context)
        {
            ProcessStart(context);
            
            context.PipelineStatus = PipelineStatus.Running;
            
            foreach (var filter in _steps)
            {
                ProcessStepStart(context);
                
                context = await filter.ExecuteAsync(context);
                
                ProcessStepFinish(context);

                if (context.IsFurtherExecutionPrevented)
                    break;
            }

            if (context.PipelineStatus == PipelineStatus.Running)
            {
                context.PipelineStatus = PipelineStatus.Complete;
            }
            
            ProcessFinish(context);

            return context;
        }

        public virtual void ProcessStart(TContext pipelineContextBase)
        {
        }
        
        public virtual void ProcessStepStart(TContext pipelineContextBase)
        {
        }
        
        public virtual void ProcessStepFinish(TContext pipelineContextBase)
        {
        }
        
        public virtual void ProcessFinish(TContext pipelineContextBase)
        {
        }
        
    }
}