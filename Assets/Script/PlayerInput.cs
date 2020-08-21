using System;
using UnityEngine;


[RequireComponent(typeof(MovementController))]
public class PlayerInput : MonoBehaviour
{
    
    private MovementController _movement;
    private CannonController _cannon;

    private void Awake()
    {
        _movement = GetComponent<MovementController>();
        _cannon = GetComponentInChildren<CannonController>();
        
    }

   

    private void Update()
    {
        _movement._movementInput.x = Input.GetAxis("Horizontal");
        _movement._movementInput.y = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.Space))
        {
            _cannon.Shoot();
        }
    }
}