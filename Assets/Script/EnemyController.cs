using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D _enemyBody;
    public float _hitPoints = 1f;
    public float _movementSpeed = 3f;
    public float _enemyCollisionDamage = 1f;
    public ParticleSystem _explosion;

    private void Awake()
    {
        _enemyBody = GetComponent<Rigidbody2D>();
        _explosion = GetComponentInChildren<ParticleSystem>();
    }

    private void Start()
    {
        Vector2 velocity = new Vector2(_movementSpeed * Random.Range(0.2f, 3f),
            Mathf.Sin(Mathf.PI * (_movementSpeed * Time.time)));
        _enemyBody.velocity -= velocity;
    }

    private void FixedUpdate()
    {
        Vector2 velocity = new Vector2(_enemyBody.velocity.x, Mathf.Sin(Mathf.PI * Time.time));
        _enemyBody.velocity = velocity;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CannonBall"))
        {
            float damage = other.gameObject.GetComponent<CannonBall>()._damage;
            TakeDamage(damage);
        }
    }

    private void TakeDamage(float damage)
    {
        _hitPoints -= damage;
        if (_hitPoints <= 0f)
        {
            Explode();
            // PlayerData.Instance.UpdateScore(1);
        }
    }

    private void Explode()
    {
        GetComponentInChildren<Renderer>().enabled = false;
        _explosion.Play();
        Destroy(gameObject, _explosion.main.duration);
        GetComponentInChildren<Collider2D>().enabled = false;
        this.enabled = false;
    }
}