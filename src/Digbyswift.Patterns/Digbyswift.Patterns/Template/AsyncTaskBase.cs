using System;
using System.Threading.Tasks;

namespace Digbyswift.Patterns.Template
{
    public abstract class AsyncTaskBase<T>
    {
        public async Task RunAsync(T context = default)
        {
            try
            {
                await SetupAsync(context);
                await ProcessAsync(context);
                await TeardownAsync(context);
            }
            catch (TaskCanceledException ex)
            {
                await HandleTaskCancelledErrorAsync(context, ex);
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(context, ex);
            }
        }

        protected virtual Task SetupAsync(T context)
        {
            return Task.CompletedTask;
        }

        protected abstract Task ProcessAsync(T context); 

        protected virtual Task TeardownAsync(T context)
        {
            return Task.CompletedTask;
        } 
       
        protected virtual Task HandleTaskCancelledErrorAsync(T context, TaskCanceledException ex)
        {
            return Task.CompletedTask;
        }

        protected virtual Task HandleErrorAsync(T context, Exception ex)
        {
            return Task.CompletedTask;
        } 

    }
}