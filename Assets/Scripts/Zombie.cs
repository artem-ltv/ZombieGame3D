using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CapsuleCollider))]
public class Zombie : Player
{
    public UnityAction ZombieDie;

    [SerializeField] private GameObject[] _zombieDamages;

    private CapsuleCollider _bodyCollider;

    private void Start()
    {
        _bodyCollider = GetComponent<CapsuleCollider>();    
    }

    private void Update()
    {
        if(Health <= 0)
            Die();
    }

    protected override void Die()
    {
        StartCoroutine(RemoveCollision());

        foreach (var item in _zombieDamages)
            Destroy(item);

        ZombieDie?.Invoke();
    }

    private IEnumerator RemoveCollision()
    {
        yield return new WaitForSeconds(1.5f);

        _bodyCollider.enabled = false;
    }
}
