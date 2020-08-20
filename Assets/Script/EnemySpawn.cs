
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
  private Bounds _spawnArea;
  public float _spawnInterval = 2f;
  private float _timer = 0f;
  public GameObject _enemyShip;
  private void Awake()
  {
    _spawnArea = GetComponent<Collider2D>().bounds;
    
  }

  private void FixedUpdate()
  {
    _timer -= Time.fixedDeltaTime;
    if (_timer <= 0f)
    {
      SpawnEnemy();
    }
   
  }

  private void SpawnEnemy()
  {
    Vector2 spawnPosition;
    spawnPosition.y = Random.Range(min: _spawnArea.min.y, max: _spawnArea.max.y);
    spawnPosition.x = Random.Range(min: _spawnArea.min.x, max: _spawnArea.max.x);
    Instantiate(_enemyShip, spawnPosition, Quaternion.identity);
    _timer = _spawnInterval;
  }
}
