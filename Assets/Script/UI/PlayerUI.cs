
using UnityEngine;


public class PlayerUI : MonoBehaviour
{
    public GameObject _heart;
    public GameObject _heart1;
    public GameObject _heart2;
    public GameObject _killCounter;
  
    private Vector3 _killCountPos;


    private void Awake()
    {

        _heart = GetComponentInChildren<GameObject>();
        _heart1 = GetComponentInChildren<GameObject>();
        _heart2 = GetComponentInChildren<GameObject>();
    }

    public void SetKillCount()
    {
        _killCountPos = new Vector3(-16f, -9, 0f);
        Vector3 killpointPos = _killCountPos;
        killpointPos.x += PlayerData.Instance._score + 0.5f;

        Instantiate(_killCounter, killpointPos, Quaternion.identity);
        _killCounter.transform.SetPositionAndRotation(killpointPos, Quaternion.identity);
    }


    public void SetHealth(float currentHealth)
    {
        if (currentHealth >= 3f)
        {
            _heart.SetActive(true); _heart1.SetActive(true); _heart2.SetActive(true);
        }

        if (currentHealth == 2f)
        {
            _heart2.SetActive(false);
        }

        if (currentHealth == 1f)
        {
            _heart1.SetActive(false);
            _heart2.SetActive(false);
        }

        if (currentHealth <= 0f)
        {
            _heart.SetActive(false);
            _heart1.SetActive(false);
            _heart2.SetActive(false);
        }
    }
}