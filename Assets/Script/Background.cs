using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private Material _material;
    private Vector2 _position;
    private void Awake()
    {
        _material = GetComponent<MeshRenderer>().material;
    }

    private void FixedUpdate()
    {
        Vector2 currentOffset = _material.GetTextureOffset(0);
        currentOffset.x += 0.1f * Time.fixedDeltaTime;
        currentOffset.y += Mathf.Sin(Mathf.PI * Time.fixedDeltaTime);
        _material.SetTextureOffset(0, currentOffset);
           
    }
}
