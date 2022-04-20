using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ZombieDamage : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private Image _damageBackgrond;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_damage);
            _damageBackgrond.DOFade(0.5f, 0.2f);
            _damageBackgrond.DOFade(0f, 0.7f).SetDelay(0.2f);
        }
    }
}
