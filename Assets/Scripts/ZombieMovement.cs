using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class ZombieMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _distance;
    [SerializeField] private float _distanceForAttack;
    [SerializeField] private Zombie _zombie;

    private NavMeshAgent _navMeshAgent;
    private Animator _animator;

    private void Start()
    {
        _zombie = GetComponent<Zombie>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        _zombie.ZombieDie += FallingBack;
        _zombie.ZombieDie += BlockMovement;
    }


    private void OnDisable()
    {
        _zombie.ZombieDie -= FallingBack;
        _zombie.ZombieDie += BlockMovement;
    }
    
    private void Update()
    {
        float distanceFromPlayer = Vector3.Distance(transform.position, _player.position);

        if (distanceFromPlayer > _distance)
        {
            _navMeshAgent.enabled = false;
            SwitchAnimation("Walk", "Idle");
        }

        if(distanceFromPlayer <= _distanceForAttack)
        {
            _navMeshAgent.enabled = false;
            SwitchAnimation("Walk", "Attack");
        }

        else if(distanceFromPlayer < _distance)
        {
            _navMeshAgent.enabled = true;
            SwitchAnimation("Idle", "Walk");
            SwitchAnimation("Attack", "Walk");
            _navMeshAgent.SetDestination(_player.position);
        }

    }

    private void SwitchAnimation(string resetAnimationTrigger, string setAnimationTrigger)
    {
        _animator.ResetTrigger(resetAnimationTrigger);
        _animator.SetTrigger(setAnimationTrigger);
    }
    private void FallingBack()
    {
        _animator.ResetTrigger("Idle");
        _animator.ResetTrigger("Walk");
        _animator.ResetTrigger("Attack");
        _animator.SetTrigger("FallingBack");
    }
    private void BlockMovement() => this.enabled = false;
}
