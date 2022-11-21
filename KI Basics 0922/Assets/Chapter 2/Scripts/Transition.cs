using System;

public class Transition
{
    private Func<bool> condition;
    private State targetState;

    public Func<bool> Condition => condition;
    public State TargetState => targetState;

    public Transition(State targetState, Func<bool> condition)
    {
        this.targetState = targetState;
        this.condition = condition;
    }
}
