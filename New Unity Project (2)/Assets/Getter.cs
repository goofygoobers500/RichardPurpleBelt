using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Getter : MonoBehaviour
{
    // Start is called before the first frame update
    public int Health;
    void Start()
    {
        Health = GetComponentInParent<Variable>().Health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
