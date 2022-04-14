using UnityEngine;

public class ZombieDamage : MonoBehaviour
{
    [SerializeField] private int _damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_damage);
        }
    }
}
