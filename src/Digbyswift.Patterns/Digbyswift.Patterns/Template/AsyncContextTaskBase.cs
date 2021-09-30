using System;
using System.Threading.Tasks;

namespace Digbyswift.Patterns.Template
{
    public abstract class AsyncContextTaskBase
    {
        protected async Task RunAsync()
        {
            try
            {
                await SetupAsync();
                await ProcessAsync();
                await TeardownAsync();
            }
            catch (TaskCanceledException ex)
            {
                await HandleTaskCancelledErrorAsync(ex);
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(ex);
            }
        }

        protected virtual Task SetupAsync()
        {
            return Task.CompletedTask;
        }

        protected abstract Task ProcessAsync(); 

        protected virtual Task TeardownAsync()
        {
            return Task.CompletedTask;
        } 
       
        protected virtual Task HandleTaskCancelledErrorAsync(TaskCanceledException ex)
        {
            return Task.CompletedTask;
        }

        protected virtual Task HandleErrorAsync(Exception ex)
        {
            return Task.CompletedTask;
        } 

    }
}