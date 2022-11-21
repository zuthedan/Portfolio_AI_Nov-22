using System.Collections.Generic;

namespace Behaviour
{
    public abstract class CompositeNode : Node
    {
        #region attributes
        protected List<Node> children; // saves the child Nodes of this Node from left to right
        protected BehaviourResult childResult;
        #endregion

        #region methods

        /// <summary>
        /// appends a Node to the end of the list
        /// </summary>
        /// <param name="child"> the Node that should be added </param>
        public void AppendChild(Node child)
        {
            children.Add(child);
        }

        #endregion
    }
}
