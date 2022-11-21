namespace Behaviour
{
    public class SelectorNode : CompositeNode
    {
        #region constructors
        public SelectorNode() { }
        #endregion

        #region methods
        /// <summary>
        /// evaluates the Node by checking their child Nodes
        /// </summary>
        /// <returns> Success == one child returns Success, Running == at least one returns running and none Success, Fail == all children return Fail </returns>
        public override BehaviourResult Evaluate()
        {
            result = BehaviourResult.Fail;

            foreach(Node node in children)
            {
                 childResult =node.Evaluate();

                if(childResult== BehaviourResult.Running) result = BehaviourResult.Running;
                else if(childResult== BehaviourResult.Success) return result= BehaviourResult.Success;
            }

            return result;
        }
        #endregion
    }
}
