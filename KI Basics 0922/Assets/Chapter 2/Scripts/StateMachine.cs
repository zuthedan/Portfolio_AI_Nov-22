using System.Collections.Generic;

public class StateMachine 
{
    private State currentState;
    private Dictionary<State, List<Transition>> transitions;

    public StateMachine(State startState, Dictionary<State, List<Transition>> transitions)
    {
        this.currentState = startState;
        this.transitions = transitions;
    }

    public void Update()
    {
        State nextState = GetNextState();

        if (nextState != null) SwitchState(nextState);

        currentState.OnStateUpdate();
    }

    private State GetNextState()
    {
        List<Transition> currentTransitions = transitions[currentState];

        foreach (Transition transition in currentTransitions)
        {
            if (transition.Condition()) return transition.TargetState;
        }
        return null;
    }

    private void SwitchState(State targetState)
    {
        if(currentState == targetState) return;

        currentState.OnStateExit();
        targetState.OnStateEnter();

        currentState=targetState;
    }
}
