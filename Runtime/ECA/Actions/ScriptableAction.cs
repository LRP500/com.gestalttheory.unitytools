using UnityEngine;

namespace UnityTools.Runtime.ECA.Actions
{
    public abstract class ScriptableAction : ScriptableObject
    {
        public bool Execute()
        {
            return CanExecute() && ExecuteBehaviour();
        }

        public virtual bool CanExecute() => true;
        protected abstract bool ExecuteBehaviour();
    }
    
    public abstract class ScriptableAction<T> : ScriptableObject
    {
        protected T Data { get; private set; }
        
        public bool Execute(T data)
        {
            Data = data; 
            return CanExecute() && ExecuteBehaviour();
        }

        protected virtual bool CanExecute() => true;
        protected abstract bool ExecuteBehaviour();
    }
}