using UnityEngine;
using UnityEngine.Events;

public class Zombie : Player
{
    public UnityAction ZombieDie;

    private void Update()
    {
        if(Health <= 0)
            Die();
    }

    protected override void Die()
    {
        ZombieDie?.Invoke();
    }
}
