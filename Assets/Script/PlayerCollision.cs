using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    PlayerData PlayerData = PlayerData.Instance;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("EnemyShip"))
        {
            PlayerData._hitPoints -= other.gameObject.GetComponent<EnemyController>()._enemyCollisionDamage;
            if (PlayerData._hitPoints <= 0)
            {
                
                gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color(255f, 0f, 0f, 0.5f);
            }
        }
    }
}