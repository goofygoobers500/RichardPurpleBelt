using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Spikes Object for controling the game")]
    public GameObject stalagmite_1;

    [Header("Default Height")]
    public float height;
    void Start()
    {
        InvokeRepeating("InstantiateObjects", 1f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(5, Random.Range(-height, height), 0);
    }

    void InstantiateObjects()
    {
        Instantiate(stalagmite_1, transform.position, transform.rotation);

    }
}
