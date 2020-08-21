using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{
    [SerializeField] private float _maxSpeed = 10f;
    [SerializeField] private float _acceleration = 20f;

    [NonSerialized] public Rigidbody2D _body;
    private Color _playerColor;
    private Vector2 _currentSpeed = new Vector2(0f, 0f);
    [NonSerialized] public Vector2 _movementInput;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _playerColor = GetComponentInChildren<Color>();
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