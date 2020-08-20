using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    private float _ballSpeed = 40f;
    public float _damage = 1f;

    private void FixedUpdate()
    {
        transform.position += Vector3.right * (_ballSpeed * Time.fixedDeltaTime);
    }

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     Destroy(gameObject);
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("SpawnArea"))
        {
            Destroy(gameObject);
        }
    }
}