using System;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [NonSerialized] public float _hitPoints = 10f;
    [NonSerialized] public float _damageModifier = 1f;
    [NonSerialized] public Weapon _currentWeapon;
    [NonSerialized] public float _killPoints = 0f;

    public PlayerUI _playerUI;
    public Vector3 _healtBar;


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
        _healtBar = GetComponent<Transform>().localScale;
        _healtBar.x = 1f;
        _healtBar.y = 2f;
        _healtBar.z = 1f;
    }

    public void UpdateScore(float killPoints)
    {
        _killPoints += killPoints;
        _playerUI.SetKillPointUI();
    }

    public void UpdateHitpoints(float hitPoints)
    {
        _hitPoints -= hitPoints;
        hitPoints /= 10f;
        float currentHealth = PlayerData.Instance._hitPoints -= hitPoints;
        _healtBar.y = currentHealth;
    }
}