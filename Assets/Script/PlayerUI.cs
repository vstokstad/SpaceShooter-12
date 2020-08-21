using System;
using UnityEngine;
using UnityEngine.UI;


public class PlayerUI : MonoBehaviour
{
    

    private Text _killPointText;
    public string _killPointString = "Kill Points: ";
    
    private void Awake()
    {
      
        _killPointText = GetComponentInChildren<Text>();
        _killPointText.text = _killPointString;
    }

    public void SetKillPointUI(int killpoints)
    {
        _killPointText.text = _killPointString + killpoints;
    }
}

