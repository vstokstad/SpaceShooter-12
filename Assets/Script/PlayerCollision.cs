using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerData _playerData;
    private void OnCollisionEnter2D(Collision2D other)
    {
        _playerData = PlayerData.Instance;
        if (other.gameObject.CompareTag("EnemyShip"))
        {
            _playerData.UpdateHitpoints(other.gameObject.GetComponent<EnemyController>()._enemyCollisionDamage);
            
           other.gameObject.GetComponent<EnemyController>()._explosion.Play(true);
            if (_playerData._hitPoints <= 0)
            {
                
            }
        }
    }
}