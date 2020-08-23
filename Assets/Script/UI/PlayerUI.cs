using System;
using UnityEngine;



public class PlayerUI : MonoBehaviour
{
    public GameObject _hitPointBar;

    public GameObject _killPoints;
   

    private void Awake()
    {
        
    }

    public void SetKillPointUI()
    {
        Vector3 killpointPos = _killPoints.transform.localPosition;
        killpointPos.x += 1f;
        killpointPos.y += 0f;
        killpointPos.z += 0f;
        Instantiate(_killPoints, killpointPos, Quaternion.identity);
    }
    

  
}