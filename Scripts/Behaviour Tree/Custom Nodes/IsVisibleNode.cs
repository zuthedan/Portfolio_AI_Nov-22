namespace Behaviour
{
    public class IsVisibleNode : Node
    {
        #region attributes
        private Bool isVisible;
        #endregion

        #region constructors
        public IsVisibleNode(Bool isVisible)
        {
            this.isVisible = isVisible;
        }
        #endregion

        #region methods
        public override BehaviourResult Evaluate()
        {
            return result = isVisible?BehaviourResult.Success:BehaviourResult.Fail;
        }
        #endregion
    }
}
