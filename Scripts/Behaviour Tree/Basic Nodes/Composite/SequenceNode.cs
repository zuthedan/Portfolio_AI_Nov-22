namespace Behaviour
{
    public class SequenceNode : CompositeNode
    {
        #region constructors
        public SequenceNode() { }
        #endregion

        #region methods
        /// <summary>
        /// evaluates the Node by checking their child Nodes
        /// </summary>
        /// <returns> Fail == one child returns Fail, Running == at least one returns Running and none Fail, true == all children return Success </returns>
        public override BehaviourResult Evaluate()
        {
            result = BehaviourResult.Success;

            foreach (Node node in children)
            {
                childResult = node.Evaluate();

                if (childResult == BehaviourResult.Running) result = BehaviourResult.Running;
                else if (childResult == BehaviourResult.Fail) return result = BehaviourResult.Fail;
            }

            return result;

        }
        #endregion
    }
}
