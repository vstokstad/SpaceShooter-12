using System;
using UnityEngine;



public class PlayerUI : MonoBehaviour
{
    public GameObject _healthBar;

    public GameObject _killCounter;
    private Vector3 _killCountPos;


    private void Awake()
    {
       
       
        SetHealth(PlayerData.Instance._health);
       
    }

    public void SetKillCount()
    {
        _killCountPos = new Vector3(-16f, -9, 0f);
        Vector3 killpointPos = _killCountPos;
        killpointPos.x += PlayerData.Instance._score + 0.5f;

        Instantiate(_killCounter, killpointPos, Quaternion.identity);
        _killCounter.transform.SetPositionAndRotation(killpointPos,Quaternion.identity);
        
       
    }

    public void SetHealth(float currentHealth)
    {
        Vector3 health = _healthBar.transform.localScale;
        health.y -= currentHealth;
        _healthBar.transform.localScale = health;
    }



}