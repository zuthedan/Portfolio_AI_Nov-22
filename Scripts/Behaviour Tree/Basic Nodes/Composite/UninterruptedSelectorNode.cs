namespace Behaviour
{
    public class UninterruptedSelectorNode : CompositeNode
    {
        #region constructors
        public UninterruptedSelectorNode() { }

        #endregion

        #region methods
        /// <summary>
        /// evaluates the Node by checking their child Nodes
        /// evaluates all children before returning a result
        /// </summary>
        /// <returns> Success == one child returns Success, Running == at least one returns Running and none Success, Fail == all children return Fail </returns>
        public override BehaviourResult Evaluate()
        {
            foreach (Node node in children)
            {
                childResult = node.Evaluate();

                if (result == BehaviourResult.Success) continue;
                if (childResult == BehaviourResult.Fail) continue;

                result = childResult;
            }

            return result;
        }
        #endregion
    }
}
