using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
 
public class Player : MonoBehaviour
{
    public UnityAction PlayerDie;

    public float Health;

    public void ApplyDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
            Die();
    }

    protected virtual void Die()
    {
        PlayerDie.Invoke();
    }
}
