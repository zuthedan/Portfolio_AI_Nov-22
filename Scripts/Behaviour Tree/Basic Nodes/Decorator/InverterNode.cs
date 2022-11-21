namespace Behaviour
{
    public class InverterNode : DecoratorNode
    {
        #region methods
        /// <summary>
        /// inverts the result of the child Node
        /// </summary>
        /// <returns> the inverted result of the child Node, or Running if child result is Running </returns>
        public override BehaviourResult Evaluate()
        {
            result = child.Evaluate();
            switch (result)
            {
                case BehaviourResult.Running:
                    return BehaviourResult.Running;
                case BehaviourResult.Success:
                    return BehaviourResult.Fail;
                case BehaviourResult.Fail:
                    return BehaviourResult.Success;
                default:
                    return BehaviourResult.Fail;
            }

        }
        #endregion
    }
}
