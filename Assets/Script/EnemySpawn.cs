using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawn : MonoBehaviour
{
    private Bounds _spawnArea;
    public float _spawnInterval = 2f;
    private float _timer = 0f;
    public GameObject _enemyShip;
    private Camera _camera;


    private void Awake()
    {
        try
        {
            _spawnArea = Camera.main.GetComponent<BoxCollider2D>().bounds;
        }
        catch (Exception e)
        {
            Debug.Log(e);
            throw;
        }
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
        Vector3 spawnPosition;
        spawnPosition.z = 0f;
        spawnPosition.y = Random.Range(_spawnArea.min.y, _spawnArea.max.y);
        spawnPosition.x = _spawnArea.max.x;
        Instantiate(_enemyShip, spawnPosition, Quaternion.identity);
        _timer = _spawnInterval;
    }
}