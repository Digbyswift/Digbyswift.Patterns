using System.Threading.Tasks;

namespace Digbyswift.Patterns.Pipelines
{
    public interface IStep<T> where T : PipelineContextBase
    {
        /// <summary>
        /// Filter implementing this method would perform processing on the input type T
        /// </summary>
        /// <param name="context">The input to be executed by the filter</param>
        Task<T> ExecuteAsync(T context);
    }
}