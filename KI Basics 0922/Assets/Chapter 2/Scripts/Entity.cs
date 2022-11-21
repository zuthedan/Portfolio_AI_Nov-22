using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(MeshRenderer))]
public class Entity : MonoBehaviour
{
    private NavMeshAgent agent;
    private MeshRenderer meshRenderer;

    private Transform enemy;

    [SerializeField]
    private float walkingSpeed, fleeingSpeed;

    private Vector3 movementDirection;

    private float currentWalkTime, maxWalkTime;

    [SerializeField]
    private float attentionRadius;

    [SerializeField]
    private LayerMask mask;

    public NavMeshAgent Agent { get => agent; }
    public MeshRenderer MeshRenderer { get => meshRenderer; }
    public Transform Enemy { get => enemy; set => enemy = value; }
    public float WalkingSpeed { get => walkingSpeed; }
    public float FleeingSpeed { get => fleeingSpeed; }
    public Vector3 MovementDirection { get => movementDirection; set => movementDirection = value; }
    public float CurrentWalkTime { get => currentWalkTime; set => currentWalkTime = value; }
    public float MaxWalkTime { get => maxWalkTime; set => maxWalkTime = value; }
    public float AttentionRadius { get => attentionRadius; }
    public LayerMask Mask { get => mask; }


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        meshRenderer = GetComponent<MeshRenderer>();
    }


}
