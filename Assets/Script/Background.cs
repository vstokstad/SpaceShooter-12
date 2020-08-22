using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Background : MonoBehaviour
{
    private Material _material;
    private int[] _texturePropertyNameIDs;
    public GameObject _player;
  
    private void Awake()
    {
  
        _material = GetComponent<MeshRenderer>().material;
        _texturePropertyNameIDs = _material.GetTexturePropertyNameIDs();
    }

    private void FixedUpdate()
    {
        Vector3 playerPosition = _player.transform.position;
        Vector2 currentOffset = _material.GetTextureOffset(_texturePropertyNameIDs[0]);
        currentOffset.x += playerPosition.x / 10f * Time.fixedDeltaTime;
        currentOffset.y += playerPosition.y / 10f * Time.fixedDeltaTime;
        _material.SetTextureOffset(_texturePropertyNameIDs[0], currentOffset);
           
    }
}
