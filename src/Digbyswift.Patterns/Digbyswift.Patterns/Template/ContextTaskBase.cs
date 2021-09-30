using System;

namespace Digbyswift.Patterns.Template
{
    public abstract class ContextTaskBase<T>
    {
        public void Run(T context)
        {
            try
            {
                Setup(context);
                Process(context);
                Teardown(context);
            }
            catch (Exception ex)
            {
                HandleError(context, ex);
            }
        }

        protected virtual void Setup(T context)
        {
        }

        protected abstract void Process(T context); 

        protected virtual void Teardown(T context)
        {
        } 
       
        protected virtual void HandleError(T context, Exception ex)
        {
        } 

    }
}