using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField]private float _acceleration = 10f;

    private float _currentSpeed;
    private float _targetSpeed;
    private Animator _animator;
    private float _leftBound = -2.4f;
    private float _rightBound = 2.4f;
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
        Vector2 position = transform.position;
        
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

         
        
        position.x = _currentSpeed;
        position.y = 0f;
        
        transform.Translate(position * Time.deltaTime, Space.World);

        if (transform.position.x < _leftBound)
        {
            Vector3 positionLeft = transform.position;
            positionLeft.x = _leftBound;
            transform.position = positionLeft;
        }
        else if (transform.position.x > _rightBound)
        {
            Vector3 positionRight = transform.position;
            positionRight.x = _rightBound;
            transform.position = positionRight;
        }

    }
}