using System;
using UnityEngine;

public  class PlayerData : MonoBehaviour
{
    public float _hitPoints = 10f;
    public float _damageModifier = 1f;
    public Weapon _currentWeapon;
    public int _killPoints = 0;
    public Color _playerColor = new Color(0,0,0,1);
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

    public void UpdateScore(int killPoints)
    {
        _killPoints += killPoints;
        _playerUI.SetKillPointUI(_killPoints);
    }

}
