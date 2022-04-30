using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CapsuleCollider))]
public class Zombie : Player
{
    public UnityAction ZombieDie;

    private CapsuleCollider _collider;

    private void Start()
    {
        _collider = GetComponent<CapsuleCollider>();    
    }

    private void Update()
    {
        if(Health <= 0)
            Die();
    }

    protected override void Die()
    {
        _collider.enabled = false;
        ZombieDie?.Invoke();
    }
}
