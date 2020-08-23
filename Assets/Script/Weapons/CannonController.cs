using System;
using System.Collections;
using UnityEngine;

public class CannonController : Weapon
{
    public GameObject _cannonBall;
    public float _fireCoolDown = 0.3f;
    private float _shootTimer = 0f;

    public float _expansionSpeed = 5.0f;
    public float _expansionMaxIncrease = 0.2f; 
    private Vector3 _startScale;

    private void Awake()
    {
        _startScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

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
        StartCoroutine(ShotPipeExtension());
    }

    IEnumerator ShotPipeExtension()
    {
        Vector3 expansionTarget = transform.localScale +
                                  new Vector3(_expansionMaxIncrease, _expansionMaxIncrease, _expansionMaxIncrease);

        while (transform.localScale.x < expansionTarget.x)
        {
            // transform.localScale = Vector3.MoveTowards(transform.localScale, expansionTarget, _expansionSpeed);
            transform.localScale += new Vector3(_expansionSpeed, _expansionSpeed, _expansionSpeed) * Time.deltaTime;
            yield return null;
        }

        expansionTarget = _startScale;

        while (transform.localScale.x > _startScale.x)
        {
            transform.localScale -= new Vector3(_expansionSpeed, _expansionSpeed, _expansionSpeed) * Time.deltaTime;
            yield return null;
        }
        
        yield return null;
    }
    
}