using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float _shotRange;
    [SerializeField] private Camera _camera;
    [SerializeField] private Animation _shootAnimation;
    [SerializeField] private AudioSource _shotAudioSource;
    [SerializeField] private AudioClip _shotAudioClip;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _shootAnimation.Play();
            _shotAudioSource.PlayOneShot(_shotAudioClip);

            RaycastHit hit;

            if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, _shotRange))
            {
                if(hit.collider.TryGetComponent(out Zombie zombie))
                {
                    zombie.Health--;
                }
            }
        }
    }
}
