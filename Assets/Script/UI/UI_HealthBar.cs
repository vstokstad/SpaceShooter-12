using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_HealthBar : MonoBehaviour
{
   public Vector3 _healtBar;
 
   private void Awake()
   {

       _healtBar = GetComponent<Transform>().localScale;
      _healtBar.x = 1f;
      _healtBar.y = 2f;
      _healtBar.z = 1f;

   }

   public void UpdateHealthBar(float hitPoint)
   {     hitPoint /= 10f;
       float currentHealth = PlayerData.Instance._hitPoints -= hitPoint;

       _healtBar.y = currentHealth;
   }
}
