
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public float _ballSpeed = 40f;
    public float _damage = 1f;

    private void FixedUpdate()
    {
        transform.position += Vector3.right * (_ballSpeed * Time.fixedDeltaTime);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}