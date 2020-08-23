using System;
using UnityEngine;

public  class PlayerData : MonoBehaviour
{
    [NonSerialized] public float _hitPoints = 10f;
    [NonSerialized] public float _killPoints = 0f;
    private PlayerUI _playerUI;

    public static PlayerData Instance { get; private set; }
    
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

        _playerUI = GetComponent<PlayerUI>();
    }

    public void UpdateScore(float killPoints)
    {
        _killPoints += killPoints;
        _playerUI.SetKillPointUI(_killPoints);
    }

    public void UpdateHitpoints(float hitPoints)
    {
        _hitPoints += hitPoints;
        _playerUI.SetHitPointsUI(_hitPoints);
        
    }
}
