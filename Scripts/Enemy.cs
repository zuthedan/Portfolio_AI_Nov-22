using Behaviour;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private AgentBehaviourStats stats;

    private MeshRenderer meshRenderer;

    private BehaviourTree behaviourTree;


    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;

        behaviourTree = CreateBehaviourTree.CreateTree(stats);
        
    }

    private void Update()
    {
        behaviourTree.Evaluate();
    }
}
