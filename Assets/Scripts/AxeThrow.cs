﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeThrow : MonoBehaviour
{
    // Start is called before the first frame update
    public float throwspeed = 10;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Vector3.left * Time.deltaTime * throwspeed);
 
    }
}
