using System;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{
    [SerializeField] private float _maxSpeed = 20f;
    [SerializeField] private float _acceleration = 60f;

    [NonSerialized] public Rigidbody2D _body;
    private Vector2 _currentSpeed = new Vector2(0f, 0f);
    [NonSerialized] public Vector2 _movementInput;
   // [NonSerialized] public Vector3 _currentPosition;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
       
     //   _currentPosition.x = gameObject.transform.position.x;
     //   _currentPosition.y = gameObject.transform.position.y;
     //   _currentPosition.z = 0f;
    }

    private void FixedUpdate()
    {
        moveHorizontal();
        moveVertical();
        _body.velocity = _currentSpeed;
    }

    private void moveHorizontal()
    {
        float desiredHorizontalSpeed = _movementInput.x * _maxSpeed;
        _currentSpeed.x =
            Mathf.MoveTowards(_currentSpeed.x, desiredHorizontalSpeed, _acceleration * Time.fixedDeltaTime);
    }

    private void moveVertical()
    {
        float desiredVerticalSpeed = _movementInput.y * _maxSpeed;
        _currentSpeed.y = Mathf.MoveTowards(_currentSpeed.y, desiredVerticalSpeed, _acceleration * Time.fixedDeltaTime);
    }
}