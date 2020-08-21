using System;
using UnityEngine;

public  class PlayerData : MonoBehaviour
{
    public float _hitPoints = 10f;
    public float _damageModifier = 1f;
    public Weapon _currentWeapon;
    public float _killPoints = 0f;
    public Color _playerColor;
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
        _playerColor = GetComponent<Color>();
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
