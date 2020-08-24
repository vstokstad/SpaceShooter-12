using System;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [NonSerialized] public float _health = 2f;
  
    [NonSerialized] public float _score = 0f;

    public PlayerUI _playerUI;


    internal static PlayerData Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

     

    }

    public void AddKill()
    {
       
        _playerUI.SetKillCount();
        _score += 1f;
    }

    public void UpdateHealth(float damage)
    {
       
        _playerUI.SetHealth(damage);
        
       
    }
}