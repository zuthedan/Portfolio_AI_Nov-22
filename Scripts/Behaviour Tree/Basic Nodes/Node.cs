namespace Behaviour
{
    public abstract class Node
    {
        #region attributes
        protected BehaviourResult result; // the current result of the Node
        #endregion

        #region methods
        public abstract BehaviourResult Evaluate();

        #endregion
    }
}
