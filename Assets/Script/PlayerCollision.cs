using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerData _playerData;

    private void OnCollisionEnter2D(Collision2D other)
    {
        _playerData = FindObjectOfType<PlayerData>();


        if (other.gameObject.CompareTag("EnemyShip"))
        {
            PlayerData.Instance.UpdateHealth(1f);
            other.gameObject.GetComponent<EnemyController>().Explode();
            
           
        }
    }
}