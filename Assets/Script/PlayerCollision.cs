using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
 
    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("EnemyShip"))
        {
            PlayerData.Instance.UpdateHitpoints(1f);
            other.gameObject.GetComponent<EnemyController>()._explosion.Play(true);
           Destroy(other.gameObject);
            if (PlayerData.Instance._hitPoints <= 0)
            {
              
            }
        }
    }
}