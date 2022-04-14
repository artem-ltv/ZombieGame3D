using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerPhisycs : MonoBehaviour
{
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _jumpHeight;

    private CharacterController _characterController;
    private Vector3 _velocity;
    private bool _isGroundChecked;

    private float _gravity = -9.81f;
    private float _groundDistance = 0.3f;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();    
    }

    private void Update()
    {
        CheckGround();

        if (Input.GetButtonDown("Jump") && _isGroundChecked)
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
        

        _velocity.y += _gravity * Time.deltaTime;
        _characterController.Move(_velocity * Time.deltaTime);
    }

    private void CheckGround()
    {
        _isGroundChecked = Physics.CheckSphere(_groundChecker.position, _groundDistance, _groundMask);

        if(_isGroundChecked && _velocity.y < 0)
            _velocity.y = -2f;
    }
}
