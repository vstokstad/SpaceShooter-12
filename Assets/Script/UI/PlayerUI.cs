using System;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;


public class PlayerUI : MonoBehaviour
{

    public GameObject _hitPointBar;
    public Text _killPointText;
   // public string _killPointString = "Kill Points: ";
    
    private void Awake()
    {
     //   _hitPointBar = 
        
      // _killPointText.text = _killPointString;
        
    }

    public void SetKillPointUI(float killpoints)
    {
        _killPointText.text = killpoints.ToString();
       
    }

    public void SetHitPointsUI(float hitpoints)
    {
        Vector3 scale = _hitPointBar.transform.localScale;
        scale.z += hitpoints;
    }
}

