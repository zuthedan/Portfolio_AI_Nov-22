namespace Behaviour
{
    public class FailNode : DecoratorNode
    {
        #region methods
        public override BehaviourResult Evaluate()
        {
            child?.Evaluate();

            return result = BehaviourResult.Fail;
        }
        #endregion
    }
}
