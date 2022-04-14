using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();    
    }

    private void Update()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");

        Vector3 move = transform.right * xMovement + transform.forward * zMovement;
        _characterController.Move(move * _speed * Time.deltaTime);
    }
}
