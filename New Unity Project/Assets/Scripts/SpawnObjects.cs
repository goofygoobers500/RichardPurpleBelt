using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {



        spawn = difficulty * Time.deltaTime;

        difficulty = Time.deltaTime * 4;


        while (spawn > 0)
        {


            spawn -= 1;

            Vector3 v3Pos = transform.position + new Vector3(Random.value * 40f - 20f, 0, Random.value * 40f - 20f);

            Quaternion qRotation = qRotation = Quaternion.Euler(0, Random.value * 360f, Random.value * 30f);

            GameObject gameObject = Instantiate(spawnCube, v3Pos, qRotation);
        }
    }

    public GameObject spawnCube;

    public float difficulty = 40f;

    float spawn;
}
