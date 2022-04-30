using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float _shotRange;
    [SerializeField] private Camera _camera;
    [SerializeField] private Animation _shootAnimation;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _shootAnimation.Play();
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
