namespace Behaviour
{
    public abstract class DecoratorNode : Node
    {
        #region attributes
        protected Node child;
        #endregion

        #region properties
        public Node Child { get => child;set => child = value; }
        #endregion
    }
}
