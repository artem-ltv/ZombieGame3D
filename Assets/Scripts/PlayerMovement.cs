using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speeding;

    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();    
    }

    private void Update()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift))
            _speed += _speeding;
        if (Input.GetKeyUp(KeyCode.LeftShift))
            _speed -= _speeding;

        Vector3 move = transform.right * xMovement + transform.forward * zMovement;
        _characterController.Move(move * _speed * Time.deltaTime);

    }
}
