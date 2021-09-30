using System;

namespace Digbyswift.Patterns.Template
{
    public abstract class TaskBase
    {
        public void Run()
        {
            try
            {
                Setup();
                Process();
                Teardown();
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }

        protected virtual void Setup()
        {
        }

        protected abstract void Process(); 

        protected virtual void Teardown()
        {
        } 
       
        protected virtual void HandleError(Exception ex)
        {
        } 

    }
}