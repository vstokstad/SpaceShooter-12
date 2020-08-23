﻿using System;
using UnityEditor;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [NonSerialized] public float _health = 2f;
   // [NonSerialized] public float _damageModifier = 1f;
   // [NonSerialized] public Weapon _currentWeapon;
    [NonSerialized] public float _score = 0f;

    public PlayerUI _playerUI;
   


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

     

    }

    public void AddKill()
    {
       
        _playerUI.SetKillCount();
        _score += 1f;
    }

    public void UpdateHealth(float damage)
    {
        damage /= 2f;
        _health -= damage;
        _playerUI.SetHealth(_health);
       
    }
}