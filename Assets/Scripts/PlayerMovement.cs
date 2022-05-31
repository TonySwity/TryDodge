using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _acceleration = 10f;

    private float _currentSpeed;
    private float _targetSpeed;
    private Animator _animator;
    private float _leftBound = -2.4f;
    private float _rightBound = 2.4f;
    private Vector3 _position;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontalDirection = Input.GetAxis("Horizontal");
        Vector2 movePosition = transform.position;

        _targetSpeed = horizontalDirection * _speed;
        _currentSpeed = Mathf.MoveTowards(_currentSpeed, _targetSpeed, _acceleration * Time.deltaTime);

        if (horizontalDirection != 0)
        {
            _animator.Play("Move");
            transform.eulerAngles = (horizontalDirection < 0) ? Vector3.up * 180f : Vector3.zero;
        }
        else
        {
            _animator.Play("Idle");
        }

        movePosition.x = _currentSpeed;
        movePosition.y = 0f;

        transform.Translate(movePosition * Time.deltaTime, Space.World);

        _position = transform.position;

        if (transform.position.x < _leftBound)
        {
            _position.x = _leftBound;
            transform.position = _position;
        }
        else if (transform.position.x > _rightBound)
        {
            _position.x = _rightBound;
            transform.position = _position;
        }
    }
}