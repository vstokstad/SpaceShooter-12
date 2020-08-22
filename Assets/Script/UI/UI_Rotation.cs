using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Rotation : MonoBehaviour
{
    public GameObject _body;
    

   

    
    void FixedUpdate()
    {

//        _transformRotation.y 
        _body.transform.Rotate(xAngle: 0f, yAngle: 0f, zAngle: 10f);
    }
}
