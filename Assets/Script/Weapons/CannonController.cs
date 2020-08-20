using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class CannonController : Weapon
{
    
    public GameObject _cannonBall;
    public float _fireCoolDown = 0.3f;
    private float _shootTimer = 0f;

    private void FixedUpdate()
    {
        _shootTimer -= Time.fixedDeltaTime;
    }

    public override void Shoot()
    {
        if (_shootTimer > 0f)
        {
            return;
        }

        Instantiate(_cannonBall, transform.position, transform.rotation);
        _shootTimer = _fireCoolDown;
    }
    
}