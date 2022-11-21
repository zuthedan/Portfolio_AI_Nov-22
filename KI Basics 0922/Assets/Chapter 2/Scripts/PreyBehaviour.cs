using System.Collections.Generic;
using UnityEngine;

public class PreyBehaviour : MonoBehaviour
{

    [SerializeField]
    private List<Entity> entities;
    private List<StateMachine> stateMachines;

    void Start()
    {
        stateMachines = new List<StateMachine>();

        foreach(Entity entity in entities)
        {
            CreateStateMachine(entity);
        }
    }

    void Update()
    {
        foreach(StateMachine stateMachine in stateMachines)
        {
            stateMachine.Update();
        }
    }

    private void CreateStateMachine(Entity entity)
    {
        ChooseDirectionState chooseDirectionState = new ChooseDirectionState(entity);
        WalkingState walkingState = new WalkingState(entity);
        FleeingState fleeingState = new FleeingState(entity);

        Dictionary<State, List<Transition>> transitions = new Dictionary<State, List<Transition>>()
        {
            [chooseDirectionState] = new List<Transition>()
            {
                new Transition(fleeingState, () => CheckForEnemy(entity)),
                new Transition(walkingState, () => true),
            },

            [walkingState] = new List<Transition>()
            {
                new Transition(fleeingState, () => CheckForEnemy(entity)),
                new Transition(chooseDirectionState, () => entity.CurrentWalkTime >= entity.MaxWalkTime)
            },

            [fleeingState] = new List<Transition>()
            {
                new Transition(chooseDirectionState, () => !CheckForEnemy(entity))
            }
        };
        stateMachines.Add(new StateMachine(chooseDirectionState, transitions));

    }

    private bool CheckForEnemy(Entity entity)
    {
        Collider[] colliders = Physics.OverlapSphere(entity.transform.position, entity.AttentionRadius, entity.Mask);

        if(colliders.Length > 0)
        {
            entity.Enemy = colliders[0].transform;
            return true;
        }
        entity.Enemy = null;
        return false;
    }
}
