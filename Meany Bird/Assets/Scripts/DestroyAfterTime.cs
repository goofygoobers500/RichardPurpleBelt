﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{

    public float timeToDescruction;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyObject", timeToDescruction);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void DestroyObject()
    {

        Destroy(gameObject);
    }
}