﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;


       if (transform.localScale.x <= .05f)
        {

            Destroy(gameObject);
        }
    }

    public Rigidbody2D rb;

    public float shrinkSpeed = 3f;
}
