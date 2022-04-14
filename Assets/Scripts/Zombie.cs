using UnityEngine;
using UnityEngine.Events;

public class Zombie : Player
{
    public UnityAction ZombieDie;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
            Die();
    }

    protected override void Die()
    {
        ZombieDie?.Invoke();
    }
}
