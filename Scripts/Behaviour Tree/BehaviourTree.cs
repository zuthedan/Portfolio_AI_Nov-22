namespace Behaviour
{
    public class BehaviourTree
    {
        #region attributes
        private Node root; // saves the root Node of the tree
        #endregion

        #region constructors
        /// <summary>
        /// creates a new BehaviourTree with a given root Node
        /// </summary>
        /// <param name="root"> the root Node of the new BehaviourTree </param>
        public BehaviourTree(Node root)
        {
            this.root = root;
        }
        #endregion

        #region methods
        /// <summary>
        /// evaluates the BehaviourTree by evaluating the root Node
        /// </summary>
        public BehaviourResult Evaluate()
        {
            return root.Evaluate();
        }
        #endregion
    }
}
