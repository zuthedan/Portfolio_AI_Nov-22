public abstract class State
{
    protected Entity entity;

    protected State(Entity entity)
    {
        this.entity = entity;
    }

    public virtual void OnStateEnter() { }
    public virtual void OnStateUpdate() { }
    public virtual void OnStateExit() { }
}
