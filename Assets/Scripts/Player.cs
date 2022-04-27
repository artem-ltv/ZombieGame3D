using UnityEngine;

public class Player : MonoBehaviour
{
    public float Health;

    public void ApplyDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
            Die();
    }

    protected virtual void Die()
    {
        //
    }
}
