using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;

    public void ApplyDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
            Die();
    }

    protected virtual void Die()
    {
        //
    }
}
